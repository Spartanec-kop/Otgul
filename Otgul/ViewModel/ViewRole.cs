using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Api.ViewModel
{
    public class ViewRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
       public List<ViewRight> RoleRights { get; set; }
        public ViewRole()
        {
            RoleRights = new List<ViewRight>();
        }
    }
}
