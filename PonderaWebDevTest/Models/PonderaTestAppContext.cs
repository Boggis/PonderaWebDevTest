using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PonderaWebDevTest.Models
{
    public class PonderaTestAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PonderaTestAppContext() : base("name=PonderaTestAppContext")
        {
        }
        
        // Not going to store converstion data in the DB, but elsewhere we'll use ADO.NET 
        // to log requested conversions.

        public DbSet<CurrencyConversionData> CurrencyConversionData { get; set; }
        public DbSet<CountryData> CountryData { get; set; }
    }
}
