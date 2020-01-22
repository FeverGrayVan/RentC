namespace RentC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clients1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ClientName", c => c.String());
            DropColumn("dbo.Clients", "ClientFirstName");
            DropColumn("dbo.Clients", "ClientLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ClientLastName", c => c.String());
            AddColumn("dbo.Clients", "ClientFirstName", c => c.String());
            DropColumn("dbo.Clients", "ClientName");
        }
    }
}
