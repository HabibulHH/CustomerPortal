namespace CustomerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerPaymentModelEdited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerPayments", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerPayments", "PayingCustomerId", c => c.String(nullable: false));
            DropColumn("dbo.CustomerPayments", "CustomeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerPayments", "CustomeId", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerPayments", "PayingCustomerId");
            DropColumn("dbo.CustomerPayments", "CustomerId");
        }
    }
}
