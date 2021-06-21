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
    public class StudentReservedAppointments1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentReservedAppointments1
        public ActionResult Index()
        {
            return View(db.StudentReservedAppointments.ToList());
        }

        // GET: StudentReservedAppointments1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReservedAppointment studentReservedAppointment = db.StudentReservedAppointments.Find(id);
            if (studentReservedAppointment == null)
            {
                return HttpNotFound();
            }
            return View(studentReservedAppointment);
        }

        // GET: StudentReservedAppointments1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentReservedAppointments1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,studentID,studentName,StudentEmail,staffName,serviceName,Date,Time,status,isDone,availability,isVisibale,roleNumber,WorkingDaysTupe,Day,isDoneby,isCancelledby")] StudentReservedAppointment studentReservedAppointment)
        {
            if (ModelState.IsValid)
            {
                db.StudentReservedAppointments.Add(studentReservedAppointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentReservedAppointment);
        }

        // GET: StudentReservedAppointments1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReservedAppointment studentReservedAppointment = db.StudentReservedAppointments.Find(id);
            if (studentReservedAppointment == null)
            {
                return HttpNotFound();
            }
            return View(studentReservedAppointment);
        }

        // POST: StudentReservedAppointments1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,studentID,studentName,StudentEmail,staffName,serviceName,Date,Time,status,isDone,availability,isVisibale,roleNumber,WorkingDaysTupe,Day,isDoneby,isCancelledby")] StudentReservedAppointment studentReservedAppointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentReservedAppointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentReservedAppointment);
        }

        // GET: StudentReservedAppointments1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReservedAppointment studentReservedAppointment = db.StudentReservedAppointments.Find(id);
            if (studentReservedAppointment == null)
            {
                return HttpNotFound();
            }
            return View(studentReservedAppointment);
        }

        // POST: StudentReservedAppointments1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentReservedAppointment studentReservedAppointment = db.StudentReservedAppointments.Find(id);
            db.StudentReservedAppointments.Remove(studentReservedAppointment);
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
