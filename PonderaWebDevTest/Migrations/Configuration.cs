using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PonderaWebDevTest.Models;

namespace PonderaWebDevTest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PonderaTestAppContext>
    {
        private const string sqlDropCmd = "IF EXISTS (SELECT type_desc, type FROM sys.procedures WITH(NOLOCK) WHERE NAME = 'ReadCurrencyConversionData' AND type = 'P') \n" +
                                          "DROP PROCEDURE dbo.ReadCurrencyConversionData";

        private const string sqlPreStoredProcCmd1 = "SET ANSI_NULLS ON";

        private const string sqlPreStoredProcCmd2 = "SET QUOTED_IDENTIFIER ON";

        private const string sqlStoredProcCmd = "CREATE PROCEDURE dbo.ReadCurrencyConversionData " +
                                                "AS " +
                                                "SELECT " +
                                                "  Id, " +
                                                "  SourceCountry, " +
                                                "  SourceCountryCurrency, " +
                                                "  SourceCountryExchangeRate, " +
                                                "  TargetCountry, " +
                                                "  TargetCountryCurrency," +
                                                "  TargetCountryExchangeRate, " +
                                                "  ConversionAmount " +
                                                "FROM CurrencyConversionDatas";

        public const string ConversionDataProc = "ReadCurrencyConversionData";

        private readonly List<string> _sqlStatements = new List<string>()
                                                       {
                                                           sqlDropCmd,
                                                           sqlPreStoredProcCmd1,
                                                           sqlPreStoredProcCmd2,
                                                           sqlStoredProcCmd
                                                       };

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PonderaTestAppContext context)
        {
            var countryData = new List<CountryData>
                              {
                                  new CountryData() {Code = 1, CountryName = "USA", CurrencyName = "USD"},
                                  new CountryData() {Code = 44, CountryName = "United Kingdom", CurrencyName = "GBP"},
                                  new CountryData() {Code = 49, CountryName = "Germany", CurrencyName = "Euro"},
                                  new CountryData() {Code = 93, CountryName = "Afghanistan", CurrencyName = "AFN"},
                                  new CountryData() {Code = 355, CountryName = "Albania", CurrencyName = "ALL"},
                                  new CountryData() {Code = 213, CountryName = "Algeria", CurrencyName = "DZD"},
                                  new CountryData() {Code = 52, CountryName = "Mexico", CurrencyName = "MXN"},
                                  new CountryData() {Code = 63, CountryName = "Philippines", CurrencyName = "PHP"},
                                  new CountryData() {Code = 1876, CountryName = "Jamaica", CurrencyName = "JMD"},
                                  new CountryData() {Code = 81, CountryName = "Japan", CurrencyName = "JPY"}
                              };

            countryData.ForEach(s => context.CountryData.Add(s));

            _sqlStatements.ForEach(s => context.Database.ExecuteSqlCommand(s));

            context.SaveChanges();
        }
    }
}
