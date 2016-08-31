namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStructureOfScheduleTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleTasks", "Activity_Id", "dbo.TypeOfActivities");
            DropIndex("dbo.ScheduleTasks", new[] { "Activity_Id" });
            AddColumn("dbo.ScheduleTasks", "Note", c => c.String(maxLength: 4000));
            DropColumn("dbo.ScheduleTasks", "TimeOfStartingActivity");
            DropColumn("dbo.ScheduleTasks", "DurationOfTheActivity");
            DropColumn("dbo.ScheduleTasks", "Activity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleTasks", "Activity_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTasks", "DurationOfTheActivity", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ScheduleTasks", "TimeOfStartingActivity", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.ScheduleTasks", "Note");
            CreateIndex("dbo.ScheduleTasks", "Activity_Id");
            AddForeignKey("dbo.ScheduleTasks", "Activity_Id", "dbo.TypeOfActivities", "Id", cascadeDelete: true);
        }
    }
}
