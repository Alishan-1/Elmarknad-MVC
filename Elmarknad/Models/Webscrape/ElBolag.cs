using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class ElBolag
    {
        [Key]
        public virtual int ElBolagId { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Phone { get; set; }

        public virtual ICollection<ClientModel> ElAvtal { get; set; }
    }
}