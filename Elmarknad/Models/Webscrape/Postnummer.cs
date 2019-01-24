using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elmarknad.Models
{
    public class Postnummer
    {
        [Key]
        public int PostnummerId { get; set; }
        public int Number { get; set; }
        public int ElområdeId { get; set; }
    }
}