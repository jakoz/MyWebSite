namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRoutineModelStatev3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities");
            DropIndex("dbo.Routines", new[] { "Time_Id" });
            AlterColumn("dbo.Routines", "Time_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Routines", "Time_Id");
            AddForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities");
            DropIndex("dbo.Routines", new[] { "Time_Id" });
            AlterColumn("dbo.Routines", "Time_Id", c => c.Int());
            CreateIndex("dbo.Routines", "Time_Id");
            AddForeignKey("dbo.Routines", "Time_Id", "dbo.TimeOfActivities", "Id");
        }
    }
}
