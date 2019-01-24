using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class ElBolagViewModel
    {
       
        [Required]
        [Display(Name = "Namn")]
        public virtual string Name { get; set; }
        [Display(Name = "Logo (400x400 px)")]
        public HttpPostedFileBase Image { get; set; }
        [Display(Name = "Telefonnummer")]
        public virtual string Phone { get; set; }
    }
}