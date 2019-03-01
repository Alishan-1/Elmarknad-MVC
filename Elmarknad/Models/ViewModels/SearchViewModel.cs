using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class SearchViewModel
    {
        [RegularExpression(@"^\d{3}\d{2}$", ErrorMessage = "Uppge ett riktigt postnummer")]
        [Required(ErrorMessage = "Ange ett giltigt postnummer")]
        public int Postnummer { get; set; }


        [Required(ErrorMessage = "Ange vilket typ av antal")]
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


        [Required(ErrorMessage = "Ange din förbrukning")]
        public int Förbrukning { get; set; }

        private Dictionary<int, string> _Förbrukning = new Dictionary<int, string>
        {
            {2000, "0 - 2000 Kwh/år" },
            {5000, "2000 - 5000 Kwh/år" },
            {20000, "5000 - 20 000 Kwh/år"},
        };

        public IEnumerable<SelectListItem> FörbrukningList
        {
            get { return new SelectList(_Förbrukning, "Key", "Value", "Välj förbrukning"); }
        }
        public bool Test1 { get; set; } = false;
        public bool Test2 { get; set; } = false;
    }
}