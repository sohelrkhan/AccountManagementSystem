using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Expenses
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
