using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonderaWebDevTest.Controllers
{
    public class HomeController : Controller
    {
        public const string AppName = "Pondera";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = AppName;
            ViewBag.Message = "Pondera Web Dev Test App.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = AppName;
            ViewBag.Message = "Developer Contact info.";

            return View();
        }
    }
}