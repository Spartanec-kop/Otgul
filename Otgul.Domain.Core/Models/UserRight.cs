using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Models
{
    public class UserRight
    {
        public int UserId { get; set; }
        public int RightId { get; set; }
        public User User { get; set; }
        public Right Right { get; set; }
    }
}
