using System;
using System.Collections.Generic;
using System.Text;

namespace Otguls.DataBase.Models
{
    public class Department
    {
        public int id { get; set; }
        public int departmentCode { get; set; }
        public string name { get; set; }
        public string chief { get; set; }
    }
}
