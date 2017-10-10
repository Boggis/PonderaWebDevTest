using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PonderaWebDevTest.Models;

namespace PonderaWebDevTest.Controllers
{
    public class CountryDataController : Controller
    {
        private PonderaTestAppContext db = new PonderaTestAppContext();

        // GET: CountryData

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.CountryData.ToList());
        }

        // GET: CountryData/Details/

        [HttpGet]
        public ActionResult Details(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Look for country matching Id...

            CountryData countryData = db.CountryData.FirstOrDefault(cc => cc.Id == Id);

            if (countryData == null)
            {
                return HttpNotFound();
            }

            return View(countryData);
        }

        [HttpGet]
        public JsonResult Decode(string phoneNumber)
        {

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Json("Invalid phone number.", JsonRequestBehavior.AllowGet);
            }

            // Parse the phone number... get the leading country code.

            int countryCode = DecodePhoneNumber(phoneNumber);

            // Look for country matching code...

            CountryData countryData = db.CountryData.FirstOrDefault(cc => cc.Code == countryCode);

            if (countryData == null)
            {
                return Json("Invalid phone number - Unable to decode.", JsonRequestBehavior.AllowGet);
            }

            return Json(countryData, JsonRequestBehavior.AllowGet);
        }

        private int DecodePhoneNumber(string phoneNumber)
        {
            return 44; // TODO : Add phone number decode logic
        }

        /// <summary>
        /// Create a new CountryData instance
        /// 
        /// GET: CountryData/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: CountryData/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryData countryData = db.CountryData.Find(id);
            if (countryData == null)
            {
                return HttpNotFound();
            }
            return View(countryData);
        }

        // POST: CountryData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,CountryName,CurrencyName")] CountryData countryData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryData);
        }

        // GET: CountryData/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryData countryData = db.CountryData.Find(id);
            if (countryData == null)
            {
                return HttpNotFound();
            }
            return View(countryData);
        }

        // POST: CountryData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CountryData countryData = db.CountryData.Find(id);
            db.CountryData.Remove(countryData);
            db.SaveChanges();
            return RedirectToAction("Index");
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
