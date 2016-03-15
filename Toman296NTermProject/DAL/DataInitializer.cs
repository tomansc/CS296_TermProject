using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Toman296NTermProject.Models;

namespace Toman296NTermProject.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Toman296NTermProjectContext>
    {
        protected override void Seed(Toman296NTermProjectContext context)
        {
            MeetupMemberParsed m1 = new MeetupMemberParsed { city = "Testville", country = "us", gender = "non-binary", id = "test", lat = "-1.00", link = "www.google.com", lon = "-1.00", name = "Database Seed", status = "Inactive" };
            context.SaveChanges();
        }

    }
}