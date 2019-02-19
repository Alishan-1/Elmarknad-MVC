namespace Elmarknad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogModels",
                c => new
                    {
                        BlogModelId = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Ingress = c.String(),
                        ImagePath = c.String(),
                        HtmlContent = c.String(),
                        Timestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.BlogModelId);
            
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Contract = c.String(),
                        Förbrukning = c.Int(nullable: false),
                        Typ = c.String(),
                        ExtraInfo = c.String(),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        ÅrsAvgift = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Engångsavgift = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fastpris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RörligtInköpsPris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RörligtPåslag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miljöpåslag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RörligtMiljöpåslag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rabatt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Moms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Uppsägningstid = c.String(),
                        Automatiskförlängning = c.String(),
                        Omteckningsrätt = c.String(),
                        ElområdeId = c.Int(nullable: false),
                        ElBolagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.ElBolags", t => t.ElBolagId, cascadeDelete: true)
                .ForeignKey("dbo.Elområde", t => t.ElområdeId, cascadeDelete: true)
                .Index(t => t.ElområdeId)
                .Index(t => t.ElBolagId);
            
            CreateTable(
                "dbo.ElBolags",
                c => new
                    {
                        ElBolagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ElBolagId);
            
            CreateTable(
                "dbo.Elområde",
                c => new
                    {
                        ElområdeId = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                    })
                .PrimaryKey(t => t.ElområdeId);
            
            CreateTable(
                "dbo.Postnummers",
                c => new
                    {
                        PostnummerId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        ElområdeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostnummerId)
                .ForeignKey("dbo.Elområde", t => t.ElområdeId, cascadeDelete: true)
                .Index(t => t.ElområdeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        SocialSecurity = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Postnumber = c.String(),
                        City = c.String(),
                        AreaCode = c.String(),
                        PropertyCode = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DaySigned = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IpAdress = c.String(),
                        Paymentmethod = c.String(),
                        HasConfirmed = c.Boolean(nullable: false),
                        LetUsGetInfo = c.Boolean(nullable: false),
                        ClientId = c.Int(),
                        ScrapeId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.ClientModels", t => t.ClientId)
                .ForeignKey("dbo.ScrapeModels", t => t.ScrapeId)
                .Index(t => t.ClientId)
                .Index(t => t.ScrapeId);
            
            CreateTable(
                "dbo.ScrapeModels",
                c => new
                    {
                        ScrapeId = c.Int(nullable: false, identity: true),
                        Price = c.String(),
                        Company = c.String(),
                        Contract = c.String(),
                        Förbrukning = c.Int(nullable: false),
                        Typ = c.String(),
                        ExtraInfo = c.String(),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        ÅrsAvgift = c.String(),
                        Engångsavgift = c.String(),
                        Fastpris = c.String(),
                        RörligtInköpsPris = c.String(),
                        RörligtPåslag = c.String(),
                        Miljöpåslag = c.String(),
                        RörligtMiljöpåslag = c.String(),
                        Rabatt = c.String(),
                        Moms = c.String(),
                        Uppsägningstid = c.String(),
                        Automatiskförlängning = c.String(),
                        Omteckningsrätt = c.String(),
                        ElområdeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScrapeId)
                .ForeignKey("dbo.Elområde", t => t.ElområdeId, cascadeDelete: true)
                .Index(t => t.ElområdeId);
            
            CreateTable(
                "dbo.RemovedUserModels",
                c => new
                    {
                        RemovedUserModelId = c.Int(nullable: false, identity: true),
                        DateMoved = c.String(),
                        AdminName = c.String(),
                        SocialSecurity = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Postnumber = c.String(),
                        City = c.String(),
                        AreaCode = c.String(),
                        PropertyCode = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DaySigned = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IpAdress = c.String(),
                        Paymentmethod = c.String(),
                        HasConfirmed = c.Boolean(nullable: false),
                        LetUsGetInfo = c.Boolean(nullable: false),
                        Price = c.String(),
                        Company = c.String(),
                        Contract = c.String(),
                        Förbrukning = c.Int(nullable: false),
                        Typ = c.String(),
                        ExtraInfo = c.String(),
                        IsClient = c.Boolean(nullable: false),
                        Elområde = c.String(),
                    })
                .PrimaryKey(t => t.RemovedUserModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ScrapeId", "dbo.ScrapeModels");
            DropForeignKey("dbo.ScrapeModels", "ElområdeId", "dbo.Elområde");
            DropForeignKey("dbo.Customers", "ClientId", "dbo.ClientModels");
            DropForeignKey("dbo.ClientModels", "ElområdeId", "dbo.Elområde");
            DropForeignKey("dbo.Postnummers", "ElområdeId", "dbo.Elområde");
            DropForeignKey("dbo.ClientModels", "ElBolagId", "dbo.ElBolags");
            DropIndex("dbo.ScrapeModels", new[] { "ElområdeId" });
            DropIndex("dbo.Customers", new[] { "ScrapeId" });
            DropIndex("dbo.Customers", new[] { "ClientId" });
            DropIndex("dbo.Postnummers", new[] { "ElområdeId" });
            DropIndex("dbo.ClientModels", new[] { "ElBolagId" });
            DropIndex("dbo.ClientModels", new[] { "ElområdeId" });
            DropTable("dbo.RemovedUserModels");
            DropTable("dbo.ScrapeModels");
            DropTable("dbo.Customers");
            DropTable("dbo.Postnummers");
            DropTable("dbo.Elområde");
            DropTable("dbo.ElBolags");
            DropTable("dbo.ClientModels");
            DropTable("dbo.BlogModels");
        }
    }
}
