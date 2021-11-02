using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class ComGenders
    {
        public ComGenders()
        {
            Students = new HashSet<Students>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
