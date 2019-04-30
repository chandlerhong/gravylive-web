using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GravyLiveWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a mock-up demo application for Gravy Live, created for the Information Systems class at UW-Madison for Spring 2019 by Graham Pearce, Ryan Potocki, Duy Tran, Kathy Ni, and Chandler Hong.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You don't need to contact us.";

            return View();
        }
    }
}