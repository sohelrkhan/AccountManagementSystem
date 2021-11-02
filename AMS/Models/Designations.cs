using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Designations
    {
        public Designations()
        {
            PayScales = new HashSet<PayScales>();
            Staffs = new HashSet<Staffs>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PayScales> PayScales { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
