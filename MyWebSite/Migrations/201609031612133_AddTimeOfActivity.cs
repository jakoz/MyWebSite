namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeOfActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeOfActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoutineId = c.String(),
                        Start = c.Time(nullable: false, precision: 7),
                        Duration = c.Time(nullable: false, precision: 7),
                        End = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Routines", "Time_Id", c => c.Int());
            CreateIndex("dbo.Routines", "Time_Id");
            AddForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities", "Id");
            DropColumn("dbo.Routines", "TimeOfStartingActivity");
            DropColumn("dbo.Routines", "DurationOfTheActivity");
            DropColumn("dbo.Routines", "EndOfActivity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routines", "EndOfActivity", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Routines", "DurationOfTheActivity", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Routines", "TimeOfStartingActivity", c => c.Time(nullable: false, precision: 7));
            DropForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities");
            DropIndex("dbo.Routines", new[] { "Time_Id" });
            DropColumn("dbo.Routines", "Time_Id");
            DropTable("dbo.TimeOfActivities");
        }
    }
}
