using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IDepartmentService
    {
        void CreateDepartment(Department department);
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartmentFromId(int departmentId);
        void UpdateDepartment(Department department);
        void RemoveDepartment(int departmentId);
    }
}
