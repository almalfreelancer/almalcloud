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
    public class MissionTypesController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: MissionTypes
        public ActionResult Index()
        {
            var tblMissionTypes = db.tblMissionTypes.Include(t => t.tblMobilityConfig);
            return View(tblMissionTypes.ToList());
        }

        // GET: MissionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMissionType tblMissionType = db.tblMissionTypes.Find(id);
            if (tblMissionType == null)
            {
                return HttpNotFound();
            }
            return View(tblMissionType);
        }

        // GET: MissionTypes/Create
        public ActionResult Create()
        {
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category");
            return View();
        }

        // POST: MissionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionTypeID,MobilityConfigID,Subject,Description,Amount,IsActive,IsCompleted,EstimatedStartTime,EstimatedStopTime,StartDuration,StopDuration")] tblMissionType tblMissionType)
        {
            if (ModelState.IsValid)
            {
                db.tblMissionTypes.Add(tblMissionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblMissionType.MobilityConfigID);
            return View(tblMissionType);
        }

        // GET: MissionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMissionType tblMissionType = db.tblMissionTypes.Find(id);
            if (tblMissionType == null)
            {
                return HttpNotFound();
            }
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblMissionType.MobilityConfigID);
            return View(tblMissionType);
        }

        // POST: MissionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionTypeID,MobilityConfigID,Subject,Description,Amount,IsActive,IsCompleted,EstimatedStartTime,EstimatedStopTime,StartDuration,StopDuration")] tblMissionType tblMissionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMissionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MobilityConfigID = new SelectList(db.tblMobilityConfigs, "MobilityConfigID", "Category", tblMissionType.MobilityConfigID);
            return View(tblMissionType);
        }

        // GET: MissionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMissionType tblMissionType = db.tblMissionTypes.Find(id);
            if (tblMissionType == null)
            {
                return HttpNotFound();
            }
            return View(tblMissionType);
        }

        // POST: MissionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMissionType tblMissionType = db.tblMissionTypes.Find(id);
            db.tblMissionTypes.Remove(tblMissionType);
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
