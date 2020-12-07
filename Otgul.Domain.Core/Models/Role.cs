using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
       public List<RoleRights> RoleRights { get; set; }
        public Role()
        {
            RoleRights = new List<RoleRights>();
        }
    }
}
