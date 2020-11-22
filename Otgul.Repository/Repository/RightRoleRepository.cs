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
    public class RightRoleRepository : IDataBaseRepository<RightRole>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public RightRoleRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(RightRole item)
        {
            db.RightRole.Add(item);
        }

        public void Delete(long id)
        {
            RightRole rightrole = db.RightRole.Find(id);
            if (rightrole != null)
            {
                db.RightRole.Remove(rightrole);
            }
        }

        public IEnumerable<RightRole> Find(Expression<Func<RightRole, bool>> predicate)
        {
            IQueryable<RightRole> query = db.RightRole.Where(predicate);
            return query;
        }

        public IEnumerable<RightRole> GetAll()
        {
            return db.RightRole.ToList();
        }

        public RightRole GetId(int id)
        {
            throw new NotImplementedException();
        }

        public int recordCount(Expression<Func<RightRole, bool>> predicate)
        {
            IQueryable<RightRole> query = db.RightRole.Where(predicate);
            return query.Count();
        }
        public void Update(RightRole item)
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