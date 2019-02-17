using Elmarknad.Models.UserAdminModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Elmarknad.Models.Webscrape
{
    public class DbEl : DbContext
    {
        public virtual DbSet<Elområde> Elområden { get; set; }
        public virtual DbSet<Postnummer> Postnummers { get; set; }
        public virtual DbSet<ScrapeModel> ScrapeModels { get; set; }
        public virtual DbSet<ClientModel> ClientModels { get; set; }
        public virtual DbSet<ElBolag> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BlogModel> BlogPosts { get; set; }
        public virtual DbSet<RemovedUserModel> DeletedCustomer { get; set; }

        public DbEl() : base() {
          
        }
    }
}