using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.DataBase.Models
{
    public class User
    {
        public int id { get; set; }
        public int idRole { get; set; }
        public string tabel { get; set; }
        public string firstName { get; set; }
        public string workStatus { get; set; }
        public int idOtdel { get; set; }
        public int idDepartament { get; set; }
        public string phone { get; set; }
        public bool isDeleted { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
