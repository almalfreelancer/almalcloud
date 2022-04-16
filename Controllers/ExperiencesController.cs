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
    public class ExperiencesController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: Experiences
        public ActionResult Index()
        {
            var tblExperiences = db.tblExperiences.Include(t => t.tblSkillConfig).Include(t => t.tblUserProfile);
            return View(tblExperiences.ToList());
        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperience tblExperience = db.tblExperiences.Find(id);
            if (tblExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblExperience);
        }

        // GET: Experiences/Create
        public ActionResult Create()
        {
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category");
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName");
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExperienceID,UserProfileID,SkillConfigID,YearCount,Description,RegDate")] tblExperience tblExperience)
        {
            if (ModelState.IsValid)
            {
                db.tblExperiences.Add(tblExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblExperience.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblExperience.UserProfileID);
            return View(tblExperience);
        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperience tblExperience = db.tblExperiences.Find(id);
            if (tblExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblExperience.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblExperience.UserProfileID);
            return View(tblExperience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExperienceID,UserProfileID,SkillConfigID,YearCount,Description,RegDate")] tblExperience tblExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillConfigID = new SelectList(db.tblSkillConfigs, "SkillConfigID", "Category", tblExperience.SkillConfigID);
            ViewBag.UserProfileID = new SelectList(db.tblUserProfiles, "UserProfileID", "FullName", tblExperience.UserProfileID);
            return View(tblExperience);
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperience tblExperience = db.tblExperiences.Find(id);
            if (tblExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblExperience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExperience tblExperience = db.tblExperiences.Find(id);
            db.tblExperiences.Remove(tblExperience);
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
