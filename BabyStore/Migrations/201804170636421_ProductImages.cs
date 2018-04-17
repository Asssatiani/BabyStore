namespace BabyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductImageMappings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductImageMappings", "ProductImageID", "dbo.ProductImages");
            DropIndex("dbo.ProductImageMappings", new[] { "ProductID" });
            DropIndex("dbo.ProductImageMappings", new[] { "ProductImageID" });
            DropIndex("dbo.ProductImages", new[] { "FileName" });
            AlterColumn("dbo.ProductImages", "FileName", c => c.String());
            DropTable("dbo.ProductImageMappings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductImageMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ProductImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.ProductImages", "FileName", c => c.String(maxLength: 100));
            CreateIndex("dbo.ProductImages", "FileName", unique: true);
            CreateIndex("dbo.ProductImageMappings", "ProductImageID");
            CreateIndex("dbo.ProductImageMappings", "ProductID");
            AddForeignKey("dbo.ProductImageMappings", "ProductImageID", "dbo.ProductImages", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductImageMappings", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
