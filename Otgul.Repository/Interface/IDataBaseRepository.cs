using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Repository.Interface
{
    public interface IDataBaseRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(Int64 id);
        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate, bool fullData = true);
        int recordCount(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        T Create(T item);
        void Update(T item);
        void Delete(Int64 id);
        void Save();
    }
}
