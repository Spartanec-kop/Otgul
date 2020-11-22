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
    public class UserRightsRepository : IDataBaseRepository<UserRights>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public UserRightsRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(UserRights item)
        {
            db.UserRights.Add(item);
        }

        public void Delete(long id)
        {
            UserRights userRights = db.UserRights.Find(id);
            if (userRights != null)
            {
                db.UserRights.Remove(userRights);
            }
        }
        public IEnumerable<UserRights> Find(Expression<Func<UserRights, bool>> predicate)
        {
                IQueryable<UserRights> query = db.UserRights.Where(predicate);
                return query;
            }

        public IEnumerable<UserRights> GetAll()
        {
            return db.UserRights.ToList();
        }

        public UserRights GetId(int id)
        {
            throw new NotImplementedException();
        }

        public int recordCount(Expression<Func<UserRights, bool>> predicate)
        {
            IQueryable<UserRights> query = db.UserRights.Where(predicate);
            return query.Count();
        }

        public void Update(UserRights item)
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
