using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Otgul.DataBase.Repository.Repository
{
    public class OtdelRepository : IDataBaseRepository<Otdel>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public OtdelRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(Otdel item)
        {
            db.Otdels.Add(item);
        }

        public void Delete(long id)
        {
            Otdel otdel = db.Otdels.Find(id);
            if (otdel != null)
            {
                db.Otdels.Remove(otdel);
            }
        }
               
        public IEnumerable<Otdel> Find(Expression<Func<Otdel, bool>> predicate)
        {
            IQueryable<Otdel> query = db.Otdels.Where(predicate);
            return query;
        }

        public IEnumerable<Otdel> GetAll()
        {
            return db.Otdels.ToList(); ;
        }

        public Otdel GetId(int id)
        {
            return db.Otdels.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<Otdel, bool>> predicate)
        {
            IQueryable<Otdel> query = db.Otdels.Where(predicate);
            return query.Count();
        }
                
        public void Update(Otdel item)
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
