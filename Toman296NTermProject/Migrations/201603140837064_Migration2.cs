namespace Toman296NTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MeetupMemberUnparsed", newName: "MeetupMemberParsed");
            DropColumn("dbo.MeetupMemberParsed", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeetupMemberParsed", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameTable(name: "dbo.MeetupMemberParsed", newName: "MeetupMemberUnparsed");
        }
    }
}
