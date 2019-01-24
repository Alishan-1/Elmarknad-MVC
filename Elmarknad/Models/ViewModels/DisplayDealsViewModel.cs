using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.ViewModels
{
    public class DisplayDealsViewModel
    {
        public List<ClientModel> Deals { get; set; }
    }
}