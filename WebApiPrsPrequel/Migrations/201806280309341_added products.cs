namespace WebApiPrsPrequel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedproducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartNumber = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Unit = c.String(),
                        PhotoPath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            DropTable("dbo.Products");
        }
    }
}
