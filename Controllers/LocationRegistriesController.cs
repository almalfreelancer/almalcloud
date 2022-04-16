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
    public class LocationRegistriesController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: LocationRegistries
        public ActionResult Index()
        {
            return View(db.tblLocationRegistries.ToList());
        }

        // GET: LocationRegistries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationRegistry tblLocationRegistry = db.tblLocationRegistries.Find(id);
            if (tblLocationRegistry == null)
            {
                return HttpNotFound();
            }
            return View(tblLocationRegistry);
        }

        // GET: LocationRegistries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationRegistries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationRegistryID,Country,Town,Residence")] tblLocationRegistry tblLocationRegistry)
        {
            if (ModelState.IsValid)
            {
                db.tblLocationRegistries.Add(tblLocationRegistry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLocationRegistry);
        }

        // GET: LocationRegistries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationRegistry tblLocationRegistry = db.tblLocationRegistries.Find(id);
            if (tblLocationRegistry == null)
            {
                return HttpNotFound();
            }
            return View(tblLocationRegistry);
        }

        // POST: LocationRegistries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationRegistryID,Country,Town,Residence")] tblLocationRegistry tblLocationRegistry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLocationRegistry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLocationRegistry);
        }

        // GET: LocationRegistries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocationRegistry tblLocationRegistry = db.tblLocationRegistries.Find(id);
            if (tblLocationRegistry == null)
            {
                return HttpNotFound();
            }
            return View(tblLocationRegistry);
        }

        // POST: LocationRegistries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLocationRegistry tblLocationRegistry = db.tblLocationRegistries.Find(id);
            db.tblLocationRegistries.Remove(tblLocationRegistry);
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
