using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Otgul.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Tabel { get; set; }
        public string FirstName { get; set; }
        public string WorkStatus { get; set; }
        //public int OtdelId { get; set; }
        
        [ForeignKey("otdelId")]
        public Otdel Otdel { get; set; }
        public int DepartmentId { get; set; }
        
        [ForeignKey("departmentId")]
        public Department Department { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public int RoleId { get; set; }
        
        [ForeignKey("roleId")]
        public Role Role { get; set; }
        public List<UserRights> UserRights { get; set; }

        public User()
        {
            UserRights = new List<UserRights>();
            IsDeleted = false;
        } 
    }
}
