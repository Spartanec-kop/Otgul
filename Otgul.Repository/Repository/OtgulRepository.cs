using Microsoft.EntityFrameworkCore;
using Otguls.DataBase;
using Otguls.DataBase.Models;
using Otguls.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Otguls.Repository.Repository
{
    public class OtgulRepository : IDataBaseRepository<DataBase.Models.Otgul>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public OtgulRepository(OtgulDBContext context)
        {
            this.db = context;
        }

        public void Create(DataBase.Models.Otgul item)
        {
            db.Otguls.Add(item);
        }

        public void Delete(long id)
        {
            Otgul otgul = db.Otguls.Find(id);
            if (otgul != null)
            {
                db.Otguls.Remove(otgul);
            }
        }

        public IEnumerable<DataBase.Models.Otgul> Find(Expression<Func<DataBase.Models.Otgul, bool>> predicate)
        {
            IQueryable<Otgul> query = db.Otguls.Where(predicate);
            return query;
        }

        public IEnumerable<DataBase.Models.Otgul> GetAll()
        {
            return db.Otguls.ToList();
        }

        public DataBase.Models.Otgul GetId(int id)
        {
            return db.Otguls.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<DataBase.Models.Otgul, bool>> predicate)
        {
            IQueryable<Otgul> query = db.Otguls.Where(predicate);
            return query.Count();
        }
        public void Update(DataBase.Models.Otgul item)
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