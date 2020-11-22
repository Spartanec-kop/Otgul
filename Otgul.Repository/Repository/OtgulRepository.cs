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
    public class OtgulRepository : IDataBaseRepository<Otguls>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public OtgulRepository(OtgulDBContext context)
        {
            this.db = context;
        }

        public void Create(Otguls item)
        {
            db.Otgul.Add(item);
        }

        public void Delete(long id)
        {
            Otguls otgul = db.Otgul.Find(id);
            if (otgul != null)
            {
                db.Otgul.Remove(otgul);
            }
        }

        public IEnumerable<Otguls> Find(Expression<Func<Otguls, bool>> predicate)
        {
            IQueryable<Otguls> query = db.Otgul.Where(predicate);
            return query;
        }

        public IEnumerable<Otguls> GetAll()
        {
            return db.Otgul.ToList();
        }

        public Otguls GetId(int id)
        {
            return db.Otgul.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<Otguls, bool>> predicate)
        {
            IQueryable<Otguls> query = db.Otgul.Where(predicate);
            return query.Count();
        }
        public void Update(Otguls item)
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