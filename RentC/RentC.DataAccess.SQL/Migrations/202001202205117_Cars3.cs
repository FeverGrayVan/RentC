namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cars3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "CarID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CarID", c => c.Int(nullable: false));
        }
    }
}
