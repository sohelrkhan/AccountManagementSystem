using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Students
    {
        public Students()
        {
            Scholarships = new HashSet<Scholarships>();
            StudentPayments = new HashSet<StudentPayments>();
        }

        public long Id { get; set; }
        public long ClassId { get; set; }
        public long GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? AdmittedYear { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime? Dob { get; set; }

        public virtual Classes Class { get; set; }
        public virtual ComGenders Gender { get; set; }
        public virtual ICollection<Scholarships> Scholarships { get; set; }
        public virtual ICollection<StudentPayments> StudentPayments { get; set; }
    }
}
