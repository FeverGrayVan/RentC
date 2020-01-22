namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expiration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ReservStatsID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservStatsID", c => c.Single(nullable: false));
        }
    }
}
