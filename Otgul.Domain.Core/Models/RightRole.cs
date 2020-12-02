using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class RightRole
    {
        public int RoleId { get; set; }
        public int RightId { get; set; }
        public Right Rights { get; set; }
        public Role Roles { get; set; }

    }
}
