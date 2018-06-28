namespace WebApiPrsPrequel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedvedor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "IsPreApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "IsPreApproved", c => c.String());
        }
    }
}
