namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCodes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "AId", "dbo.Admins");
            DropForeignKey("dbo.News", "CId", "dbo.Categories");
            DropIndex("dbo.Employees", new[] { "AId" });
            DropIndex("dbo.News", new[] { "CId" });
            DropTable("dbo.Admins");
            DropTable("dbo.Employees");
            DropTable("dbo.Categories");
            DropTable("dbo.News");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.News", "CId");
            CreateIndex("dbo.Employees", "AId");
            AddForeignKey("dbo.News", "CId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "AId", "dbo.Admins", "Id", cascadeDelete: true);
        }
    }
}
