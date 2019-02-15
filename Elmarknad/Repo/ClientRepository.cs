using Elmarknad.Models.UserAdminModels;
using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Elmarknad.Repo
{
    public class ClientRepository
    {
        private DbEl db = new DbEl();

        public bool SaveElBolag(ElBolagViewModel el) {
            var IsUnique = db.Companies.Any(i => i.Name == el.Name);
            if (!IsUnique) {
                var imgPath = SaveImage(el.Image);
                var bolag = new ElBolag {
                     Name = el.Name,
                     Phone = el.Phone,
                     Image = imgPath
                };
                db.Companies.Add(bolag);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public void EditImage(HttpPostedFileBase img, int id) {
            var bolag = db.Companies.Find(id);
            var imgPath = SaveImage(img);
            bolag.Image = imgPath;
            db.SaveChanges();
        }

        public string SaveImage(HttpPostedFileBase img) {
            if (img != null)
            {
                //för att göra sökvägen helt unik används GUID
                string pic = Guid.NewGuid().ToString() + "_" + Path.GetFileName(img.FileName);

                string imgPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), pic);
                img.SaveAs(imgPath);
                var clientImagePath = @"Images\" + pic;

                return clientImagePath;
                
            }
            return null;
           
        }
        public AllElBolagViewModel FillEditModel() {
            var model = new AllElBolagViewModel();
            model.ElBolag = db.Companies.ToList();
            return model;
        }
        public void DeleteCompany(int id) {
            var HasAgreements = db.ClientModels.Any(i => i.ElBolagId == id);
            if (!HasAgreements)
            {
                var company = db.Companies.Find(id);
                db.Companies.Remove(company);
                db.SaveChanges();
            }
            else {
                throw new Exception();
            }
        }
        public EditElbolagViewModel GetElbolag(int id) {
            var IsCompany = db.Companies.Any(i => i.ElBolagId == id);
            if (IsCompany)
            {
                var bolag = db.Companies.Find(id);
                var model = new EditElbolagViewModel
                {
                    ElBolagId = bolag.ElBolagId,
                    Name = bolag.Name,
                    Image = bolag.Image,
                    Phone = bolag.Phone
                };
                return model;
            }
            else {
                throw new Exception();
            }
        }
        public bool IsUnique(string name) => db.Companies.Any(i => i.Name == name);

        public void UpdateCompanyName(string name, int id) {
            var company = db.Companies.Find(id);
            company.Name = name;
            db.SaveChanges();
        }
        public void UpdateCompanyPhone(string Phone, int id)
        {
            var company = db.Companies.Find(id);
            company.Phone = Phone;
            db.SaveChanges();
        }
    }
}