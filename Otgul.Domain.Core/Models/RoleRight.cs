using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class RoleRight
    {
        public int RoleId { get; set; }
        public int RightId { get; set; }
        public Right Right { get; set; }
        public Role Role { get; set; }

    }
}
