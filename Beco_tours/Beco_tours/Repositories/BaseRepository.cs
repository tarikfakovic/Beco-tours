using System;
using Beco_tours.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Beco_tours.Contracts.Repository;

namespace Beco_tours.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> SelectAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
    }
}


