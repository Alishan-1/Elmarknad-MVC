using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Repo
{
    public class CustomerRepository
    {
        public DbEl db = new DbEl();

        public AddCustomerAdminViewModel GetAdminModel() {
            AddCustomerAdminViewModel model;
            if (db.ClientModels.Any())
            {
                model = new AddCustomerAdminViewModel
                {
                    Clients = db.ClientModels.ToList()
                };
            }
            else {
                model = new AddCustomerAdminViewModel
                {
                    Clients = new List<ClientModel>()
                };
            }
            
            return model;
        }

        public void SaveCustomerAdminModel(AddCustomerAdminViewModel model) {
            try
            {
                if (model.ClientId != null)
                {
                    SaveClients(model);
                }
                else
                {
                    SaveScraped(model);
                }
            }
            catch {
                throw new Exception();
            }
        }
        private void SaveClients(AddCustomerAdminViewModel model) {
            if (model.LetUsGetInfo)
            {
                var customer = new Customer
                {
                    Address = model.Address,
                    City = model.City,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    IpAdress = model.IpAdress,
                    Lastname = model.Lastname,
                    SocialSecurity = model.SocialSecurity,
                    HasConfirmed = model.HasConfirmed,
                    Paymentmethod = model.Paymentmethod,
                    Postnumber = model.Postnumber,
                    ClientId = model.ClientId,
                    LetUsGetInfo = model.LetUsGetInfo,
                    DaySigned = DateTime.Now,
                    PaymentAddress = model.FakturaAddress != null ? model.FakturaAddress : model.Address,
                    PaymentCity = model.FakturaCity != null ? model.FakturaCity : model.City,
                    PaymentPostnumber = model.FakturaPostnumber != null ? model.FakturaPostnumber : model.Postnumber
                };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            else
            {
                var customer = new Customer
                {
                    Address = model.Address,
                    City = model.City,
                    DaySigned = DateTime.Now,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    IpAdress = model.IpAdress,
                    Lastname = model.Lastname,
                    SocialSecurity = model.SocialSecurity,
                    HasConfirmed = model.HasConfirmed,
                    Paymentmethod = model.Paymentmethod,
                    Postnumber = model.Postnumber,
                    ClientId = model.ClientId,
                    LetUsGetInfo = model.LetUsGetInfo,
                    AreaCode = model.AreaCode,
                    StartDate = model.StartDate,
                    PropertyCode = model.PropertyCode,
                    PaymentAddress = model.FakturaAddress != null ? model.FakturaAddress : model.Address,
                    PaymentCity = model.FakturaCity != null ? model.FakturaCity : model.City,
                    PaymentPostnumber = model.FakturaPostnumber != null ? model.FakturaPostnumber : model.Postnumber
                };

                db.Customers.Add(customer);
                db.SaveChanges();

            }
        }

        private void SaveScraped(AddCustomerAdminViewModel model)
        {
            if (model.LetUsGetInfo)
            {
                var customer = new Customer
                {
                    Address = model.Address,
                    City = model.City,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    IpAdress = model.IpAdress,
                    Lastname = model.Lastname,
                    SocialSecurity = model.SocialSecurity,
                    HasConfirmed = model.HasConfirmed,
                    Paymentmethod = model.Paymentmethod,
                    Postnumber = model.Postnumber,
                    ScrapeId = model.ScrapeId,
                    LetUsGetInfo = model.LetUsGetInfo,
                    DaySigned = DateTime.Now,
                    PaymentAddress = model.FakturaAddress != null ? model.FakturaAddress : model.Address,
                    PaymentCity = model.FakturaCity != null ? model.FakturaCity : model.City,
                    PaymentPostnumber = model.FakturaPostnumber != null ? model.FakturaPostnumber : model.Postnumber
                };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            else
            {
                var customer = new Customer
                {
                    Address = model.Address,
                    City = model.City,
                    DaySigned = DateTime.Now,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    IpAdress = model.IpAdress,
                    Lastname = model.Lastname,
                    SocialSecurity = model.SocialSecurity,
                    HasConfirmed = model.HasConfirmed,
                    Paymentmethod = model.Paymentmethod,
                    Postnumber = model.Postnumber,
                    ScrapeId = model.ScrapeId,
                    LetUsGetInfo = model.LetUsGetInfo,
                    AreaCode = model.AreaCode,
                    StartDate = model.StartDate,
                    PropertyCode = model.PropertyCode,
                    PaymentAddress = model.FakturaAddress != null ? model.FakturaAddress : model.Address,
                    PaymentCity = model.FakturaCity != null ? model.FakturaCity : model.City,
                    PaymentPostnumber = model.FakturaPostnumber != null ? model.FakturaPostnumber : model.Postnumber
                };

                db.Customers.Add(customer);
                db.SaveChanges();

            }
        }



        public List<ListCustomerViewModel> GetCustomers() {
            var _db = new DbEl();
            var customers = _db.Customers.OrderByDescending(i => i.DaySigned).ToList();
            var list = new List<ListCustomerViewModel>();
            foreach (var item in customers) {
                var model = new ListCustomerViewModel {
                    SocialSecurity = item.SocialSecurity,
                    CustomerId = item.CustomerId,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Address = item.Address,
                    City = item.City,
                    Email = item.Email,
                    Postnumber = item.Postnumber,
                    ClientDeal = item.ClientModel != null ? item.ClientModel : null,
                    ScrapeDeal = item.ScrapeModel != null ? item.ScrapeModel : null,
                    Timestamp = item.DaySigned.ToString(),
                    AreaCode = item.AreaCode != null ? item.AreaCode : null,
                    HasConfirmed = item.HasConfirmed,
                    IpAdress = item.IpAdress,
                    LetUsGetInfo = item.LetUsGetInfo,
                    Paymentmethod = item.Paymentmethod,
                    PropertyCode = item.PropertyCode != null ? item.PropertyCode : null,
                    StartDate = item.StartDate

                };
                list.Add(model);
            }
            return list;
        }

        public List<ListCustomerViewModel> GetTodaysCustomers()
        {
            var today = DateTime.Now.Date;
            var customers = db.Customers.ToList();

            var filteredCustomer = customers.Where(i => i.DaySigned.Date == today);

            var list = new List<ListCustomerViewModel>();
            foreach (var item in filteredCustomer)
            {
                var model = new ListCustomerViewModel
                {
                    SocialSecurity = item.SocialSecurity,
                    CustomerId = item.CustomerId,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Address = item.Address,
                    City = item.City,
                    Email = item.Email,
                    Postnumber = item.Postnumber,
                    ClientDeal = item.ClientModel != null ? item.ClientModel : null,
                    ScrapeDeal = item.ScrapeModel != null ? item.ScrapeModel : null,
                    Timestamp = item.DaySigned.ToString(),
                    AreaCode = item.AreaCode != null ? item.AreaCode : null,
                    HasConfirmed = item.HasConfirmed,
                    IpAdress = item.IpAdress,
                    LetUsGetInfo = item.LetUsGetInfo,
                    Paymentmethod = item.Paymentmethod,
                    PropertyCode = item.PropertyCode != null ? item.PropertyCode : null,
                    StartDate = item.StartDate
                };
                list.Add(model);
            }
            return list;
        }

        public void DeleteUser(int userId) {
            var cust = db.Customers.Find(userId);
            if (this.MoveCustomer(cust)) {
                db.Customers.Remove(cust);
                db.SaveChanges();
                return;
            }
            throw new Exception();
        }

        private bool MoveCustomer(Customer c)
        {
            var httpContext = HttpContext.Current;
            var db = new DbEl();
            if (c.ScrapeId != null)
            {
                var deleted = new RemovedUserModel
                {
                    Address = c.Address,
                    AdminName = httpContext.User.Identity.Name,
                    AreaCode = c.AreaCode,
                    City = c.City,
                    Company = c.ScrapeModel.Company,
                    Contract = c.ScrapeModel.Contract,
                    DateMoved = DateTime.Now.ToString(),
                    DaySigned = c.DaySigned,
                    Email = c.Email,
                    ExtraInfo = c.ScrapeModel.ExtraInfo,
                    Firstname = c.Firstname,
                    Förbrukning = c.ScrapeModel.Förbrukning,
                    HasConfirmed = c.HasConfirmed,
                    IpAdress = c.IpAdress,
                    Lastname = c.Lastname,
                    LetUsGetInfo = c.LetUsGetInfo,
                    Paymentmethod = c.Paymentmethod,
                    Postnumber = c.Postnumber,
                    Price = c.ScrapeModel.Price,
                    PropertyCode = c.PropertyCode,
                    SocialSecurity = c.SocialSecurity,
                    StartDate = c.StartDate,
                    Typ = c.ScrapeModel.Typ,
                    IsClient = false,
                    Elområde = c.ScrapeModel.Elområde.Area
                };
                db.DeletedCustomer.Add(deleted);
                db.SaveChanges();
                return true;
            } else if(c.ClientId != null)
            {
                var deleted = new RemovedUserModel
                {
                    Address = c.Address,
                    AdminName = httpContext.User.Identity.Name,
                    AreaCode = c.AreaCode,
                    City = c.City,
                    Company = c.ClientModel.ElBolag.Name,
                    Contract = c.ClientModel.Contract,
                    DateMoved = DateTime.Now.ToString(),
                    DaySigned = c.DaySigned,
                    Email = c.Email,
                    ExtraInfo = c.ClientModel.ExtraInfo,
                    Firstname = c.Firstname,
                    Förbrukning = c.ClientModel.Förbrukning,
                    HasConfirmed = c.HasConfirmed,
                    IpAdress = c.IpAdress,
                    Lastname = c.Lastname,
                    LetUsGetInfo = c.LetUsGetInfo,
                    Paymentmethod = c.Paymentmethod,
                    Postnumber = c.Postnumber,
                    Price = c.ClientModel.Price.ToString(),
                    PropertyCode = c.PropertyCode,
                    SocialSecurity = c.SocialSecurity,
                    StartDate = c.StartDate,
                    Typ = c.ClientModel.Typ,
                    IsClient = true,
                    Elområde = c.ClientModel.Elområde.Area
                };
                db.DeletedCustomer.Add(deleted);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<RemovedUserModel> GetDeletedUsers()
        {
            var db = new DbEl();
            return db.DeletedCustomer.OrderByDescending(i => i.DaySigned).ToList();
        }

    }
}