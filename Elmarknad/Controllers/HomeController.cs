using Elmarknad.Models.ViewModels;
using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private SearchResultRepository _searchRepo = new SearchResultRepository();

        public ActionResult Index()
        {
            var model = new SearchViewModel();
           
            return View(model);
        }
        #region ShowResult
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
                        Förbrukning = model.Förbrukning,
                        Typ = model.Typ,
                        Clients = new List<SearchResultViewModel>(),
                        Scraped = new List<SearchResultViewModel>()
                    };
                    return View(m);

                }
                
            }

            return View("Index", model);
        }
        #endregion

        #region SignAgreement

        private EmailRepository _email = new EmailRepository();

        public ActionResult TecknaAvtal(int id)
        {
            try
            {
                var helper = new CustomerDealRepository();
                var model = helper.GetScrapedModel(id);
                return View("SignScrapeDeal", model);
            }
            catch {
                return RedirectToAction("Error", "Shared");
            }
        }

        
        public ActionResult TecknaKampanjAvtal(int id)
        {
            try
            {
                var helper = new CustomerDealRepository();
                var model = helper.GetClientModel(id);
                return View("SignClientDeal", model);
            }
            catch
            {
                return RedirectToAction("Error", "Shared");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TecknaAvtal(SignDealViewModel m) {
            if (!m.CustomerInfo.LetUsGetInfo) {
                if (String.IsNullOrEmpty(m.CustomerInfo.PropertyCode)) {
                    ModelState.AddModelError("", "Du måste ange ett AnläggningsID");
                }
                if (String.IsNullOrEmpty(m.CustomerInfo.AreaCode))
                {
                    ModelState.AddModelError("", "Du måste ange ett områdesID");
                }
                if (String.IsNullOrEmpty(m.CustomerInfo.StartDate.ToLongDateString()) || m.CustomerInfo.StartDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("", "Du måste ange ett datum som inte är tidigare än dagens datum");
                }
            }
            var Customer = new CustomerRepository();
            if (ModelState.IsValid)
            {
                var model = new AddCustomerAdminViewModel();
                model = m.CustomerInfo;
                model.IpAdress = Request.UserHostAddress;
                model.ScrapeId = m.ScrapeId;
                Customer.SaveCustomerAdminModel(model);
                _email.SendEmailAsync(m);
                return RedirectToAction("Thanks");
            }
            var helper = new CustomerDealRepository();
            var failmodel = helper.GetScrapedModel(m.ScrapeId);
            return View("SignScrapeDeal", failmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TecknaKampanjAvtal(SignDealViewModel m)
        {
            if (!m.CustomerInfo.LetUsGetInfo)
            {
                if (String.IsNullOrEmpty(m.CustomerInfo.PropertyCode))
                {
                    ModelState.AddModelError("", "Du måste ange ett AnläggningsID");
                }
                if (String.IsNullOrEmpty(m.CustomerInfo.AreaCode))
                {
                    ModelState.AddModelError("", "Du måste ange ett områdesID");
                }
                if (String.IsNullOrEmpty(m.CustomerInfo.StartDate.ToLongDateString()) || m.CustomerInfo.StartDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("", "Du måste ange ett datum som inte är tidigare än dagens datum");
                }
            }
            var Customer = new CustomerRepository();
            if (ModelState.IsValid)
            {
                var model = new AddCustomerAdminViewModel();
                model = m.CustomerInfo;
                model.IpAdress = Request.UserHostAddress;
                model.ClientId = m.ScrapeId;
                
                Customer.SaveCustomerAdminModel(model);
                _email.SendEmailAsync(m);
                return RedirectToAction("Thanks");
            }
            var helper = new CustomerDealRepository();
            var failmodel = helper.GetClientModel(m.ScrapeId);
            return View("SignClientDeal", failmodel);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.successMessage = "";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(CustomerEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var helper = new EmailRepository();
                helper.CustomerSupportEmail(model);
                ViewBag.successMessage = "Ditt meddelande har skickats och kommer hanteras så fort som möjligt!";
                
                return View();
            }

            return View(model);
        }
        public ActionResult Thanks()
        {
            return View();
        }
       
        public ActionResult MoreInfo()
        {
           
            return View();
        }
        #endregion

        public ActionResult About()
        {
            return View();
        }
    }

}