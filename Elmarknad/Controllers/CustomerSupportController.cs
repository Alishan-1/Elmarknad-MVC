using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Controllers
{
    public class CustomerSupportController : Controller
    {
        // GET: CustomerSupport
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult Dictionary()
        {
            return View();
        }
    }
}