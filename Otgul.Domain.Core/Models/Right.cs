using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class Right
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRights> UserRights { get; set; }
        public List<RightRole> RightRoles { get; set; }

        public Right()
        {
            UserRights = new List<UserRights>();
            RightRoles = new List<RightRole>();
        }
    }
}
