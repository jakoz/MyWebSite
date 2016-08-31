namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStructureOfScheduleTaskv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTasks", "NoteA", c => c.String(maxLength: 4000));
            AddColumn("dbo.ScheduleTasks", "NoteB", c => c.String(maxLength: 4000));
            AddColumn("dbo.ScheduleTasks", "NoteC", c => c.String(maxLength: 4000));
            DropColumn("dbo.ScheduleTasks", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleTasks", "Note", c => c.String(maxLength: 4000));
            DropColumn("dbo.ScheduleTasks", "NoteC");
            DropColumn("dbo.ScheduleTasks", "NoteB");
            DropColumn("dbo.ScheduleTasks", "NoteA");
        }
    }
}
