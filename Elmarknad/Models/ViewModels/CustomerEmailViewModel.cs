using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class CustomerEmailViewModel
    {
        [Required(ErrorMessage = "Du måste ange ett ämne")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Du måste ange ett ämne")]
        [MaxLength(400, ErrorMessage = "Meddelandet får inte vara längre än 400 tecken"), MinLength(10, ErrorMessage = "Meddelandet får inte vara kortare än 10 tecken")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Du måste ange ditt namn")]
        public string Sender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}