using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Otgul.Models
{
    public class OtgulRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }
        public string Action { get; set; }
        public int MinutCount { get; set; }
        public int InitiatorId { get; set; }
        [ForeignKey("initiatorId")]
        public User Initiator { get; set; }
        public DateTime Date { get; set; }
        public int GuideId { get; set; }
        [ForeignKey("guideId")]
        public Guide Guide { get; set; }
        public DateTime EventDate { get; set; }
        public string Comment { get; set; }
    }
}
