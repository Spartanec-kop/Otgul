using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Tabel { get; set; }
        public string FirstName { get; set; }
        public string WorkStatus { get; set; }
        public Otdel Otdel { get; set; }
        public Department Department { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<UserRights> UserRights { get; set; }

        public User()
        {
            UserRights = new List<UserRights>();
            IsDeleted = false;
        } 
    }
}
