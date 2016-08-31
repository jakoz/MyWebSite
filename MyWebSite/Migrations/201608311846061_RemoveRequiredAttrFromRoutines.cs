namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredAttrFromRoutines : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routines", "RoutineId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routines", "RoutineId", c => c.String(nullable: false));
        }
    }
}
