using Elmarknad.Models.ViewModels;
using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Controllers
{
    [Authorize(Users = "samuel@elmarknad.se")]
    public class HomeController : Controller
    {
        private SearchResultRepository _searchRepo = new SearchResultRepository();

        public ActionResult Index()
        {
            var model = new SearchViewModel();
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Search(SearchViewModel model)
        {

            if (ModelState.IsValid) {
                try
                {
                    var searchmodel = _searchRepo.FillSearchResultModel(model);
                    return View(searchmodel);
                }
                catch {
                    var m = new ListSearchResultViewModel
                    {
                        Förbrukning = model.Förbrukning.ToString(),
                        Typ = model.Typ,
                        Clients = new List<SearchResultViewModel>(),
                        Scraped = new List<SearchResultViewModel>()
                    };
                    return View(m);

                }
                
            }

            return View("Index", model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}