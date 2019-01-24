using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class AddDealViewModel
    {

        [Required]
        [Display(Name = "Pris")]
        public virtual decimal Price { get; set; }

        [Required]
        [Display(Name = "Kontrakt")]
        public virtual string Contract { get; set; }

        [Required]
        [Display(Name = "Elförbrukning")]
        public virtual int Förbrukning { get; set; }
        private Dictionary<int, int> _Förbrukning = new Dictionary<int, int>
        {
            {2000, 2000 },
            {5000, 5000 },
            {20000, 20000 },
        };

        public IEnumerable<SelectListItem> FörbrukningList
        {
            get { return new SelectList(_Förbrukning, "Key", "Value", "Välj förbrukning"); }
        }

        [Required]
        [Display(Name = "Typ av avtal")]
        public virtual string Typ { get; set; }
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

        [Required]
        [Display(Name = "Extra information")]
        public virtual string ExtraInfo { get; set; }

        [Display(Name = "Kundbetyg")]
        public virtual decimal Rating { get; set; }

        [Display(Name = "Årlig avgift")]
        public virtual decimal ÅrsAvgift { get; set; }

        
        public virtual decimal Engångsavgift { get; set; }
        public virtual decimal Fastpris { get; set; }
        public virtual decimal RörligtInköpsPris { get; set; }
        public virtual decimal RörligtPåslag { get; set; }
        public virtual decimal Miljöpåslag { get; set; }
        public virtual decimal RörligtMiljöpåslag { get; set; }
        public virtual decimal Rabatt { get; set; }
        public virtual decimal Moms { get; set; }
        public virtual string Uppsägningstid { get; set; }
        public virtual string Automatiskförlängning { get; set; }
        public virtual string Omteckningsrätt { get; set; }

        [Required]
        [Display(Name = "Elområde")]
        public virtual int ElområdeId { get; set; }
        public List<Elområde> Elområde { get; set; }

        public IEnumerable<SelectListItem> ElområdeList
        {
            get { return new SelectList(Elområde, "ElområdeId", "Area"); }
        
        }

        [Required]
        [Display(Name = "Elbolag")]
        public virtual int ElBolagId { get; set; }

        public List<ElBolag> ElBolag { get; set; }

        public IEnumerable<SelectListItem> ElbolagList
        {
            get { return new SelectList(ElBolag, "ElBolagId", "Name"); }
           
        }
    }
}