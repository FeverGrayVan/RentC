namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "EndDate", c => c.String());
            AlterColumn("dbo.Reservations", "StartDate", c => c.String());
        }
    }
}
