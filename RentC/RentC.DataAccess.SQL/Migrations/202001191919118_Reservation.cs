namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CarID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ReservStatsID = c.Single(nullable: false),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Location = c.String(),
                        CouponCode = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
