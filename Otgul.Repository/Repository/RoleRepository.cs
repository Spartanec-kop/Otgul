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
    public class RoleRepository : IDataBaseRepository<Role>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public RoleRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(Role item)
        {
            db.Role.Add(item);
        }

        public void Delete(long id)
        {
            Role role = db.Role.Find(id);
            if (role != null)
            {
                db.Role.Remove(role);
            }
        }
                
        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            IQueryable<Role> query = db.Role.Where(predicate);
            return query;
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Role.ToList();
        }

        public Role GetId(int id)
        {
            return db.Role.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<Role, bool>> predicate)
        {
            IQueryable<Role> query = db.Role.Where(predicate);
            return query.Count();
        }

        public void Update(Role item)
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
