using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

using PonderaWebDevTest.Models;
using PonderaWebDevTest.Migrations;

using WebGrease.Css.Extensions;

using Configuration = PonderaWebDevTest.Migrations.Configuration;

namespace PonderaWebDevTest.Controllers
{
    public class CurrencyConversionController : Controller
    {
        private const decimal ExchangeRateRange = 250.0M;
        private readonly Random randomNumber = new Random(DateTime.Now.Millisecond);

        private PonderaTestAppContext db = new PonderaTestAppContext();

        // GET: CurrencyConversion
        public ActionResult Index()
        {
            // Used stored proc (only for illustrative purposes) via ADO. I could have used the proc
            // directly through EF (which would be better), but just wanted to illustrate this approach.

            DataTable dt;

            using (var dbConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(Configuration.ConversionDataProc, dbConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        })
                {

                    using (var sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dt = new DataTable("CurrencyConversion");
                        sqlAdapter.Fill(dt);
                    }
                }
            }

            var conversionList = new List<CurrencyConversionData>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    conversionList.Add(new CurrencyConversionData()
                                       {
                                           Id = Convert.ToInt64(dataRow["Id"]),

                                           SourceCountry = dataRow["SourceCountry"].ToString(),
                                           SourceCountryCurrency = dataRow["SourceCountryCurrency"].ToString(),
                                           SourceCountryExchangeRate = Convert.ToDecimal(dataRow["SourceCountryExchangeRate"]),

                                           TargetCountry = dataRow["TargetCountry"].ToString(),
                                           TargetCountryCurrency = dataRow["TargetCountryCurrency"].ToString(),
                                           TargetCountryExchangeRate = Convert.ToDecimal(dataRow["TargetCountryExchangeRate"]),

                                           ConversionAmount = Convert.ToDecimal(dataRow["ConversionAmount"])
                                       });
                }
            }

            return View(conversionList);
        }

        // POST: CurrencyConversion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SourceCountry,TargetCountry,Amount")] CurrencyConversionInput currencyConversionInput)
        {
            CurrencyConversionData conversionData = new CurrencyConversionData();

            if (ModelState.IsValid)
            {
                // Do a conversion operation.

                // Here's where we would go out and use some external data source to find out what the 
                // current coversion rate is between the two countries.

                conversionData = new CurrencyConversionData
                                 {
                                     SourceCountry = currencyConversionInput.SourceCountry,
                                     TargetCountry = currencyConversionInput.TargetCountry,

                                     ConversionAmount = currencyConversionInput.ConversionAmount,

                                     SourceCountryExchangeRate = Convert.ToDecimal(randomNumber.NextDouble()) * ExchangeRateRange,
                                     TargetCountryExchangeRate = Convert.ToDecimal(randomNumber.NextDouble()) * ExchangeRateRange,
                                 };

                CountryData sourceCountryDatacountryData = db.CountryData.FirstOrDefault(nm => nm.CountryName == currencyConversionInput.SourceCountry);
                if (sourceCountryDatacountryData != null &&
                    !string.IsNullOrEmpty(sourceCountryDatacountryData.CurrencyName))
                {
                    conversionData.SourceCountryCurrency = sourceCountryDatacountryData.CurrencyName;
                }

                CountryData targetCountryDatacountryData = db.CountryData.FirstOrDefault(nm => nm.CountryName == currencyConversionInput.TargetCountry);
                if (targetCountryDatacountryData != null &&
                    !string.IsNullOrEmpty(targetCountryDatacountryData.CurrencyName))
                {
                    conversionData.SourceCountryCurrency = targetCountryDatacountryData.CurrencyName;
                }

                db.CurrencyConversionData.Add(conversionData);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(conversionData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
