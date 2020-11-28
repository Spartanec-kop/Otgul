using System;
using System.Collections.Generic;
using System.Text;

namespace Otguls.DataBase.Models
{
    public class Right
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<UserRights> UserRights { get; set; }
        public List<RightRole> RightRoles { get; set; }

        public Right()
        {
            UserRights = new List<UserRights>();
            RightRoles = new List<RightRole>();
        }
    }
}
