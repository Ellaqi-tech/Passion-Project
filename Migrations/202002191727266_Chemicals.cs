namespace ChemicalShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chemicals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Chemicals",
                c => new
                    {
                        ChemicalID = c.Int(nullable: false, identity: true),
                        ChemicalName = c.String(),
                        ProductDescription = c.String(),
                        ProductCode = c.String(),
                        Price = c.Int(nullable: false),
                        MinOrder = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ChemicalPic = c.Int(nullable: false),
                        PicExtension = c.String(),
                    })
                .PrimaryKey(t => t.ChemicalID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanylID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                    })
                .PrimaryKey(t => t.CompanylID);
            
            CreateTable(
                "dbo.OrderChemicals",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        Chemical_ChemicalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Chemical_ChemicalID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Chemicals", t => t.Chemical_ChemicalID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Chemical_ChemicalID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.OrderChemicals", "Chemical_ChemicalID", "dbo.Chemicals");
            DropForeignKey("dbo.OrderChemicals", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Chemicals", "CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderChemicals", new[] { "Chemical_ChemicalID" });
            DropIndex("dbo.OrderChemicals", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "CompanyID" });
            DropIndex("dbo.Chemicals", new[] { "CategoryID" });
            DropTable("dbo.OrderChemicals");
            DropTable("dbo.Companies");
            DropTable("dbo.Orders");
            DropTable("dbo.Chemicals");
            DropTable("dbo.Categories");
        }
    }
}
