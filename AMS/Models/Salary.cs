using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Salary
    {
        public long Id { get; set; }
        public long StaffId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }

        public virtual Staffs Staff { get; set; }
    }
}
