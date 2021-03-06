namespace Toman296NTermProject.Migrations
{
    using DAL;
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Toman296NTermProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Toman296NTermProjectContext context)
        {
            MeetupMemberParsed m1 = new MeetupMemberParsed { city = "Testville", country = "us", gender = "non-binary", id = "test", lat = "-1.00", link = "www.google.com", lon = "-1.00", name = "Database Seed", status = "Inactive" };
            context.MeetupMembersParsed.AddOrUpdate(m => m.gender, m1);

            User u1 = new User { email = "samantha.toman@gmail.com", fname = "Samantha", lname = "Toman", organization = "LCC" };
            context.RegistryUsers.Add(u1);
            context.SaveChanges();


            if (!(context.Users.Any(u => u.UserName == "test@test.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "test@test.com", PhoneNumber = "1234567890" };
                userManager.Create(userToInsert, "Password123!");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
                {
                    Name = "Admin"
                });

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
                {
                    Name = "Guest"
                });

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
                {
                    Name = "User"
                });

                context.SaveChanges();
                userManager.AddToRole(userToInsert.Id, "Admin");
                userManager.AddToRole(userToInsert.Id, "Guest");
                userManager.AddToRole(userToInsert.Id, "User");
            }
        }
    }
}
