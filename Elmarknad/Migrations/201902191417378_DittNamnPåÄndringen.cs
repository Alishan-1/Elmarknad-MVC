namespace Elmarknad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DittNamnPåÄndringen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScrapeModels", "Autogiro", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "EFaktura", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Pappersfaktura", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "House", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Appartment", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Sol", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Vind", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Vatten", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Bio", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScrapeModels", "Miljömärkt", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScrapeModels", "Miljömärkt");
            DropColumn("dbo.ScrapeModels", "Bio");
            DropColumn("dbo.ScrapeModels", "Vatten");
            DropColumn("dbo.ScrapeModels", "Vind");
            DropColumn("dbo.ScrapeModels", "Sol");
            DropColumn("dbo.ScrapeModels", "Appartment");
            DropColumn("dbo.ScrapeModels", "House");
            DropColumn("dbo.ScrapeModels", "Pappersfaktura");
            DropColumn("dbo.ScrapeModels", "EFaktura");
            DropColumn("dbo.ScrapeModels", "Autogiro");
        }
    }
}
