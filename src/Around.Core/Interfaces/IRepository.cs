using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Around.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Get(string code);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        T FirstOrDefault(Func<T, bool> predicate);

        Task<T> FirstOrDefaultAsync(Func<T, bool> predicate);
    }
}
