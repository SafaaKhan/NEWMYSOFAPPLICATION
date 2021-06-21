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
    public class RegistrationForms1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegistrationForms1
        public ActionResult Index()
        {
            return View(db.RegistrationForms.ToList());
        }

        // GET: RegistrationForms1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // GET: RegistrationForms1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationForms1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EntSemesters,EntCenter,EntCivilID,EntArabicName,EntEnglishName,EntArabicSecond,EntEnglishSecond,EntArabicThird,EntEnglishThird,EntArabicFamily,EntEnglishFamily,EntMale,EntFemale,EntGregorian,EntHijri,EntBirthDay,EntBirthPlace,EntNationality,EntEXPDateID,EntIDType,EntPhoneNumH,EntMobileNum,EntEmail,EntArea,EntCity,EntArStreet,EntEnStreet,EntArBuilding,EntEnBuilding,EntArFloor,EntEnFloor,EntArtSience,EntCuorses,EntCertificateType,EntAverage,EntGraduateYear,EntCountry,EntEnglishLevel,EntQyasGrade,EntTofelTest,EntProgram,EntTrack,EntHaveAjob,EntKnowingOfAOU,EntHaveDisAbility,EntContactName,EntPhoneNumEm,FilePath,Status")] RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationForms.Add(registrationForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrationForm);
        }

        // GET: RegistrationForms1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // POST: RegistrationForms1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EntSemesters,EntCenter,EntCivilID,EntArabicName,EntEnglishName,EntArabicSecond,EntEnglishSecond,EntArabicThird,EntEnglishThird,EntArabicFamily,EntEnglishFamily,EntMale,EntFemale,EntGregorian,EntHijri,EntBirthDay,EntBirthPlace,EntNationality,EntEXPDateID,EntIDType,EntPhoneNumH,EntMobileNum,EntEmail,EntArea,EntCity,EntArStreet,EntEnStreet,EntArBuilding,EntEnBuilding,EntArFloor,EntEnFloor,EntArtSience,EntCuorses,EntCertificateType,EntAverage,EntGraduateYear,EntCountry,EntEnglishLevel,EntQyasGrade,EntTofelTest,EntProgram,EntTrack,EntHaveAjob,EntKnowingOfAOU,EntHaveDisAbility,EntContactName,EntPhoneNumEm,FilePath,Status")] RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrationForm);
        }

        // GET: RegistrationForms1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            if (registrationForm == null)
            {
                return HttpNotFound();
            }
            return View(registrationForm);
        }

        // POST: RegistrationForms1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationForm registrationForm = db.RegistrationForms.Find(id);
            db.RegistrationForms.Remove(registrationForm);
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
