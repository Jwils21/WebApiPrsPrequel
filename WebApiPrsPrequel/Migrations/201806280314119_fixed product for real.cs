namespace WebApiPrsPrequel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedproductforreal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Vendor_Id", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "Vendor_Id" });
            DropColumn("dbo.Products", "VendorId");
            RenameColumn(table: "dbo.Products", name: "Vendor_Id", newName: "VendorId");
            AlterColumn("dbo.Products", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "VendorId");
            AddForeignKey("dbo.Products", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            AlterColumn("dbo.Products", "VendorId", c => c.Int());
            AlterColumn("dbo.Products", "VendorId", c => c.Boolean(nullable: false));
            RenameColumn(table: "dbo.Products", name: "VendorId", newName: "Vendor_Id");
            AddColumn("dbo.Products", "VendorId", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "Vendor_Id");
            AddForeignKey("dbo.Products", "Vendor_Id", "dbo.Vendors", "Id");
        }
    }
}
