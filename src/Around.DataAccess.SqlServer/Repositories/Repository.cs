using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Around.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Around.DataAccess.SqlServer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DronesharingContext _db;
        protected DbSet<T> _dbSet;

        public Repository(DronesharingContext context)
        {
            _db = context;
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T obj = _dbSet.Find(id);
            if (obj != null)
                _dbSet.Remove(obj);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public Task<T> FirstOrDefaultAsync(Func<T, bool> predicate)
        {
            return Task.Run(() => _dbSet.FirstOrDefault(predicate));
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(string code)
        {
            return _dbSet.Find(code);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
