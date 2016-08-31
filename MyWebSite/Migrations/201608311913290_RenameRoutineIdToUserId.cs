namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameRoutineIdToUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routines", "UserId", c => c.String());
            DropColumn("dbo.Routines", "RoutineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routines", "RoutineId", c => c.String());
            DropColumn("dbo.Routines", "UserId");
        }
    }
}
