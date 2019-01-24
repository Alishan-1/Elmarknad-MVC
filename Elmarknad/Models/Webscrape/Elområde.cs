using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models
{
    public class Elområde
    {
        [Key]
        public virtual int ElområdeId { get; set; }
        public virtual string Area { get; set; }

        public virtual ICollection<Postnummer> Postnummers {get; set;}

        public Elområde() {
          
        }
    }
}