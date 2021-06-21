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
    public class RegisterMembers1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterMembers1
        public ActionResult Index()
        {
            return View(db.RegisterMembers.ToList());
        }

        // GET: RegisterMembers1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterMember registerMember = db.RegisterMembers.Find(id);
            if (registerMember == null)
            {
                return HttpNotFound();
            }
            return View(registerMember);
        }

        // GET: RegisterMembers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterMembers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,MemberType,StaffService,StaffDepartment")] RegisterMember registerMember)
        {
            if (ModelState.IsValid)
            {
                db.RegisterMembers.Add(registerMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerMember);
        }

        // GET: RegisterMembers1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterMember registerMember = db.RegisterMembers.Find(id);
            if (registerMember == null)
            {
                return HttpNotFound();
            }
            return View(registerMember);
        }

        // POST: RegisterMembers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password,ConfirmPassword,MemberType,StaffService,StaffDepartment")] RegisterMember registerMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerMember);
        }

        // GET: RegisterMembers1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterMember registerMember = db.RegisterMembers.Find(id);
            if (registerMember == null)
            {
                return HttpNotFound();
            }
            return View(registerMember);
        }

        // POST: RegisterMembers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RegisterMember registerMember = db.RegisterMembers.Find(id);
            db.RegisterMembers.Remove(registerMember);
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
