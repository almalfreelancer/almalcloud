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
    public class FeaturedProfilesController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: FeaturedProfiles
        public ActionResult Index()
        {
            var tblFeaturedProfiles = db.tblFeaturedProfiles.Include(t => t.tblMedia).Include(t => t.tblMissionType).Include(t => t.tblUserProfile);
            return View(tblFeaturedProfiles.ToList());
        }

        // GET: FeaturedProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeaturedProfile tblFeaturedProfile = db.tblFeaturedProfiles.Find(id);
            if (tblFeaturedProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblFeaturedProfile);
        }

        // GET: FeaturedProfiles/Create
        public ActionResult Create()
        {
            ViewBag.MediaID = new SelectList(db.tblMedias, "MediaID", "ContentUrl");
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject");
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName");
            return View();
        }

        // POST: FeaturedProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeaturedProfileID,UserProfileID,MissionTypeID,MediaID")] tblFeaturedProfile tblFeaturedProfile)
        {
            if (ModelState.IsValid)
            {
                db.tblFeaturedProfiles.Add(tblFeaturedProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MediaID = new SelectList(db.tblMedias, "MediaID", "ContentUrl", tblFeaturedProfile.MediaID);
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblFeaturedProfile.MissionTypeID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblFeaturedProfile.UserProfileID);
            return View(tblFeaturedProfile);
        }

        // GET: FeaturedProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeaturedProfile tblFeaturedProfile = db.tblFeaturedProfiles.Find(id);
            if (tblFeaturedProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediaID = new SelectList(db.tblMedias, "MediaID", "ContentUrl", tblFeaturedProfile.MediaID);
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblFeaturedProfile.MissionTypeID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblFeaturedProfile.UserProfileID);
            return View(tblFeaturedProfile);
        }

        // POST: FeaturedProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeaturedProfileID,UserProfileID,MissionTypeID,MediaID")] tblFeaturedProfile tblFeaturedProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFeaturedProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MediaID = new SelectList(db.tblMedias, "MediaID", "ContentUrl", tblFeaturedProfile.MediaID);
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblFeaturedProfile.MissionTypeID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblFeaturedProfile.UserProfileID);
            return View(tblFeaturedProfile);
        }

        // GET: FeaturedProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeaturedProfile tblFeaturedProfile = db.tblFeaturedProfiles.Find(id);
            if (tblFeaturedProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblFeaturedProfile);
        }

        // POST: FeaturedProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFeaturedProfile tblFeaturedProfile = db.tblFeaturedProfiles.Find(id);
            db.tblFeaturedProfiles.Remove(tblFeaturedProfile);
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
