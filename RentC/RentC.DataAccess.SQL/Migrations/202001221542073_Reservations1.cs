namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "CarID", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "CustomerID", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Location", c => c.String());
            AlterColumn("dbo.Reservations", "CustomerID", c => c.String());
            AlterColumn("dbo.Reservations", "CarID", c => c.String());
        }
    }
}
