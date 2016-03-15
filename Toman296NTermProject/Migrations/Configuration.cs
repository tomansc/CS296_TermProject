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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Toman296NTermProjectContext context)
        {
            MeetupMemberParsed m1 = new MeetupMemberParsed { city = "Testville", country = "us", gender = "non-binary", id = "test", lat = "-1.00", link = "www.google.com", lon = "-1.00", name = "Database Seed", status = "Inactive" };
            context.MeetupMembersParsed.AddOrUpdate(m => m.gender, m1);

            if (!(context.Users.Any(u => u.UserName == "test@test.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "test@test.com", PhoneNumber = "1234567890" };
                userManager.Create(userToInsert, "Password123");

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
            /*var manager = new UserManager<User>(
                new UserStore<User>(context));

            var user = new User { UserName = "testUser", Email = "test@user.com" };
            manager.Create(user);
            context.Users.AddOrUpdate(u => u.UserName, user);

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
            {
                Name = "Admin, Guest, User"
            });

            context.SaveChanges();
            userManager.AddToRole(user.Id, "Admin");
            manager.AddToRole(user.Id, "Guest");
            manager.AddToRole(user.Id, "User");*/
        }
    }
}
