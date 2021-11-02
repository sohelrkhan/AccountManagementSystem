using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AMS.Models.ViewModels
{
    public class FeesViewModel
    {
             
        public Fees fees { get; set; }
        public StudentPayments studentPayments { get; set; }
       
    }
}
