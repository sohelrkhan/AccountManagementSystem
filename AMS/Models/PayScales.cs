using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class PayScales
    {
        public long Id { get; set; }
        public long DesignationId { get; set; }
        public decimal Amount { get; set; }

        public virtual Designations Designation { get; set; }
    }
}
