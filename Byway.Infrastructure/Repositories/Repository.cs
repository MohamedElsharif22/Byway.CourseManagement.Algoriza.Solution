using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using Byway.Infrastructure.Data;
using Byway.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure.Repositories
{
    public class Repository<T> (AppDbContext dbContext) : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext = dbContext;

        public void Add(T entity) => _dbContext.Add(entity);

        public void Update(T entity) => _dbContext.Update(entity);

        public void Delete(T entity) => _dbContext.Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> specs) 
            =>  await ApplySpecifications(specs).ToListAsync();
        

        public async Task<int> GetCountWithspecsAsync(ISpecification<T> specs) 
            => await ApplySpecifications(specs).CountAsync();
        

        public async Task<T?> GetWithSpecsAsync(ISpecification<T> specs) 
            => await ApplySpecifications(specs).FirstOrDefaultAsync();
        

        
        private IQueryable<T> ApplySpecifications(ISpecification<T> specs) 
            => SpecificationEvaluator<T>.BuildQuery(_dbContext.Set<T>(), specs);
        

    }
}
