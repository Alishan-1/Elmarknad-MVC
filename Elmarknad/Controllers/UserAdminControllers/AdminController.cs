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
    public class AdminController : Controller
    {
        private ClientRepository Client = new ClientRepository();
        private DealRepository Deal = new DealRepository();
        private CustomerRepository Customer = new CustomerRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Scrape()
        {
            return View();
        }


        public ActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(ElBolagViewModel el)
        {
            if (ModelState.IsValid) {
                if (Client.SaveElBolag(el))
                {
                    return RedirectToAction("EditCompany");
                }
                else {
                    ModelState.AddModelError("", "Något har gått fel, är namnet unikt?");
                }
            }
            
            return View(el);
        }

        public ActionResult EditCompany() {
            var model = Client.FillEditModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult ManageCompany(int id) {
            try
            {
                var model = Client.GetElbolag(id);
                return View(model);
            }
            catch {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult ManageCompany(HttpPostedFileBase img, int ElBolagId)
        {
            try
            {
                if (img != null)
                {
                    Client.EditImage(img, ElBolagId);
                }
                var model = Client.GetElbolag(ElBolagId);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult EditCompanyName(string name, int ElBolagId)
        {
            var IsUnique = Client.IsUnique(name);
            var model = Client.GetElbolag(ElBolagId);
            if (IsUnique || name.Length < 2)
            {
                ModelState.AddModelError("Duplicate", "Namnet måste vara unikt och längre än två tecken");
                return View("ManageCompany", model);
            }
            else {
                Client.UpdateCompanyName(name, ElBolagId);
                return View("ManageCompany", model);
            }
            
        }
        [HttpPost]
        public ActionResult EditCompanyNumber(string Phone, int ElBolagId)
        {
            
            var model = Client.GetElbolag(ElBolagId);
            if (Phone.Length < 8)
            {
                ModelState.AddModelError("Number", "Nummer måste vara längre än åtta tecken");
                return View("ManageCompany", model);
            }
            else
            {
                Client.UpdateCompanyPhone(Phone, ElBolagId);
                return View("ManageCompany", model);
            }

        }

        public ActionResult AddDeal() {
            var model = Deal.FillDealModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDeal(AddDealViewModel model)
        {
            if (ModelState.IsValid) {
                Deal.SaveDeal(model);
                return RedirectToAction("DisplayDeals");
            }
            var failmodel = Deal.FillDealModel();
            return View(failmodel);
        }
        public ActionResult DisplayDeals() {
            var model = Deal.FillAllDealsModel();
            return View(model);
        }

        public ActionResult AddCustomer()
        {
            var model = Customer.GetAdminModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCustomer(AddCustomerAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.IpAdress = Request.UserHostAddress;
                Customer.SaveCustomerAdminModel(model);
                return RedirectToAction("ListCustomers");
            }

            var failmodel = Customer.GetAdminModel();
            return View(failmodel);
        }

        public ActionResult ListCustomers()
        {
            var model = Customer.GetCustomers();
            return View(model);
        }
        public ActionResult TodaysDeals()
        {
            var model = Customer.GetTodaysCustomers();
            return View("ListCustomers", model);
        }

        public ActionResult WritePost()
        {
            var model = new AddBlogPostViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WritePost(AddBlogPostViewModel model)
        {
            var helper = new BlogRepository();
            if (ModelState.IsValid)
            {
                helper.SavePost(model);
                return RedirectToAction("Index", "Blog");
            }
            return View(model);
        }
        public ActionResult ListBlogPosts()
        {
            var helper = new BlogRepository();
            var model = helper.GetAllPosts();
            return View(model);
        }
        public ActionResult EditBlogPost(int id)
        {
            var helper = new BlogRepository();
            var obj = helper.GetSinglePost(id);
            var model = new AddBlogPostViewModel
            {
                BlogModelId = obj.BlogModelId,
                Header = obj.Header,
                HtmlContent = obj.HtmlContent,
                Ingress = obj.Ingress,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlogPost(AddBlogPostViewModel model)
        {
            var helper = new BlogRepository();
            if (ModelState.IsValid)
            {
                helper.UpdatePost(model);
                return RedirectToAction("Index", "Blog");
            }
            return View(model);
        }

      
    }
}