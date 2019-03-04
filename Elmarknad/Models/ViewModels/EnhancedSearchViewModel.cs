using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class EnhancedSearchViewModel
    {
        
        public int Postnummer { get; set; }

        public int ElområdeId { get; set; }
        //Type
        [Required(ErrorMessage = "Ange vilket typ av antal")]
        [Display(Name = "Avtalstyp")]
        public string Typ { get; set; }

        private Dictionary<string, string> _Typ = new Dictionary<string, string>
        {
            {"Rörligt", "Rörligt"},
            {"Fast", "Fast"},
            {"Mix", "Mix"},
        };

        public IEnumerable<SelectListItem> TypList
        {
            get { return new SelectList(_Typ, "Key", "Value"); }
        }

        //---slut---//
        //---Förbrukning---//
        [Required(ErrorMessage = "Ange din förbrukning")]
        [Range(1,30000, ErrorMessage = "Ange din elförbrukning mellan 1 - 30000 kwh/år.")]
        public int Förbrukning { get; set; }


        //slut//
        
        [Display(Name = "Välj betalningsmetod")]
        public string PaymentMethod { get; set; }
        private Dictionary<string, string> _Payment = new Dictionary<string, string>
        {
            {"A", "Autogiro"},
            {"E", "E-Faktura"},
            {"P", "Pappersfaktura"},
        };
        public IEnumerable<SelectListItem> PaymentList
        {
            get { return new SelectList(_Payment, "Key", "Value"); }
        }
        //---//
        [Display(Name = "Välj bostad")]
        public string Property { get; set; }
        private Dictionary<string, string> _Property = new Dictionary<string, string>
        {
            {"house", "Villa"},
            {"cabin", "Lägenhet / Sommarstuga"}
        };
        public IEnumerable<SelectListItem> PropertyList
        {
            get { return new SelectList(_Property, "Key", "Value"); }
        }

        //--slut--//
        //--//
        [Display(Name = "Vill du ha ett miljöavtal?")]
        public string Source { get; set; }
        private Dictionary<string, string> _Source = new Dictionary<string, string>
        {
            {"yes", "Ja"},
            {"no", "Nej"}
        };
        public IEnumerable<SelectListItem> SourceList
        {
            get { return new SelectList(_Source, "Key", "Value"); }
        }
        //---//
     
        

    }
}