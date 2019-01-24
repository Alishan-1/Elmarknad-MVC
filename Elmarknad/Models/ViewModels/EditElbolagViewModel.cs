using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class EditElbolagViewModel
    {
        
        public int ElBolagId { get; set; }
        [Display(Name = "Ändra Namn")]
        public virtual string Name { get; set; }
        [Display(Name = "Logo (400x400 px)")]
        public string Image { get; set; }
        [Display(Name = "Ändra Telefonnummer")]
        public virtual string Phone { get; set; }
    }
}