﻿using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otgul.DataBase.Repository.Repository
{
    public class UserRepository : IDataBaseRepository<User>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public UserRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public User Create(User item)
        {
            return db.Users.Add(item).Entity;
        }

        public void Delete(long id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(System.Linq.Expressions.Expression<Func<User, bool>> predicate, bool fullData)
        {
            IQueryable<User> query = db.Users
                .Where(predicate)
                .Include(s => s.Department)
                .Include(s => s.Otdel)
                .Include(s => s.Role)
                .ThenInclude(f => f.RoleRights)
                .Include(s => s.UserRights)
                .ThenInclude(f => f.Right);
            return query;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(s => s.UserRights).ThenInclude(f => f.Right).ToList();
        }

        public User GetId(Int64 id)
        {
            return db.Users.AsNoTracking().Include(s => s.UserRights).ThenInclude(f => f.Right).FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> query = db.Users.Where(predicate);
            return query.Count();
        }

        public void Update(User item)
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
