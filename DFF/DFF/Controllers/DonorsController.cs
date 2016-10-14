using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DFF.Models;

namespace DFF.Controllers
{
    public class DonorsController : Controller
    {
        private DFFEntities db = new DFFEntities();

        // GET: Donors
        public ActionResult Index()
        {
            return View(db.DonorData.ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorData donorData = db.DonorData.Find(id);
            if (donorData == null)
            {
                return HttpNotFound();
            }
            return View(donorData);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonorID,Name,Email,Phone")] DonorData donorData)
        {
            if (ModelState.IsValid)
            {
                db.DonorData.Add(donorData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donorData);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorData donorData = db.DonorData.Find(id);
            if (donorData == null)
            {
                return HttpNotFound();
            }
            return View(donorData);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorID,Name,Email,Phone")] DonorData donorData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donorData);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorData donorData = db.DonorData.Find(id);
            if (donorData == null)
            {
                return HttpNotFound();
            }
            return View(donorData);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorData donorData = db.DonorData.Find(id);
            db.DonorData.Remove(donorData);
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
