using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class ScrapeModel
    {
        [Key]
        public virtual int ScrapeId { get; set; }
        public virtual string Price { get; set; }
        public virtual string Company { get; set; }
        public virtual string Contract { get; set; }
        public virtual int Förbrukning { get; set; }
        public virtual string Typ { get; set; }
        public virtual string ExtraInfo { get; set; }
        public virtual decimal? Rating { get; set; }
        public virtual string ÅrsAvgift { get; set; }
        public virtual string Engångsavgift { get; set; }
        public virtual string Fastpris { get; set; }
        public virtual string RörligtInköpsPris { get; set; }
        public virtual string RörligtPåslag { get; set; }
        public virtual string Miljöpåslag { get; set; }
        public virtual string RörligtMiljöpåslag { get; set; }
        public virtual string Rabatt { get; set; }
        public virtual string Moms { get; set; }
        public virtual string Uppsägningstid { get; set; }
        public virtual string Automatiskförlängning { get; set; }
        public virtual string Omteckningsrätt { get; set; }
        public virtual int ElområdeId { get; set; }
        public virtual Elområde Elområde { get; set; }

        public virtual bool Autogiro { get; set; } = false;
        public virtual bool EFaktura { get; set; } = false;
        public virtual bool Pappersfaktura { get; set; } = false;

        public virtual bool House { get; set; } = true;
        public virtual bool Appartment { get; set; } = true;

        public virtual bool Sol { get; set; } = false;
        public virtual bool Vind { get; set; } = false;
        public virtual bool Vatten { get; set; } = false;
        public virtual bool Bio { get; set; } = false;
        public virtual bool Miljömärkt { get; set; } = false;

    }
}