using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otgul.Api.ViewModel
{
    public class ViewUser
    {
        public int Id { get; set; }
        public Int16 Tabel { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string WorkStatus { get; set; }
        public ViewRole Role { get; set; }
        public Otdel Otdel { get; set; }
        public Department Department { get; set; }
        public IEnumerable<ViewRight> UserRights { get; set; }
    }
}
