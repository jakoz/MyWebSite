namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndOfActivityPropertyToRoutines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routines", "EndOfActivity", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routines", "EndOfActivity");
        }
    }
}
