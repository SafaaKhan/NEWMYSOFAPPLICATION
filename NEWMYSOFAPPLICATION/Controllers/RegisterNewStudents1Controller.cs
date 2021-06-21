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
    public class RegisterNewStudents1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterNewStudents1
        public ActionResult Index()
        {
            return View(db.RegisterNewStudents.ToList());
        }

        // GET: RegisterNewStudents1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterNewStudent registerNewStudent = db.RegisterNewStudents.Find(id);
            if (registerNewStudent == null)
            {
                return HttpNotFound();
            }
            return View(registerNewStudent);
        }

        // GET: RegisterNewStudents1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterNewStudents1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Semesters,AdmissionCenter,CivilId,FirstName,SecondName,ThirdName,FamilyName,Gender,DateofBirthG,DateofBirthH,IDType,PlaceOfBirth,Nationality,DateExpirationCiviSecurityCard,MyPHomePhoneNumber,PersonalEmail,MobilePhone,Area,City,StreetEng,BuildingEng,FloorEng,StreetAR,BuildingAr,FloorAR,Program,Track,HaveJob,KindDisability,KindDisabilitySpecify,KnowAOU,ContactNameEng,PhoneNumberEng,ContactNameAR,PhoneNumberAR,Confirm")] RegisterNewStudent registerNewStudent)
        {
            if (ModelState.IsValid)
            {
                db.RegisterNewStudents.Add(registerNewStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerNewStudent);
        }

        // GET: RegisterNewStudents1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterNewStudent registerNewStudent = db.RegisterNewStudents.Find(id);
            if (registerNewStudent == null)
            {
                return HttpNotFound();
            }
            return View(registerNewStudent);
        }

        // POST: RegisterNewStudents1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Semesters,AdmissionCenter,CivilId,FirstName,SecondName,ThirdName,FamilyName,Gender,DateofBirthG,DateofBirthH,IDType,PlaceOfBirth,Nationality,DateExpirationCiviSecurityCard,MyPHomePhoneNumber,PersonalEmail,MobilePhone,Area,City,StreetEng,BuildingEng,FloorEng,StreetAR,BuildingAr,FloorAR,Program,Track,HaveJob,KindDisability,KindDisabilitySpecify,KnowAOU,ContactNameEng,PhoneNumberEng,ContactNameAR,PhoneNumberAR,Confirm")] RegisterNewStudent registerNewStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerNewStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerNewStudent);
        }

        // GET: RegisterNewStudents1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterNewStudent registerNewStudent = db.RegisterNewStudents.Find(id);
            if (registerNewStudent == null)
            {
                return HttpNotFound();
            }
            return View(registerNewStudent);
        }

        // POST: RegisterNewStudents1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterNewStudent registerNewStudent = db.RegisterNewStudents.Find(id);
            db.RegisterNewStudents.Remove(registerNewStudent);
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
