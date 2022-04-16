using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALMAL_Freelancer.Models;

namespace ALMAL_Freelancer.Controllers
{
    public class AvailabilityConfigsController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: AvailabilityConfigs
        public ActionResult Index()
        {
            return View(db.tblAvailabilityConfigs.ToList());
        }

        // GET: AvailabilityConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAvailabilityConfig tblAvailabilityConfig = db.tblAvailabilityConfigs.Find(id);
            if (tblAvailabilityConfig == null)
            {
                return HttpNotFound();
            }
            return View(tblAvailabilityConfig);
        }

        // GET: AvailabilityConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailabilityConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvailabilityConfigID,StartTime,StopTime,IsActive")] tblAvailabilityConfig tblAvailabilityConfig)
        {
            if (ModelState.IsValid)
            {
                db.tblAvailabilityConfigs.Add(tblAvailabilityConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAvailabilityConfig);
        }

        // GET: AvailabilityConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAvailabilityConfig tblAvailabilityConfig = db.tblAvailabilityConfigs.Find(id);
            if (tblAvailabilityConfig == null)
            {
                return HttpNotFound();
            }
            return View(tblAvailabilityConfig);
        }

        // POST: AvailabilityConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvailabilityConfigID,StartTime,StopTime,IsActive")] tblAvailabilityConfig tblAvailabilityConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAvailabilityConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAvailabilityConfig);
        }

        // GET: AvailabilityConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAvailabilityConfig tblAvailabilityConfig = db.tblAvailabilityConfigs.Find(id);
            if (tblAvailabilityConfig == null)
            {
                return HttpNotFound();
            }
            return View(tblAvailabilityConfig);
        }

        // POST: AvailabilityConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAvailabilityConfig tblAvailabilityConfig = db.tblAvailabilityConfigs.Find(id);
            db.tblAvailabilityConfigs.Remove(tblAvailabilityConfig);
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
