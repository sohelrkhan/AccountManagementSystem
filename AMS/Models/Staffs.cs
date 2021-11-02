using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Staffs
    {
        public Staffs()
        {
            Bonus = new HashSet<Bonus>();
            ExtraIncomes = new HashSet<ExtraIncomes>();
            Salary = new HashSet<Salary>();
            SalaryIncrements = new HashSet<SalaryIncrements>();
        }

        public long Id { get; set; }
        public long DesignationId { get; set; }
        public long? ClassId { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual Classes Class { get; set; }
        public virtual Designations Designation { get; set; }
        public virtual ICollection<Bonus> Bonus { get; set; }
        public virtual ICollection<ExtraIncomes> ExtraIncomes { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
        public virtual ICollection<SalaryIncrements> SalaryIncrements { get; set; }
    }
}
