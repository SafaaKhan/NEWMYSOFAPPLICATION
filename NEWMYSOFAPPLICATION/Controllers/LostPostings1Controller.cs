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
    public class LostPostings1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LostPostings1
        public ActionResult Index()
        {
            return View(db.LostPostings.ToList());
        }

        // GET: LostPostings1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPosting lostPosting = db.LostPostings.Find(id);
            if (lostPosting == null)
            {
                return HttpNotFound();
            }
            return View(lostPosting);
        }

        // GET: LostPostings1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LostPostings1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ResponsibleName,Information,Date")] LostPosting lostPosting)
        {
            if (ModelState.IsValid)
            {
                db.LostPostings.Add(lostPosting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lostPosting);
        }

        // GET: LostPostings1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPosting lostPosting = db.LostPostings.Find(id);
            if (lostPosting == null)
            {
                return HttpNotFound();
            }
            return View(lostPosting);
        }

        // POST: LostPostings1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ResponsibleName,Information,Date")] LostPosting lostPosting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostPosting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lostPosting);
        }

        // GET: LostPostings1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPosting lostPosting = db.LostPostings.Find(id);
            if (lostPosting == null)
            {
                return HttpNotFound();
            }
            return View(lostPosting);
        }

        // POST: LostPostings1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LostPosting lostPosting = db.LostPostings.Find(id);
            db.LostPostings.Remove(lostPosting);
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
