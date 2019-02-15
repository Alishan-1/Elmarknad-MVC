using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.UserAdminModels
{
    public class BlogModel
    {
        [Key]
        public virtual int BlogModelId { get; set; }
        public virtual string Header { get; set; }
        public virtual string Ingress { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual string HtmlContent { get; set; }

        [Column(TypeName = "datetime2")]
        public virtual DateTime Timestamp { get; set; }
    }
}