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
            ViewBag.Message = "Who We Are";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Questions ";


            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Find Out More ";


            return View();
        }

    }
}