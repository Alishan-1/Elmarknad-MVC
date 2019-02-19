using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class ClientModel
    {
        [Key]
        public virtual int ClientId { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Contract { get; set; }
        public virtual int Förbrukning { get; set; }
        public virtual string Typ { get; set; }
        public virtual string ExtraInfo { get; set; }

        public virtual decimal? Rating { get; set; }
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

        public virtual int ElområdeId { get; set; }
        public virtual Elområde Elområde { get; set; }

        public virtual int ElBolagId { get; set; }
        public virtual ElBolag ElBolag { get; set; }

        public virtual bool Autogiro { get; set; } = false;
        public virtual bool EFaktura { get; set; } = false;
        public virtual bool Pappersfaktura { get; set; } = false;

        public virtual bool House { get; set; } = false;
        public virtual bool Appartment { get; set; } = false;

        public virtual bool Sol { get; set; } = false;
        public virtual bool Vind { get; set; } = false;
        public virtual bool Vatten { get; set; } = false;
        public virtual bool Bio { get; set; } = false;
        public virtual bool Miljömärkt { get; set; } = false;


    }
}