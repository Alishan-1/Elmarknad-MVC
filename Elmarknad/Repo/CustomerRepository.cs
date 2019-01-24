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
                    DaySigned = DateTime.Now
                };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            else {
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
                    PropertyCode = model.PropertyCode
                };
              
                db.Customers.Add(customer);
                db.SaveChanges();

            }


        }
        

        public List<ListCustomerViewModel> GetCustomers() {
            var customers = db.Customers.ToList();
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
                    Postnumber = item.Postnumber
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
                    Postnumber = item.Postnumber
                };
                list.Add(model);
            }
            return list;
        }

        public void DeleteUser(int userId) {
            var cust = db.Customers.Find(userId);
            db.Customers.Remove(cust);
            db.SaveChanges();
        }

    }
}