using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class AddBlogPostViewModel
    {
        public int BlogModelId { get; set; }

        [Required(ErrorMessage = "Du måste välje en rubrik")]
        [Display(Name = "Rubrik")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Du måste skriva en ingress")]
        [MinLength(20, ErrorMessage = "Minsta längden är 20 tecken")]
        [Display(Name = "Ingress")]
        public string Ingress { get; set; }

        [Display(Name = "Bild")]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Minsta längden är 20 tecken")]
        [Display(Name = "Formatera som HTML")]
        public string HtmlContent { get; set; }
        
    }
    public class IndexBlogViewModel
    {
        public int BlogModelId { get; set; }
        public string Header { get; set; }
        public string Ingress { get; set; }
        public string ImagePath { get; set; }
        public string Timestamp { get; set; }
    }
    public class DisplayBlogPostViewModel
    {
        public int BlogModelId { get; set; }
        public string Header { get; set; }
        public string Ingress { get; set; }
        public string ImagePath { get; set; }
        public string HtmlContent { get; set; }
        public string Timestamp { get; set; }
    }
}