namespace Toman296NTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.User", new[] { "Id" });
            DropPrimaryKey("dbo.User");
            DropColumn("dbo.User", "Id");
            DropColumn("dbo.User", "Name");
            AddColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.User", "fname", c => c.String());
            AddColumn("dbo.User", "lname", c => c.String());
            AddColumn("dbo.User", "email", c => c.String());
            AddPrimaryKey("dbo.User", "UserId");
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
            
            AddColumn("dbo.User", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.User");
            DropColumn("dbo.User", "email");
            DropColumn("dbo.User", "lname");
            DropColumn("dbo.User", "fname");
            DropColumn("dbo.User", "UserId");
            DropTable("dbo.AspNetUsers");
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.User", "Id");
            AddForeignKey("dbo.User", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
