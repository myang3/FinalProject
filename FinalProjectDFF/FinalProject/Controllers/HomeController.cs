using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult RegisterEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEvent(RegisterEventModel form)
        {
            if (ModelState.IsValid)
            {
            return View();

            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}