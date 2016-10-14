﻿using System;
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
    public class DonationsController : Controller
    {
        private DFFEntities db = new DFFEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var donationData = db.DonationData.Include(d => d.DonorData);
            return View(donationData.ToList());
        }

        // GET: Donations/Details/5
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

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.DonorID = new SelectList(db.DonorData, "DonorID", "Name");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,DonorID,FoodType,Location,PickupTime,Picture")] DonationData donationData)
        {
            if (ModelState.IsValid)
            {
                db.DonationData.Add(donationData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorID = new SelectList(db.DonorData, "DonorID", "Name", donationData.DonorID);
            return View(donationData);
        }

        // GET: Donations/Edit/5
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
            ViewBag.DonorID = new SelectList(db.DonorData, "DonorID", "Name", donationData.DonorID);
            return View(donationData);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,DonorID,FoodType,Location,PickupTime,Picture")] DonationData donationData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorID = new SelectList(db.DonorData, "DonorID", "Name", donationData.DonorID);
            return View(donationData);
        }

        // GET: Donations/Delete/5
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

        // POST: Donations/Delete/5
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
    }
}