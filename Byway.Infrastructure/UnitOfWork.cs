using Byway.Domain;
using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Infrastructure._Data;
using Byway.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure
{
    public class UnitOfWork(BywayDbContext context) : IUnitOfWork
    {
        private readonly BywayDbContext _context = context;
        private readonly Hashtable _repositories = [];
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var key = typeof(TEntity).Name;
            if (!_repositories.Contains(key))
            {
                var repository = new Repository<TEntity>(_context);
                _repositories.Add(key, repository);
                return repository;
            }

            return _repositories[key] as Repository<TEntity>;
        }

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public ValueTask DisposeAsync()
            => _context.DisposeAsync();

    }
}
