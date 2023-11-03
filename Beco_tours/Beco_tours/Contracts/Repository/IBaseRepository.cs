using System;
using System.Linq.Expressions;

namespace Beco_tours.Contracts.Repository
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> SelectAll();
        IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

