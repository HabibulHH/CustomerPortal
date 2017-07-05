namespace CustomerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyPaymentVMaded1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompanyPayments", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyPayments", "CompanyName", c => c.Int(nullable: false));
        }
    }
}
