namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTimeOfActivity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TimeOfActivities", "RoutineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeOfActivities", "RoutineId", c => c.String());
        }
    }
}
