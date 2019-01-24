using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class AddCustomerAdminViewModel
    {
        [Required(ErrorMessage = "Du måste uppge personnummer")]
        [RegularExpression("^(19|20)?[0-9]{6}[- ]?[0-9]{4}$", ErrorMessage = "Du måste uppge personummer åååå-mm-dd-****")]
        [Display(Name = "Personnummer")]
        public virtual string SocialSecurity { get; set; }

        
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        [MaxLength(50, ErrorMessage ="Förnamn får inte vara längre än 50 tecken"), MinLength(2, ErrorMessage = "Förnamn får inte vara kortare än 2 tecken")]
        [Display(Name = "Förnamn")]
        public virtual string Firstname { get; set; }

        [Required(ErrorMessage = "Efternamn är obligatoriskt")]
        [MaxLength(50, ErrorMessage = "Efternamn får inte vara längre än 50 tecken"), MinLength(2, ErrorMessage = "Efternamn får inte vara kortare än 2 tecken")]
        [Display(Name = "Efternamn")]
        public virtual string Lastname { get; set; }

        [Required(ErrorMessage = "Du måste uppge anläggningsadressen")]
        [MaxLength(80, ErrorMessage = "Adress får inte vara längre än 80 tecken"), MinLength(10, ErrorMessage = "Adress får inte vara kortare än 10 tecken")]
        [Display(Name = "Anläggningsadress")]
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Du måste uppge ett riktigt postnummer")]
        [RegularExpression(@"^\d{3}\d{2}$", ErrorMessage = "Uppge ett riktigt postnummer")]
        [Display(Name = "Postnummer")]
        public virtual string Postnumber { get; set; }

        [Required(ErrorMessage = "Du måste uppge din ort")]
        [MaxLength(50, ErrorMessage = "Ort får inte vara längre än 50 tecken"), MinLength(2, ErrorMessage = "Ort får inte vara kortare än 2 tecken")]
        [Display(Name = "Ort")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "Du måste uppge din epost")]
        [EmailAddress(ErrorMessage = "Ange en giltig epost")]
        public virtual string Email { get; set; }

        [RegularExpression("^([A-Z a-z]{3})$", ErrorMessage = "Ej giltigt Områdes-ID")]
        [Display(Name = "Områdes-ID")]
        public virtual string AreaCode { get; set; }

        [RegularExpression("^([0-9]{18})$", ErrorMessage = "Måste vara 18 tecken")]
        [Display(Name = "Anläggnings-ID")]
        public virtual string PropertyCode { get; set; } 

        [DataType(DataType.Date, ErrorMessage = "Uppge det datum du vill påbörja ditt nya avtal")]
        [Display(Name = "Startdatum")]
        public virtual DateTime StartDate { get; set; } = DateTime.Now.Date;
        public virtual DateTime DaySigned { get; set; } = DateTime.Now;
        public virtual string IpAdress { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Du måste godkänna vilkoren")]
        [Display(Name = "Godkänn vilkoren")]
        public virtual bool HasConfirmed { get; set; } = false;

        [Display(Name = "Låt oss hämta dina uppgifter")]
        public virtual bool LetUsGetInfo { get; set; } = false;

        
        

        [Required]
        [Display(Name = "Lägg till ett avtal")]
        public virtual int? ClientId { get; set; }

        public List<ClientModel> Clients { get; set; }

        public IEnumerable<SelectListItem> ClientsList
        {
            get { return new SelectList(Clients, "ClientId", "Contract"); }

        }

     

        [Required(ErrorMessage = "Du måste välja vilken betalningsmetod")]
        [Display(Name = "Betalningsmetod")]
        public virtual string Paymentmethod { get; set; }
        private Dictionary<string, string> _Payment = new Dictionary<string, string>
        {
            {"Pappersfaktura", "Pappersfaktura"},
            {"Autogiro", "Autogiro"},
            {"E-Faktura", "E-Faktura" },
        };
        public IEnumerable<SelectListItem> PaymentList
        {
            get { return new SelectList(_Payment, "Key", "Value"); }
        }
    }
}