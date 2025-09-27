using Byway.Domain.Entities;
using Byway.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Repositoies.Contract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetWithSpecsAsync(ISpecification<TEntity> specs);
        Task<TEntity?> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity> specs);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> GetCountWithspecsAsync(ISpecification<TEntity> specs);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
