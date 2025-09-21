using Byway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Domain.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderByAsc { get; set; } = null!;
        public Expression<Func<T, object>> OrderByDesc { get; set; } = null!;
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagenationEnabled { get; set; }

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>>? criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
        protected virtual void AddOrderByAsc(Expression<Func<T, object>> orderByAscExpression)
        {
            OrderByAsc = orderByAscExpression;
        }
        protected virtual void ApplyPagination(int skip, int take)
        {
            IsPagenationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
