using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.DataBase.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Otgul.Repository.Repository
{
    public class RightsRepository : IDataBaseRepository<Rights>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public RightsRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(Rights item)
        {
            db.Rights.Add(item);
        }

        public void Delete(long id)
        {
            Rights rights = db.Rights.Find(id);
            if (rights != null)
            {
                db.Rights.Remove(rights);
            }
        }
                
        public IEnumerable<Rights> Find(Expression<Func<Rights, bool>> predicate)
        {
            IQueryable<Rights> query = db.Rights.Where(predicate);
            return query;
        }

        public IEnumerable<Rights> GetAll()
        {
            return db.Rights.ToList();
        }

        public Rights GetId(int id)
        {
            return db.Rights.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<Rights, bool>> predicate)
        {
            IQueryable<Rights> query = db.Rights.Where(predicate);
            return query.Count();
        }

        public void Update(Rights item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
