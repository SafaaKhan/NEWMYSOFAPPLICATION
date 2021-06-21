using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEWMYSOFAPPLICATION.Models;

namespace NEWMYSOFAPPLICATION.Controllers
{
    public class ServicesOfStaffs1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServicesOfStaffs1
        public ActionResult Index()
        {
            return View(db.ServicesOfStaffs.ToList());
        }

        // GET: ServicesOfStaffs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOfStaffs servicesOfStaffs = db.ServicesOfStaffs.Find(id);
            if (servicesOfStaffs == null)
            {
                return HttpNotFound();
            }
            return View(servicesOfStaffs);
        }

        // GET: ServicesOfStaffs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesOfStaffs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,staffName,staffID,staffServices")] ServicesOfStaffs servicesOfStaffs)
        {
            if (ModelState.IsValid)
            {
                db.ServicesOfStaffs.Add(servicesOfStaffs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicesOfStaffs);
        }

        // GET: ServicesOfStaffs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOfStaffs servicesOfStaffs = db.ServicesOfStaffs.Find(id);
            if (servicesOfStaffs == null)
            {
                return HttpNotFound();
            }
            return View(servicesOfStaffs);
        }

        // POST: ServicesOfStaffs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,staffName,staffID,staffServices")] ServicesOfStaffs servicesOfStaffs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicesOfStaffs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicesOfStaffs);
        }

        // GET: ServicesOfStaffs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesOfStaffs servicesOfStaffs = db.ServicesOfStaffs.Find(id);
            if (servicesOfStaffs == null)
            {
                return HttpNotFound();
            }
            return View(servicesOfStaffs);
        }

        // POST: ServicesOfStaffs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesOfStaffs servicesOfStaffs = db.ServicesOfStaffs.Find(id);
            db.ServicesOfStaffs.Remove(servicesOfStaffs);
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
