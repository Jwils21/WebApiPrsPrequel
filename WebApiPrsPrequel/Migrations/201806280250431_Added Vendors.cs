namespace WebApiPrsPrequel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVendors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                        IsPreApproved = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}
