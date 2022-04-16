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
    public class AlertsController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: Alerts
        public ActionResult Index()
        {
            var tblAlerts = db.tblAlerts.Include(t => t.tblMissionType).Include(t => t.tblMobilityConfig).Include(t => t.tblSkillConfig).Include(t => t.tblUserProfile);
            return View(tblAlerts.ToList());
        }

        // GET: Alerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlert tblAlert = db.tblAlerts.Find(id);
            if (tblAlert == null)
            {
                return HttpNotFound();
            }
            return View(tblAlert);
        }

        // GET: Alerts/Create
        public ActionResult Create()
        {
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject");
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category");
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category");
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName");
            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlertID,SkillConfigID,UserProfileID,MobilityConfigID,MissionTypeID,IsRead")] tblAlert tblAlert)
        {
            if (ModelState.IsValid)
            {
                db.tblAlerts.Add(tblAlert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblAlert.MissionTypeID);
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblAlert.MobilityConfigID);
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblAlert.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAlert.UserProfileID);
            return View(tblAlert);
        }

        // GET: Alerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlert tblAlert = db.tblAlerts.Find(id);
            if (tblAlert == null)
            {
                return HttpNotFound();
            }
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblAlert.MissionTypeID);
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblAlert.MobilityConfigID);
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblAlert.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAlert.UserProfileID);
            return View(tblAlert);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlertID,SkillConfigID,UserProfileID,MobilityConfigID,MissionTypeID,IsRead")] tblAlert tblAlert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAlert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MissionTypeID = new SelectList(db.tblMissionTypes, "MissionTypeID", "Subject", tblAlert.MissionTypeID);
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblAlert.MobilityConfigID);
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblAlert.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblAlert.UserProfileID);
            return View(tblAlert);
        }

        // GET: Alerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAlert tblAlert = db.tblAlerts.Find(id);
            if (tblAlert == null)
            {
                return HttpNotFound();
            }
            return View(tblAlert);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAlert tblAlert = db.tblAlerts.Find(id);
            db.tblAlerts.Remove(tblAlert);
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
