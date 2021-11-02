using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class StudentPromotions
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public int RollNo { get; set; }
        public DateTime Year { get; set; }

        public virtual Classes Class { get; set; }
    }
}
