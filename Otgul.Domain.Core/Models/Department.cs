using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int DepartmentCode { get; set; }
        public string Name { get; set; }
        public User Chief { get; set; }
    }
}
