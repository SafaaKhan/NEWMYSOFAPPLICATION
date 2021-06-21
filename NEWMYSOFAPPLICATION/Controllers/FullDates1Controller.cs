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
    public class FullDates1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FullDates1
        public ActionResult Index()
        {
            return View(db.FullDates.ToList());
        }

        // GET: FullDates1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDates fullDates = db.FullDates.Find(id);
            if (fullDates == null)
            {
                return HttpNotFound();
            }
            return View(fullDates);
        }

        // GET: FullDates1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FullDates1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,date,staffName")] FullDates fullDates)
        {
            if (ModelState.IsValid)
            {
                db.FullDates.Add(fullDates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fullDates);
        }

        // GET: FullDates1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDates fullDates = db.FullDates.Find(id);
            if (fullDates == null)
            {
                return HttpNotFound();
            }
            return View(fullDates);
        }

        // POST: FullDates1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,date,staffName")] FullDates fullDates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullDates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fullDates);
        }

        // GET: FullDates1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDates fullDates = db.FullDates.Find(id);
            if (fullDates == null)
            {
                return HttpNotFound();
            }
            return View(fullDates);
        }

        // POST: FullDates1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullDates fullDates = db.FullDates.Find(id);
            db.FullDates.Remove(fullDates);
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
