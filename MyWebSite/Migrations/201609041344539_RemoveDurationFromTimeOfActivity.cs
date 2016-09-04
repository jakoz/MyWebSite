namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDurationFromTimeOfActivity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TimeOfActivities", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeOfActivities", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
