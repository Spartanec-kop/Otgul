﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Otgul.Models
{
    public class Otdel
    {
        public int Id { get; set; }
        public int CodOtdela { get; set; }
        public string NameOtdela { get; set; }
        public string Director { get; set; }

    }
}
