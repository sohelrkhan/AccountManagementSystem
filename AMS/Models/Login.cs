using System;
using System.Collections.Generic;

namespace AMS.Models
{
    public partial class Login
    {
        public long UserId { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
