using Microsoft.EntityFrameworkCore;
using Otgul.DataBase;
using Otgul.DataBase.Models;
using Otgul.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otgul.Repository.Repository
{
    public class DepartmentReposirory : IDataBaseReposirory<Department>
    {
        private readonly OtgulDBContext db;
        private bool disposed = false;

        public DepartmentReposirory(OtgulDBContext context)
        {
            this.db = context;
        }
        public void Create(Department item)
        {
            db.Department.Add(item);
        }

        public void Delete(long id)
        {
            Department department = db.Department.Find(id);
            if (department != null)
            {
                db.Department.Remove(department);
            }
        }

        public IEnumerable<Department> Find(System.Linq.Expressions.Expression<Func<Department, bool>> predicate)
        {
            IQueryable<Department> query = db.Department.Where(predicate);
            return query;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Department.ToList();
        }

        public Department GetId(int id)
        {
            return db.Department.FirstOrDefault(s => s.id == id);
        }

        public int recordCount(System.Linq.Expressions.Expression<Func<Department, bool>> predicate)
        {
            IQueryable<Department> query = db.Department.Where(predicate);
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
