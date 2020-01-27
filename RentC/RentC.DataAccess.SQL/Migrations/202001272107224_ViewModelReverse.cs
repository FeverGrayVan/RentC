namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelReverse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationViewModels", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.ReservationViewModels", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReservationViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Reservation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ReservationViewModels", "Reservation_Id");
            AddForeignKey("dbo.ReservationViewModels", "Reservation_Id", "dbo.Reservations", "Id");
        }
    }
}
