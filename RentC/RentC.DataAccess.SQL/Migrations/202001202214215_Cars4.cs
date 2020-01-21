namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cars4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "CustomerID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
