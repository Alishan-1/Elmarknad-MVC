using Elmarknad.Models.UserAdminModels;
using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Elmarknad.Repo
{
    public class BlogRepository
    {
        private ClientRepository _ImageHelper = new ClientRepository();

        public void SavePost(AddBlogPostViewModel model)
        {
            var db = new DbEl();
            var post = new BlogModel
            {
                Header = model.Header,
                HtmlContent = model.HtmlContent,
                ImagePath = _ImageHelper.SaveImage(model.Image),
                Ingress = model.Ingress,
                Timestamp = DateTime.Now
            };
            db.BlogPosts.Add(post);
            db.SaveChanges();

        }
        public void UpdatePost(AddBlogPostViewModel model)
        {
            var db = new DbEl();
            var post = db.BlogPosts.Find(model.BlogModelId);
            post.Header = model.Header;
            post.HtmlContent = model.HtmlContent;
            post.Ingress = model.Ingress;
            post.Timestamp = DateTime.Now;

            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void RemovePost(int id)
        {
            var db = new DbEl();
            var post = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(post);
            db.SaveChanges();
        }
        public DisplayBlogPostViewModel GetSinglePost(int id)
        {
            var db = new DbEl();
            if (db.BlogPosts.Any(i => i.BlogModelId == id)) { 
            var post = db.BlogPosts.Find(id);
            var model = new DisplayBlogPostViewModel
            {
                Header = post.Header,
                HtmlContent = post.HtmlContent,
                Ingress = post.Ingress,
                ImagePath = post.ImagePath,
                Timestamp = post.Timestamp.ToString(),
                BlogModelId = post.BlogModelId
            };
            return model;
            }
            else
            {
                throw new Exception();
            }
        }
        public List<IndexBlogViewModel> GetAllPosts()
        {
            try { 
            var db = new DbEl();
            var posts = db.BlogPosts.OrderByDescending(i => i.Timestamp).ToList();
            var list = new List<IndexBlogViewModel>();
            foreach(var item in posts)
            {
                var post = new IndexBlogViewModel
                {
                    BlogModelId = item.BlogModelId,
                    Timestamp = item.Timestamp.ToString(),
                    Header = item.Header,
                    ImagePath = item.ImagePath,
                    Ingress = item.Ingress
                };
                list.Add(post);
            }
            return list;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


    }
}