using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class Customer
    {
        [Key]
        public virtual int CustomerId { get; set; }
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

        public virtual int? ClientId { get; set; }
        public virtual ClientModel ClientModel { get; set; }

        public virtual int? ScrapeId { get; set; }
        public virtual ScrapeModel ScrapeModel { get; set; }
    }
}