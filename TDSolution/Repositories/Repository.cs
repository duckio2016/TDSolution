using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TDSolution.Models;

namespace TDSolution.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? Find(object id);

        IEnumerable<T> GetAll();

        IQueryable<T> Query();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        bool Exists(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>>? predicate = null);

        void Save();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TDSolutionEntities _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(TDSolutionEntities context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T? Find(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public int Count(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}