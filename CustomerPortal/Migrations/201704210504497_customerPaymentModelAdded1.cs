namespace CustomerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerPaymentModelAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Customer_Table_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerPayments");
        }
    }
}
