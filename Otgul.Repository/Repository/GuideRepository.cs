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
    public class GuideRepository : IDataBaseRepository<Guide>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public GuideRepository(OtgulDBContext context)
        {
            this.db = context;
        }

        public Guide Create(Guide item)
        {
            return db.Guides.Add(item).Entity;
        }

        public void Delete(long id)
        {
            Guide guide = db.Guides.Find(id);
            if (guide != null)
            {
                db.Guides.Remove(guide);
            }
        }

        
        public IEnumerable<Guide> Find(Expression<Func<Guide, bool>> predicate, bool fullData)
        {
            IQueryable<Guide> query = db.Guides.Where(predicate);
            return query;
        }

        public IEnumerable<Guide> GetAll()
        {
            return db.Guides.ToList();
        }

        public Guide GetId(Int64 id)
        {
            return db.Guides.FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(Expression<Func<Guide, bool>> predicate)
        {
            IQueryable<Guide> query = db.Guides.Where(predicate);
            return query.Count();
        }

        public void Update(Guide item)
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
