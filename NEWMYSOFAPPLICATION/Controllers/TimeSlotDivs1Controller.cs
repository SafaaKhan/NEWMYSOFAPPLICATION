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
    public class TimeSlotDivs1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeSlotDivs1
        public ActionResult Index()
        {
            return View(db.TimeSlotDivs.ToList());
        }

        // GET: TimeSlotDivs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotDiv timeSlotDiv = db.TimeSlotDivs.Find(id);
            if (timeSlotDiv == null)
            {
                return HttpNotFound();
            }
            return View(timeSlotDiv);
        }

        // GET: TimeSlotDivs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSlotDivs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,time,staffID,roleNumber,availability,service,startDate,endDate,dateType,WorkingDaysTupe,Day")] TimeSlotDiv timeSlotDiv)
        {
            if (ModelState.IsValid)
            {
                db.TimeSlotDivs.Add(timeSlotDiv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSlotDiv);
        }

        // GET: TimeSlotDivs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotDiv timeSlotDiv = db.TimeSlotDivs.Find(id);
            if (timeSlotDiv == null)
            {
                return HttpNotFound();
            }
            return View(timeSlotDiv);
        }

        // POST: TimeSlotDivs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,time,staffID,roleNumber,availability,service,startDate,endDate,dateType,WorkingDaysTupe,Day")] TimeSlotDiv timeSlotDiv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSlotDiv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSlotDiv);
        }

        // GET: TimeSlotDivs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlotDiv timeSlotDiv = db.TimeSlotDivs.Find(id);
            if (timeSlotDiv == null)
            {
                return HttpNotFound();
            }
            return View(timeSlotDiv);
        }

        // POST: TimeSlotDivs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlotDiv timeSlotDiv = db.TimeSlotDivs.Find(id);
            db.TimeSlotDivs.Remove(timeSlotDiv);
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
