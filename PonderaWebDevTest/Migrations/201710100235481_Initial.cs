namespace PonderaWebDevTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        CountryName = c.String(nullable: false, maxLength: 50),
                        CurrencyName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CurrencyConversionDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SourceCountry = c.String(nullable: false, maxLength: 50),
                        SourceCountryCurrency = c.String(nullable: false, maxLength: 50),
                        SourceCountryExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TargetCountry = c.String(nullable: false, maxLength: 50),
                        TargetCountryCurrency = c.String(nullable: false, maxLength: 50),
                        TargetCountryExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConversionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CurrencyConversionDatas");
            DropTable("dbo.CountryDatas");
        }
    }
}
