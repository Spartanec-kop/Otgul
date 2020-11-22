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
    public class GuideRepository : IDataBaseRepository<Guide>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public GuideRepository(OtgulDBContext context)
        {
            this.db = context;
        }

        public void Create(Guide item)
        {
            db.Guide.Add(item);
        }

        public void Delete(long id)
        {
            Guide guide = db.Guide.Find(id);
            if (guide != null)
            {
                db.Guide.Remove(guide);
            }
        }

        
        public IEnumerable<Guide> Find(Expression<Func<Guide, bool>> predicate)
        {
            IQueryable<Guide> query = db.Guide.Where(predicate);
            return query;
        }

        public IEnumerable<Guide> GetAll()
        {
            return db.Guide.ToList();
        }

        public Guide GetId(int id)
        {
            return db.Guide.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(Expression<Func<Guide, bool>> predicate)
        {
            IQueryable<Guide> query = db.Guide.Where(predicate);
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
