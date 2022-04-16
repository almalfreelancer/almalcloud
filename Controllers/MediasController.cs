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
    public class MediasController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: Medias
        public ActionResult Index()
        {
            var tblMedias = db.tblMedias.Include(t => t.tblUserProfile);
            return View(tblMedias.ToList());
        }

        // GET: Medias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedia tblMedia = db.tblMedias.Find(id);
            if (tblMedia == null)
            {
                return HttpNotFound();
            }
            return View(tblMedia);
        }

        // GET: Medias/Create
        public ActionResult Create()
        {
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName");
            return View();
        }

        // POST: Medias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaID,UserProfileID,ContentUrl,Type,IsBlocked")] tblMedia tblMedia)
        {
            if (ModelState.IsValid)
            {
                db.tblMedias.Add(tblMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblMedia.UserProfileID);
            return View(tblMedia);
        }

        // GET: Medias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedia tblMedia = db.tblMedias.Find(id);
            if (tblMedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblMedia.UserProfileID);
            return View(tblMedia);
        }

        // POST: Medias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaID,UserProfileID,ContentUrl,Type,IsBlocked")] tblMedia tblMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblMedia.UserProfileID);
            return View(tblMedia);
        }

        // GET: Medias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMedia tblMedia = db.tblMedias.Find(id);
            if (tblMedia == null)
            {
                return HttpNotFound();
            }
            return View(tblMedia);
        }

        // POST: Medias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMedia tblMedia = db.tblMedias.Find(id);
            db.tblMedias.Remove(tblMedia);
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
