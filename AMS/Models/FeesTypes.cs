using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class FeesTypes
    {
        public FeesTypes()
        {
            Fees = new HashSet<Fees>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }

        public virtual ICollection<Fees> Fees { get; set; }
    }
}
