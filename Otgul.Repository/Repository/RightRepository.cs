﻿using Microsoft.EntityFrameworkCore;
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
    public class RightRepository : IDataBaseRepository<Right>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public RightRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public Right Create(Right item)
        {
            return db.Rights.Add(item).Entity;
        }

        public void Delete(long id)
        {
            Right rights = db.Rights.Find(id);
            if (rights != null)
            {
                db.Rights.Remove(rights);
            }
        }
                
        public IEnumerable<Right> Find(Expression<Func<Right, bool>> predicate, bool fullData)
        {
            IQueryable<Right> query = db.Rights.Where(predicate);
            return query;
        }

        public IEnumerable<Right> GetAll()
        {
            return db.Rights.ToList();
        }

        public Right GetId(Int64 id)
        {
            return db.Rights.FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(Expression<Func<Right, bool>> predicate)
        {
            IQueryable<Right> query = db.Rights.Where(predicate);
            return query.Count();
        }

        public void Update(Right item)
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
