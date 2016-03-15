using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Toman296NTermProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Toman296NTermProject.DAL
{
    public class Toman296NTermProjectContext : IdentityDbContext
    {
        // http://stackoverflow.com/questions/28531201/entitytype-identityuserlogin-has-no-key-defined-define-the-key-for-this-entit
        public Toman296NTermProjectContext() : base("Toman296NTermProjectContext")
        {
            Database.SetInitializer<Toman296NTermProjectContext>(null); 
            Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MeetupGroup> MeetupGroups { get; set; }
        public DbSet<MeetupMemberParsed> MeetupMembersParsed { get; set; }
        //public DbSet<MeetupMemberUnparsed> MeetupMembersUnparsed { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<User> RegistryUsers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            //modelBuilder.Entity<User>().ToTable("User");
        }

    }
}