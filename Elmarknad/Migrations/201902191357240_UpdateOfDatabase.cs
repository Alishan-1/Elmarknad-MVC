namespace Elmarknad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOfDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientModels", "Autogiro", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "EFaktura", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Pappersfaktura", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "House", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Appartment", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Sol", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Vind", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Vatten", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Bio", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientModels", "Miljömärkt", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientModels", "Miljömärkt");
            DropColumn("dbo.ClientModels", "Bio");
            DropColumn("dbo.ClientModels", "Vatten");
            DropColumn("dbo.ClientModels", "Vind");
            DropColumn("dbo.ClientModels", "Sol");
            DropColumn("dbo.ClientModels", "Appartment");
            DropColumn("dbo.ClientModels", "House");
            DropColumn("dbo.ClientModels", "Pappersfaktura");
            DropColumn("dbo.ClientModels", "EFaktura");
            DropColumn("dbo.ClientModels", "Autogiro");
        }
    }
}
