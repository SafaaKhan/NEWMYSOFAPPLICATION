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
    public class MemberVerifyOnlies1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MemberVerifyOnlies1
        public ActionResult Index()
        {
            return View(db.MemberVerifyOnlies.ToList());
        }

        // GET: MemberVerifyOnlies1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberVerifyOnly memberVerifyOnly = db.MemberVerifyOnlies.Find(id);
            if (memberVerifyOnly == null)
            {
                return HttpNotFound();
            }
            return View(memberVerifyOnly);
        }

        // GET: MemberVerifyOnlies1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberVerifyOnlies1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Membertype")] MemberVerifyOnly memberVerifyOnly)
        {
            if (ModelState.IsValid)
            {
                db.MemberVerifyOnlies.Add(memberVerifyOnly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberVerifyOnly);
        }

        // GET: MemberVerifyOnlies1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberVerifyOnly memberVerifyOnly = db.MemberVerifyOnlies.Find(id);
            if (memberVerifyOnly == null)
            {
                return HttpNotFound();
            }
            return View(memberVerifyOnly);
        }

        // POST: MemberVerifyOnlies1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Membertype")] MemberVerifyOnly memberVerifyOnly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberVerifyOnly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberVerifyOnly);
        }

        // GET: MemberVerifyOnlies1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberVerifyOnly memberVerifyOnly = db.MemberVerifyOnlies.Find(id);
            if (memberVerifyOnly == null)
            {
                return HttpNotFound();
            }
            return View(memberVerifyOnly);
        }

        // POST: MemberVerifyOnlies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MemberVerifyOnly memberVerifyOnly = db.MemberVerifyOnlies.Find(id);
            db.MemberVerifyOnlies.Remove(memberVerifyOnly);
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
