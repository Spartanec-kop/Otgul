using Microsoft.EntityFrameworkCore;
using Otguls.DataBase;
using Otguls.DataBase.Models;
using Otguls.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otguls.Repository.Repository
{
    public class DepartmentRepository : IDataBaseRepository<Department>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public DepartmentRepository(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(Department item)
        {
            db.Departments.Add(item);
        }

        public void Delete(long id)
        {
            Department department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
            }
        }

        public IEnumerable<Department> Find(System.Linq.Expressions.Expression<Func<Department, bool>> predicate)
        {
            IQueryable<Department> query = db.Departments.Where(predicate);
            return query;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetId(int id)
        {
            return db.Departments.FirstOrDefault(s => s.id == id);
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
