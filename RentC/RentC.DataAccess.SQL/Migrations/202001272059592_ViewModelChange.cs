namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Reservation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationViewModels", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.ReservationViewModels", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationViewModels");
        }
    }
}
