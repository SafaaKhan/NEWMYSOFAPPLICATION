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
    public class NormalTransactions1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NormalTransactions1
        public ActionResult Index()
        {
            return View(db.NormalTransactions.ToList());
        }

        // GET: NormalTransactions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormalTransaction normalTransaction = db.NormalTransactions.Find(id);
            if (normalTransaction == null)
            {
                return HttpNotFound();
            }
            return View(normalTransaction);
        }

        // GET: NormalTransactions1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NormalTransactions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lbContinuing,EntIdC,EntNameC,EntEmailC,lbGraduate,EntIdG,EntNameG,EntContinuingSt,EntEmailG,EntGraduateSt,FilePath,EntcontinuosTransaction,EntGraduateTransaction,GraduatedORContinuing,Status,FileExtension")] NormalTransaction normalTransaction)
        {
            if (ModelState.IsValid)
            {
                db.NormalTransactions.Add(normalTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(normalTransaction);
        }

        // GET: NormalTransactions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormalTransaction normalTransaction = db.NormalTransactions.Find(id);
            if (normalTransaction == null)
            {
                return HttpNotFound();
            }
            return View(normalTransaction);
        }

        // POST: NormalTransactions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,lbContinuing,EntIdC,EntNameC,EntEmailC,lbGraduate,EntIdG,EntNameG,EntContinuingSt,EntEmailG,EntGraduateSt,FilePath,EntcontinuosTransaction,EntGraduateTransaction,GraduatedORContinuing,Status,FileExtension")] NormalTransaction normalTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normalTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(normalTransaction);
        }

        // GET: NormalTransactions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormalTransaction normalTransaction = db.NormalTransactions.Find(id);
            if (normalTransaction == null)
            {
                return HttpNotFound();
            }
            return View(normalTransaction);
        }

        // POST: NormalTransactions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NormalTransaction normalTransaction = db.NormalTransactions.Find(id);
            db.NormalTransactions.Remove(normalTransaction);
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
