using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Company { get; set; }
        public string Contract { get; set; }
        public decimal Rating { get; set; }
        public int Avtalstid { get; set; } = 12;
        public string ExtraInfo { get; set; }
        public string Uppsägningstid { get; set; }
        public string Image { get; set; }
        public bool IsClient { get; set; }
        public string AutomatiskFörlängning { get; set; }
        public string Omteckningsrätt { get; set; }

    }
}