using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Classes
    {
        public Classes()
        {
            Fees = new HashSet<Fees>();
            Staffs = new HashSet<Staffs>();
            Students = new HashSet<Students>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fees> Fees { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
