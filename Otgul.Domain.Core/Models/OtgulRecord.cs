using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class OtgulRecord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
        public int MinutCount { get; set; }
        public User IdInitiator { get; set; }
        public DateTime Date { get; set; }
        public Guide Guide { get; set; }
        public DateTime EventDate { get; set; }
        public string Comment { get; set; }
    }
}
