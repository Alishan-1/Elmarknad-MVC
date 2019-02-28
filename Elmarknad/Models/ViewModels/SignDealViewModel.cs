using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class SignDealViewModel
    {
        public AddCustomerAdminViewModel CustomerInfo { get; set; }

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
        public virtual string Image { get; set; }

        public virtual bool IsClient { get; set; }

        public virtual bool Sol { get; set; } = false;
        public virtual bool Vind { get; set; } = false;
        public virtual bool Vatten { get; set; } = false;
        public virtual bool Bio { get; set; } = false;
        public virtual bool Miljömärkt { get; set; } = false;
    }
}