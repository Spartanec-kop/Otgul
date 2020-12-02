using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
       public List<RightRole> RightRoles { get; set; }
        public Role()
        {
            RightRoles = new List<RightRole>();
        }
    }
}
