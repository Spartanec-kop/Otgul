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

        public OtgulRecord Create(OtgulRecord item)
        {
            return db.OtgulRecords.Add(item).Entity;
        }

        public void Delete(long id)
        {
            OtgulRecord otgul = db.OtgulRecords.Find(id);
            if (otgul != null)
            {
                db.OtgulRecords.Remove(otgul);
            }
        }

        public IEnumerable<OtgulRecord> Find(Expression<Func<OtgulRecord, bool>> predicate, bool fullData)
        {
            if (fullData)
            {
                IQueryable<OtgulRecord> query = db.OtgulRecords.
                    Where(predicate)
                    .Include(s => s.Guide)
                    .Include(s => s.User)
                    .ThenInclude(s => s.Department)
                    .Include(s => s.User)
                    .ThenInclude(s => s.Otdel)
                    .Include(s => s.User)
                    .ThenInclude(s => s.Role)
                    .ThenInclude(f => f.RoleRights)
                    .Include(s => s.User)
                    .ThenInclude(s => s.UserRights)
                    .ThenInclude(f => f.Right)

                    .Include(s => s.Initiator)
                    .ThenInclude(s => s.Department)
                    .Include(s => s.Initiator)
                    .ThenInclude(s => s.Otdel)
                    .Include(s => s.Initiator)
                    .ThenInclude(s => s.Role)
                    .ThenInclude(f => f.RoleRights)
                    .Include(s => s.Initiator)
                    .ThenInclude(s => s.UserRights)
                    .ThenInclude(f => f.Right);
                return query;
            }
            else
            {
                IQueryable<OtgulRecord> query = db.OtgulRecords.
                    Where(predicate);
                return query;
            }
            
        }

        public IEnumerable<OtgulRecord> GetAll()
        {
            return db.OtgulRecords.ToList();
        }

        public OtgulRecord GetId(Int64 id)
        {
            return db.OtgulRecords.FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(Expression<Func<OtgulRecord, bool>> predicate)
        {
            IQueryable<OtgulRecord> query = db.OtgulRecords.Where(predicate);
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