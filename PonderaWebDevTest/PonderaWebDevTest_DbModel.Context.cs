﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PonderaWebDevTest
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PonderaWebDevTest_Connection : DbContext
    {
        public PonderaWebDevTest_Connection()
            : base("name=PonderaWebDevTest_Connection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CountryData> CountryDatas { get; set; }
        public virtual DbSet<CurrencyConversionData> CurrencyConversionDatas { get; set; }
    
        public virtual ObjectResult<ReadCurrencyConversionData_Result> ReadCurrencyConversionData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadCurrencyConversionData_Result>("ReadCurrencyConversionData");
        }
    }
}
