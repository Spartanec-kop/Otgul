using Otgul.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Otgul.Models
{
    public class ViewOtgulRecord
    {
        public Int64 Id { get; set; }
        public ViewUser User { get; set; }
        public ViewUser Initiator { get; set; }
        public bool Action { get; set; }
        public int MinutCount { get; set; }
        public DateTime Date { get; set; }
        public Guide Guide { get; set; }
        public DateTime EventDate { get; set; }
        public string Comment { get; set; }
    }
}
