using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otgul.Api.ViewModel
{
    public class ViewUser
    {
        public int id { get; set; }
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string role { get; set; }
        public Otdel otdel { get; set; }
        public Department department { get; set; }
        public IEnumerable<ViewRight> rights { get; set; }
    }

    public class ViewRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
