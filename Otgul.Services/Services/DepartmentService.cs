using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDataBaseRepository<Department> _departmentRepository;

        public DepartmentService(IDataBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void CreateDepartment(Department department)
        {
            _departmentRepository.Create(department);
            _departmentRepository.Save();
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
            _departmentRepository.Save();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
           return _departmentRepository.GetAll();
        }

        public Department GetDepartmentFromId(int departmentId)
        {
            return _departmentRepository.GetId(departmentId);
        }

        public void RemoveDepartment(int departmentId)
        {
            Department department = _departmentRepository.GetId(departmentId);
            if (department != null)
            {
                _departmentRepository.Delete(departmentId);
                _departmentRepository.Save();
            }
        }
    }
}
