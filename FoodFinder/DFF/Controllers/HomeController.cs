using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFF.Models;
using System.Data.Entity;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DFF.Controllers
{
    public class HomeController : Controller
    {
        DFFEntities1 dff = new DFFEntities1();
        

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

        //--------------Email using SMTP client and gmail-----------------------------------
        //-------------- must use a post method to send---------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();

                message.To.Add(new MailAddress("dariushunter777@gmail.com"));  // replace with valid value 
                message.To.Add(new MailAddress("darius777hunter@gmail.com"));  // replace with valid value 
                message.To.Add(new MailAddress("dragonpride777@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("DetroitFoodFinders@DFF.com");  // replace with valid value
                message.Subject = "It works";
                message.Body = "We win";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "detroitfoodfinders@gmail.com",  // replace with valid value
                        Password = "foodfinder1234"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            ViewBag.Message = "Email works. Fix and modify now";

            return View();
        }


    }
}
