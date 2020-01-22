namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clients2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ClientId", c => c.String());
        }
    }
}
