using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Scholarships
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public int Percentage { get; set; }

        public virtual Students Student { get; set; }
    }
}
