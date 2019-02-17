using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class RemovedUserModel
    {
        [Key]
        public virtual int RemovedUserModelId { get; set; }
        public virtual string DateMoved { get; set; }
        public virtual string AdminName { get; set; }

        public virtual string SocialSecurity { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string Postnumber { get; set; }
        public virtual string City { get; set; }
        public virtual string AreaCode { get; set; }
        public virtual string PropertyCode { get; set; }
        [Column(TypeName = "datetime2")]
        public virtual DateTime StartDate { get; set; }
        [Column(TypeName = "datetime2")]
        public virtual DateTime DaySigned { get; set; }
        public virtual string IpAdress { get; set; }
        public virtual string Paymentmethod { get; set; }
        public virtual bool HasConfirmed { get; set; }
        public virtual bool LetUsGetInfo { get; set; }

        public virtual string Price { get; set; }
        public virtual string Company { get; set; }
        public virtual string Contract { get; set; }
        public virtual int Förbrukning { get; set; }
        public virtual string Typ { get; set; }
        public virtual string ExtraInfo { get; set; }
        public virtual bool IsClient { get; set; }
        public virtual string Elområde { get; set; }
    }
}