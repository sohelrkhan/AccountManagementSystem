using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Fees
    {
        public Fees()
        {
            StudentPayments = new HashSet<StudentPayments>();
        }

        public long Id { get; set; }
        public long ClassId { get; set; }
        public long FeesTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Classes Class { get; set; }
        public virtual FeesTypes FeesType { get; set; }
        public virtual ICollection<StudentPayments> StudentPayments { get; set; }
    }
}
