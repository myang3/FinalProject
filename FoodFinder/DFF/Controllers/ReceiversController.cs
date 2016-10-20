using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DFF.Models;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DFF.Controllers
{
    public class ReceiversController : Controller
    {
        private DFFEntities1 db = new DFFEntities1();

        // GET: Receivers
        public ActionResult Index()
        {
            return View(db.ReceiverData.ToList());
        }

        // GET: Receivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiverData receiverData = db.ReceiverData.Find(id);
            if (receiverData == null)
            {
                return HttpNotFound();
            }
            return View(receiverData);
        }

        public ActionResult Create(int id)
        {
            DonationData donationdata = db.DonationData.Find(id);
            if (donationdata == null) { donationdata = new DonationData(); }
            ViewBag.donationdata = donationdata;
            return View();
        }
        // POST: Receivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReceiverID,Name,Email,Phone")] ReceiverData receiverData, int donationId, string d)
        {
            if (ModelState.IsValid)
            {
                db.ReceiverData.Add(receiverData);
                db.SaveChanges();

                List<ReceiverData> recieverdataMathces = db.ReceiverData.Where(r => r.Email == receiverData.Email && r.Name == receiverData.Name && r.Phone == receiverData.Phone).OrderByDescending(r => r.ReceiverID).ToList();
                db.MatchUp.Add(new MatchUp() { DonationID = donationId, ReceiverID = recieverdataMathces[0].ReceiverID });
                db.SaveChanges();
                DonationData done = new DonationData();
                done.DonationID = donationId;
                DonationData data = db.DonationData.Where(r => r.DonationID == donationId).Single();

                //--------------  full url----------
                var fullURL = this.Url.Action("edit", "donations", new { id = donationId }, this.Request.Url.Scheme);

                var body = $"Hello {data.Name}<br />, a user is interested in your donation. Here is the contact info:<br/> {receiverData.Name}<br />{receiverData.Phone}<br />{receiverData.Email}.<br /><br /> Please flag post after it is picked up by following thie link <br />{fullURL}.";
                var sendTo = data.Email;

                await RequsetToDonor(sendTo, "DetroitFoodFinders@dff.com", body);
               // return RedirectToAction("Sent");



                return RedirectToAction("", "Donations");
            }

            return View(receiverData);
        }

        // GET: Receivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiverData receiverData = db.ReceiverData.Find(id);
            if (receiverData == null)
            {
                return HttpNotFound();
            }
            return View(receiverData);
        }

        // POST: Receivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceiverID,Name,Email,Phone")] ReceiverData receiverData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiverData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiverData);
        }

        // GET: Receivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiverData receiverData = db.ReceiverData.Find(id);
            if (receiverData == null)
            {
                return HttpNotFound();
            }
            return View(receiverData);
        }

        // POST: Receivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiverData receiverData = db.ReceiverData.Find(id);
            db.ReceiverData.Remove(receiverData);
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


        private static async Task RequsetToDonor(string toEmail, string fromEmail, string body)
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
