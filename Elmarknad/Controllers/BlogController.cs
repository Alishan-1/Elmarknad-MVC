using Elmarknad.Models.ViewModels;
using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Controllers
{
    public class BlogController : Controller
    {
        private BlogRepository _Helper = new BlogRepository();

        // GET: Blog
        public ActionResult Index()
        {
            try
            {
                var model = _Helper.GetAllPosts();
                return View(model);
            }
            catch
            {
                var EmptyModel = new List<IndexBlogViewModel>();
                return View(EmptyModel);
            }
            
        }
        [HttpGet]
        public ActionResult ReadBlogPost(int id)
        {
            try
            {
                var model = _Helper.GetSinglePost(id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Error404", "Error");
            }
        }
    }
}