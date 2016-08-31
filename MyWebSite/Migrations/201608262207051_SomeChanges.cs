namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTasks", "DateOfSchedule", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleTasks", "DateOfSchedule");
        }
    }
}
