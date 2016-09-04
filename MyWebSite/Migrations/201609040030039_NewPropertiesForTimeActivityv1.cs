namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertiesForTimeActivityv1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TimeOfActivities", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeOfActivities", "Date", c => c.String());
        }
    }
}
