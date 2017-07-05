namespace CustomerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companymodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compnays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        BakiAmount = c.Double(nullable: false),
                        MobileNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Compnays");
        }
    }
}
