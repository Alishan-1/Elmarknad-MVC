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

        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Kontrakt")]
        public virtual string Contract { get; set; }

        [Required]
        [Range(1, 20000)]
        [Display(Name = "Minimum Elförbrukning")]
        public virtual int MinFörbrukning { get; set; }

        [Required]
        [Range(1, 20000)]
        [Display(Name = "Max Elförbrukning")]
        public virtual int MaxFörbrukning { get; set; }

        [Required]
        public virtual bool Autogiro { get; set; } = false;
        [Required]
        [Display(Name = "E-Faktura")]
        public virtual bool EFaktura { get; set; } = false;
        [Required]
        [Display(Name = "Pappersfaktura")]
        public virtual bool Pappersfaktura { get; set; } = false;

        [Required]
        [Display(Name = "Hus")]
        public virtual bool House { get; set; }
        [Required]
        [Display(Name = "Lägenhet")]
        public virtual bool Appartment { get; set; }

        [Required]
        public virtual bool Sol { get; set; } = false;
        [Required]
        public virtual bool Vind { get; set; } = false;
        [Required]
        public virtual bool Vatten { get; set; } = false;
        [Required]
        public virtual bool Bio { get; set; } = false;
        [Required]
        public virtual bool Miljömärkt { get; set; } = false;


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

        [Display(Name = "Kopiera till alla elområden")]
        public bool HasAllAreas { get; set; }

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