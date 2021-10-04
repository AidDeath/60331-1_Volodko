namespace _60331_1_Volodko.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        SweetId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Sweets", t => t.SweetId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.SweetId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sweets",
                c => new
                    {
                        SweetId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        SweetsName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CalorieContent = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.Binary(),
                        MimeType = c.String(),
                    })
                .PrimaryKey(t => t.SweetId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Purchases", "SweetId", "dbo.Sweets");
            DropForeignKey("dbo.Sweets", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Sweets", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Manufacturers", "CityId", "dbo.Cities");
            DropIndex("dbo.Sweets", new[] { "ManufacturerId" });
            DropIndex("dbo.Sweets", new[] { "CategoryId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "SweetId" });
            DropIndex("dbo.Manufacturers", new[] { "CityId" });
            DropTable("dbo.Sweets");
            DropTable("dbo.Purchases");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
        }
    }
}
