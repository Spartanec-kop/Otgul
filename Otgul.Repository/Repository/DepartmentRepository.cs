using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otgul.DataBase.Repository.Repository
{
    public class DepartmentRepository : IDataBaseRepository<Department>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public DepartmentRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public Department Create(Department item)
        {
            return db.Departments.Add(item).Entity;
        }

        public void Delete(long id)
        {
            Department department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
            }
        }

        public IEnumerable<Department> Find(System.Linq.Expressions.Expression<Func<Department, bool>> predicate, bool fullData)
        {
            IQueryable<Department> query = db.Departments.Where(predicate);
            return query;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetId(Int64 id)
        {
            return db.Departments.FirstOrDefault(s => s.Id == id);
        }

        public int recordCount(System.Linq.Expressions.Expression<Func<Department, bool>> predicate)
        {
            IQueryable<Department> query = db.Departments.Where(predicate);
            return query.Count();
        }
        public void Update(Department item)
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
