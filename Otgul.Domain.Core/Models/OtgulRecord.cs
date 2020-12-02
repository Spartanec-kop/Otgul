using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class OtgulRecord
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string action { get; set; }
        public int minutCount { get; set; }
        public int idInitiator { get; set; }
        public DateTime data { get; set; }
        public int idGuide { get; set; }
        public DateTime eventData { get; set; }
        public string comment { get; set; }
    }
}
