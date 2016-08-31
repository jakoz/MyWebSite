namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleTasksV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.String(nullable: false),
                        TimeOfStartingActivity = c.Time(nullable: false, precision: 7),
                        DurationOfTheActivity = c.Time(nullable: false, precision: 7),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfActivities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Activity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleTasks", "Activity_Id", "dbo.TypeOfActivities");
            DropIndex("dbo.ScheduleTasks", new[] { "Activity_Id" });
            DropTable("dbo.ScheduleTasks");
        }
    }
}
