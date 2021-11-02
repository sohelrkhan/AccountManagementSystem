using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Donation
    {
        public long Id { get; set; }
        public string DonationFrom { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
