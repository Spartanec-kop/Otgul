﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Otgul.Models
{
    public class OtgulRecord
    {
        public Int64 Id { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }
        public bool Action { get; set; }
        public int MinutCount { get; set; }
        [ForeignKey("initiatorId")]
        public User Initiator { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("guideId")]
        public Guide Guide { get; set; }
        public DateTime EventDate { get; set; }
        public string Comment { get; set; }
    }
}
