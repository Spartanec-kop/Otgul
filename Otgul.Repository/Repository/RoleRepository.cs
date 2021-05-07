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
    public class RoleRepository : IDataBaseRepository<Role>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public RoleRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public Role Create(Role item)
        {
            return db.Roles.Add(item).Entity;
        }

        public void Delete(long id)
        {
            Role role = db.Roles.Find(id);
            if (role != null)
            {
                db.Roles.Remove(role);
            }
        }
                
        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate, bool fullData)
        {
            IQueryable<Role> query = db.Roles.Include(s => s.RoleRights).ThenInclude(f => f.Right).Where(predicate);
            return query;
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Roles.Include(s => s.RoleRights).ThenInclude(f => f.Right).ToList();
        }

        public Role GetId(Int64 id)
        {
            return db.Roles.Include(s => s.RoleRights).ThenInclude(f => f.Right).FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(Expression<Func<Role, bool>> predicate)
        {
            IQueryable<Role> query = db.Roles.Where(predicate);
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
