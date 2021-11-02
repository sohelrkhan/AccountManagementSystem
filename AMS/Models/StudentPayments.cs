using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class StudentPayments
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public long StudentId { get; set; }
        public long FeeId { get; set; }
        public long PaymentTypeId { get; set; }
        public decimal? Fine { get; set; }
        public decimal? Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Remarks { get; set; }

        public virtual Fees Fee { get; set; }
        public virtual PaymentTypes PaymentType { get; set; }
        public virtual Students Student { get; set; }
    }
}
