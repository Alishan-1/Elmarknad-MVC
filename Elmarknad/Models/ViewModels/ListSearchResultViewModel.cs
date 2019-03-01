using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class ListSearchResultViewModel
    {
        public List<SearchResultViewModel> Agreements { get; set; }
        
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

        public int Förbrukning { get; set; }
        private Dictionary<int, string> _Förbrukning = new Dictionary<int, string>
        {
            {2000, "0 - 2000 Kwh/år" },
            {5000, "2000 - 5000 Kwh/år" },
            {20000, "5000 - 20 000 Kwh/år"},
        };
        public IEnumerable<SelectListItem> FörbrukningList
        {
            get { return new SelectList(_Förbrukning, "Key", "Value"); }
        }

       
        public string Postnummer { get; set; }
        public int ElId { get; set; }

        
    }
}