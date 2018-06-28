namespace WebApiPrsPrequel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            AddColumn("dbo.Products", "Vendor_Id", c => c.Int());
            AlterColumn("dbo.Products", "VendorId", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "Vendor_Id");
            AddForeignKey("dbo.Products", "Vendor_Id", "dbo.Vendors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Vendor_Id", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "Vendor_Id" });
            AlterColumn("dbo.Products", "VendorId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Vendor_Id");
            CreateIndex("dbo.Products", "VendorId");
            AddForeignKey("dbo.Products", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
    }
}
