using Byway.Domain.Entities;
using Byway.Domain.Repositoies.Contract;
using Byway.Domain.Specification;
using Byway.Infrastructure._Data;
using Byway.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Infrastructure.Repositories
{
    public class Repository<T> (BywayDbContext context) : IRepository<T> where T : BaseEntity
    {
        private readonly BywayDbContext _Context = context;

        public void Add(T entity) => _Context.Add(entity);

        public void Update(T entity) => _Context.Update(entity);

        public void Delete(T entity) => _Context.Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> specs) 
            =>  await ApplySpecifications(specs).ToListAsync();
        

        public async Task<int> GetCountWithspecsAsync(ISpecification<T> specs) 
            => await ApplySpecifications(specs).CountAsync();
        

        public async Task<T?> GetWithSpecsAsync(ISpecification<T> specs) 
            => await ApplySpecifications(specs).FirstOrDefaultAsync();
        

        
        private IQueryable<T> ApplySpecifications(ISpecification<T> specs) 
            => SpecificationEvaluator<T>.BuildQuery(_Context.Set<T>(), specs);
        

    }
}
