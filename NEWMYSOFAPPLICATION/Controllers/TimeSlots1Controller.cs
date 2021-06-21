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
    public class TimeSlots1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeSlots1
        public ActionResult Index()
        {
            return View(db.TimeSlots.ToList());
        }

        // GET: TimeSlots1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // GET: TimeSlots1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSlots1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,staffID,startTime,endtTime,startDate,endDate,dateType,slots,service,WorkingDaysTupe,Day,breakstartTime,breakendtTime,disableStartDate,disableEndDate,disablestatus,disableMSG")] TimeSlots timeSlots)
        {
            if (ModelState.IsValid)
            {
                db.TimeSlots.Add(timeSlots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSlots);
        }

        // GET: TimeSlots1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // POST: TimeSlots1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,staffID,startTime,endtTime,startDate,endDate,dateType,slots,service,WorkingDaysTupe,Day,breakstartTime,breakendtTime,disableStartDate,disableEndDate,disablestatus,disableMSG")] TimeSlots timeSlots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSlots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSlots);
        }

        // GET: TimeSlots1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // POST: TimeSlots1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            db.TimeSlots.Remove(timeSlots);
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
