namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRoutineModelStatev2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeOfActivities", "Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeOfActivities", "Day");
        }
    }
}
