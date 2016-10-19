using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFF.Models;

namespace DFF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Overall Mission Statement";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How You Can Reach Us";

            return View();
        }

    }
}