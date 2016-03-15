namespace Toman296NTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.User", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.User", new[] { "Id" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.User", "UserId");
            AddPrimaryKey("dbo.User", "Id");
        }
    }
}
