namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DemoAir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        email = c.String(),
                        AId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AId, cascadeDelete: true)
                .Index(t => t.AId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        email = c.String(nullable: false),
                        city = c.String(nullable: false),
                        country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirLineName = c.String(),
                        DepDate = c.DateTime(nullable: false),
                        DesDate = c.DateTime(nullable: false),
                        DepLoc = c.String(),
                        DesLoc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AId", "dbo.Admins");
            DropIndex("dbo.Employees", new[] { "AId" });
            DropTable("dbo.Flights");
            DropTable("dbo.Customers");
            DropTable("dbo.Employees");
            DropTable("dbo.Admins");
        }
    }
}
