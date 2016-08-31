namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoutineModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoutineId = c.String(nullable: false),
                        Day = c.String(),
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
            DropForeignKey("dbo.Routines", "Activity_Id", "dbo.TypeOfActivities");
            DropIndex("dbo.Routines", new[] { "Activity_Id" });
            DropTable("dbo.Routines");
        }
    }
}
