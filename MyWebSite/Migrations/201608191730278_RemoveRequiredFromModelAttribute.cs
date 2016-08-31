namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredFromModelAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "ScheduleId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "ScheduleId", c => c.String(nullable: false));
        }
    }
}
