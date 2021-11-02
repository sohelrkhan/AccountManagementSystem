using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class PaymentTypes
    {
        public PaymentTypes()
        {
            StudentPayments = new HashSet<StudentPayments>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentPayments> StudentPayments { get; set; }
    }
}
