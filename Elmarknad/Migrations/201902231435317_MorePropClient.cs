namespace Elmarknad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MorePropClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientModels", "MinFörbrukning", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "PaymentAddress", c => c.String());
            AddColumn("dbo.Customers", "PaymentPostnumber", c => c.String());
            AddColumn("dbo.Customers", "PaymentCity", c => c.String());
            AddColumn("dbo.Customers", "IsMoving", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsMoving");
            DropColumn("dbo.Customers", "PaymentCity");
            DropColumn("dbo.Customers", "PaymentPostnumber");
            DropColumn("dbo.Customers", "PaymentAddress");
            DropColumn("dbo.ClientModels", "MinFörbrukning");
        }
    }
}
