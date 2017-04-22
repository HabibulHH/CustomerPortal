namespace CustomerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyingRecordModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBuyingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        BuyingDate = c.DateTime(nullable: false),
                        BuyingCustomerId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerBuyingRecords");
        }
    }
}
