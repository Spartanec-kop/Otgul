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
    public class OtgulRecordRepository : IDataBaseRepository<OtgulRecord>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public OtgulRecordRepository(OtgulDBContext context)
        {
            this.db = context;
        }

        public void Create(OtgulRecord item)
        {
            db.Otgul.Add(item);
        }

        public void Delete(long id)
        {
            OtgulRecord otgul = db.Otgul.Find(id);
            if (otgul != null)
            {
                db.Otgul.Remove(otgul);
            }
        }

        public IEnumerable<OtgulRecord> Find(Expression<Func<OtgulRecord, bool>> predicate)
        {
            IQueryable<OtgulRecord> query = db.Otgul.Where(predicate);
            return query;
        }

        public IEnumerable<OtgulRecord> GetAll()
        {
            return db.Otgul.ToList();
        }

        public OtgulRecord GetId(int id)
        {
            return db.Otgul.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<OtgulRecord, bool>> predicate)
        {
            IQueryable<OtgulRecord> query = db.Otgul.Where(predicate);
            return query.Count();
        }
        public void Update(OtgulRecord item)
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