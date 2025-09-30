using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Infrastructure._Data;
using Byway.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BywayDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<Type, object> _repositories = new();

        public UnitOfWork(BywayDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(IRepository<TEntity>);

            return (IRepository<TEntity>)_repositories.GetOrAdd(
                type,
                _ => new Repository<TEntity>(_context)
            );
        }

        public TRepo Repository<TEntity, TRepo>()
            where TRepo : IRepository<TEntity>
            where TEntity : BaseEntity
        {
            var type = typeof(TRepo);

            return (TRepo) _repositories.GetOrAdd(
                type,
                _ => _serviceProvider.GetRequiredService<TRepo>()
            );
        }

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public ValueTask DisposeAsync()
            => _context.DisposeAsync();
    }
}
