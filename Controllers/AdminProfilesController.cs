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
    public class AdminProfilesController : Controller
    {
        private ALMAL_FreelancerDBEntities db = new ALMAL_FreelancerDBEntities();

        // GET: AdminProfiles
        public ActionResult Index()
        {
            var tblAdminProfiles = db.tblAdminProfiles.Include(t => t.tblRoleConfig);
            return View(tblAdminProfiles.ToList());
        }

        // GET: AdminProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdminProfile tblAdminProfile = db.tblAdminProfiles.Find(id);
            if (tblAdminProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblAdminProfile);
        }

        // GET: AdminProfiles/Create
        public ActionResult Create()
        {
            ViewBag.RoleConfigID = new SelectList(db.tblRoleConfigs, "RoleConfigID", "Category");
            return View();
        }

        // POST: AdminProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminProfileID,RoleConfigID,FullName,UserName,Email,Tel,Password,IsOnline,IsBlocked")] tblAdminProfile tblAdminProfile)
        {
            if (ModelState.IsValid)
            {
                db.tblAdminProfiles.Add(tblAdminProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleConfigID = new SelectList(db.tblRoleConfigs, "RoleConfigID", "Category", tblAdminProfile.RoleConfigID);
            return View(tblAdminProfile);
        }

        // GET: AdminProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdminProfile tblAdminProfile = db.tblAdminProfiles.Find(id);
            if (tblAdminProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleConfigID = new SelectList(db.tblRoleConfigs, "RoleConfigID", "Category", tblAdminProfile.RoleConfigID);
            return View(tblAdminProfile);
        }

        // POST: AdminProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminProfileID,RoleConfigID,FullName,UserName,Email,Tel,Password,IsOnline,IsBlocked")] tblAdminProfile tblAdminProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAdminProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleConfigID = new SelectList(db.tblRoleConfigs, "RoleConfigID", "Category", tblAdminProfile.RoleConfigID);
            return View(tblAdminProfile);
        }

        // GET: AdminProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdminProfile tblAdminProfile = db.tblAdminProfiles.Find(id);
            if (tblAdminProfile == null)
            {
                return HttpNotFound();
            }
            return View(tblAdminProfile);
        }

        // POST: AdminProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAdminProfile tblAdminProfile = db.tblAdminProfiles.Find(id);
            db.tblAdminProfiles.Remove(tblAdminProfile);
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
