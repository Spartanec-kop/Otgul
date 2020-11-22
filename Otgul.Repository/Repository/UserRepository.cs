﻿using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.DataBase.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otgul.Repository.Repository
{
    public class UserRepository : IDataBaseRepository<User>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public UserRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(long id)
        {
            User user = db.User.Find(id);
            if (user != null)
            {
                db.User.Remove(user);
            }
        }

        public IEnumerable<User> Find(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> query = db.User.Where(predicate);
            return query;
        }

        public IEnumerable<User> GetAll()
        {
            return db.User.ToList();
        }

        public User GetId(int id)
        {
            return db.User.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> query = db.User.Where(predicate);
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
