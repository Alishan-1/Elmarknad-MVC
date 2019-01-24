using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class ListCustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialSecurity { get; set; }
        public string Address { get; set; }
        public string Postnumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

    }
}