namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertiesForTimeActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeOfActivities", "UserId", c => c.String());
            AddColumn("dbo.TimeOfActivities", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeOfActivities", "Date");
            DropColumn("dbo.TimeOfActivities", "UserId");
        }
    }
}
