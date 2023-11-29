using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDataProject.Models;

namespace StudentDataProject.Controllers
{
    public class StudentMarksController : Controller
    {
        private StudentDataEntities db = new StudentDataEntities();

        // GET: StudentMarks
        public ActionResult Index()
        {
            return View(db.StudentMarks.ToList());
        }

        // GET: StudentMarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMark studentMark = db.StudentMarks.Find(id);
            if (studentMark == null)
            {
                return HttpNotFound();
            }
            return View(studentMark);
        }

        // GET: StudentMarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentMarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Subject,Marks")] StudentMark studentMark)
        {
            if (ModelState.IsValid)
            {
                db.StudentMarks.Add(studentMark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentMark);
        }

        // GET: StudentMarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMark studentMark = db.StudentMarks.Find(id);
            if (studentMark == null)
            {
                return HttpNotFound();
            }
            return View(studentMark);
        }

        // POST: StudentMarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Subject,Marks")] StudentMark studentMark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentMark);
        }

        // GET: StudentMarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMark studentMark = db.StudentMarks.Find(id);
            if (studentMark == null)
            {
                return HttpNotFound();
            }
            return View(studentMark);
        }

        // POST: StudentMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentMark studentMark = db.StudentMarks.Find(id);
            db.StudentMarks.Remove(studentMark);
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
