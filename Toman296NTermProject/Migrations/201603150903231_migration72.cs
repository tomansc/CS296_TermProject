namespace Toman296NTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration72 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Name");
        }
        
        public override void Down()
        {
        }
    }
}
