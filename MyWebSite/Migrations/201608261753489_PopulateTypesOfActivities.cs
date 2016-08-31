namespace MyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypesOfActivities : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO TypeOfActivities (Name) VALUES ('Running')");
            Sql("INSERT INTO TypeOfActivities (Name) VALUES ('Gym')");
            Sql("INSERT INTO TypeOfActivities (Name) VALUES ('Reading')");
            Sql("INSERT INTO TypeOfActivities (Name) VALUES ('Resting')");
        }
        
        public override void Down()
        {
        }
    }
}
