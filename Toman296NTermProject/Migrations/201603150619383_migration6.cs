namespace Toman296NTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "organization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "organization");
        }
    }
}
