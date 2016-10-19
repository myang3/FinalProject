using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DFF.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DFF.Controllers
{
    public class DonationsController : Controller
    {
        private DFFEntities1 db = new DFFEntities1();

        // GET: DonationDatas
        public ActionResult Index()
        {
            db.MatchUp.ToList();
            return View(db.DonationData.ToList());
        }

        // GET: DonationDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationData donationData = db.DonationData.Find(id);
            if (donationData == null)
            {
                return HttpNotFound();
            }
            return View(donationData);
        }

        // GET: DonationDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonationDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,Name,Email,Phone,FoodType,Location,PickupDate,PickupTime")] DonationData donationData)
        {
            if (ModelState.IsValid)
            {
                db.DonationData.Add(donationData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donationData);
        }

        // GET: DonationDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationData donationData = db.DonationData.Find(id);
            if (donationData == null)
            {
                return HttpNotFound();
            }
            return View(donationData);
        }

        // POST: DonationDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,Name,Email,Phone,FoodType,Location,PickupDate,PickupTime")] DonationData donationData)
        {


            if (ModelState.IsValid)
            {
                db.Entry(donationData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donationData);
        }

        // GET: DonationDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationData donationData = db.DonationData.Find(id);
            if (donationData == null)
            {
                return HttpNotFound();
            }
            return View(donationData);
        }

        // POST: DonationDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationData donationData = db.DonationData.Find(id);
            db.DonationData.Remove(donationData);
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

        //--------------Email using SMTP client and gmail-----------------------------------
        //-------------- must use a post method to send---------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "This is a test";
                var sendTo = "dariushunter777@gmail.com";

                await RequsetToDonor(sendTo, "from email", body );
                return RedirectToAction("Sent");

            }
            return View(model);
        }

        private static async Task RequsetToDonor(string toEmail, string fromEmail,string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail));  // replace with valid value 
            message.From = new MailAddress(fromEmail);  // replace with valid value
            message.Subject = "Comments about the site";
            message.Body = body;
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
            }
        }
    }

}

