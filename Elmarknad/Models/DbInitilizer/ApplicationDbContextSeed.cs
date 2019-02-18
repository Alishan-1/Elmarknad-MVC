
using Elmarknad.Models;
using Elmarknad.Repo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models.DBInitilizer
{
    public class ApplicationDbContextSeed : System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {

           

            var passwordhash = new PasswordHasher();
            var HasRoleOrName = false;

            if (!db.Roles.Any(r => r.Name == "Admin"))
            {
                HasRoleOrName = true;
                var store = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            if (!db.Users.Any(u => u.UserName == "samuel@elmarknad.se"))
            {
                HasRoleOrName = true;
                var store = new UserStore<ApplicationUser>(db);
                var usermanager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser
                {

                    UserName = "samuel@elmarknad.se",
                    Email = "samuel@elmarknad.se",
                    PasswordHash = passwordhash.HashPassword("Samuel22.")

                };

                usermanager.Create(user);
                usermanager.AddToRole(user.Id, "Admin");
            }

            if (!db.Users.Any(u => u.UserName == "andreas@elmarknad.se"))
            {
                HasRoleOrName = true;
                var store = new UserStore<ApplicationUser>(db);
                var usermanager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser
                {

                    UserName = "andreas@elmarknad.se",
                    Email = "andreas@elmarknad.se",
                    PasswordHash = passwordhash.HashPassword("Samuel22.")

                };

                usermanager.Create(user);
                usermanager.AddToRole(user.Id, "Admin");
                
            }

            if (!db.Users.Any(u => u.UserName == "oliwer@elmarknad.se"))
            {
                HasRoleOrName = true;
                var store = new UserStore<ApplicationUser>(db);
                var usermanager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser
                {

                    UserName = "oliwer@elmarknad.se",
                    Email = "oliwer@elmarknad.se",
                    PasswordHash = passwordhash.HashPassword("Samuel22.")

                };

                usermanager.Create(user);
                usermanager.AddToRole(user.Id, "Admin");
            }

            if (HasRoleOrName) {
                db.SaveChanges();
                base.Seed(db);
            }
        }
    }
}