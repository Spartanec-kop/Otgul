using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Repository.Interface
{
    public interface IDataBaseReposirory<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        int recordCount(System.Linq.Expressions.Expression<Func<T, Boolean>> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(Int64 id);
        void Save();
    }
}
