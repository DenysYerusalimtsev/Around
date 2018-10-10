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
        protected DronesharingContext db;
        protected DbSet<T> dbSet;

        public Repository(DronesharingContext context)
        {
            db = context;
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T obj = dbSet.Find(id);
            if (obj != null)
                dbSet.Remove(obj);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public Task<T> FirstOrDefaultAsync(Func<T, bool> predicate)
        {
            return Task.Run(() => dbSet.FirstOrDefault(predicate));
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(string code)
        {
            return dbSet.Find(code);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
