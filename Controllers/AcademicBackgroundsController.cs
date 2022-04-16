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
    public class AcademicBackgroundsController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: AcademicBackgrounds
        public ActionResult Index()
        {
            var tblAcademicBackgrounds = db.tblAcademicBackgrounds.Include(t => t.tblUserProfile);
            return View(tblAcademicBackgrounds.ToList());
        }

        // GET: AcademicBackgrounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcademicBackground tblAcademicBackground = db.tblAcademicBackgrounds.Find(id);
            if (tblAcademicBackground == null)
            {
                return HttpNotFound();
            }
            return View(tblAcademicBackground);
        }

        // GET: AcademicBackgrounds/Create
        public ActionResult Create()
        {
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName");
            return View();
        }

        // POST: AcademicBackgrounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcademicBackgroundID,UserProfileID,School,Department,StartDate,StopDate,IsGraduated,Description")] tblAcademicBackground tblAcademicBackground)
        {
            if (ModelState.IsValid)
            {
                db.tblAcademicBackgrounds.Add(tblAcademicBackground);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAcademicBackground.UserProfileID);
            return View(tblAcademicBackground);
        }

        // GET: AcademicBackgrounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcademicBackground tblAcademicBackground = db.tblAcademicBackgrounds.Find(id);
            if (tblAcademicBackground == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAcademicBackground.UserProfileID);
            return View(tblAcademicBackground);
        }

        // POST: AcademicBackgrounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcademicBackgroundID,UserProfileID,School,Department,StartDate,StopDate,IsGraduated,Description")] tblAcademicBackground tblAcademicBackground)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAcademicBackground).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAcademicBackground.UserProfileID);
            return View(tblAcademicBackground);
        }

        // GET: AcademicBackgrounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcademicBackground tblAcademicBackground = db.tblAcademicBackgrounds.Find(id);
            if (tblAcademicBackground == null)
            {
                return HttpNotFound();
            }
            return View(tblAcademicBackground);
        }

        // POST: AcademicBackgrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAcademicBackground tblAcademicBackground = db.tblAcademicBackgrounds.Find(id);
            db.tblAcademicBackgrounds.Remove(tblAcademicBackground);
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
