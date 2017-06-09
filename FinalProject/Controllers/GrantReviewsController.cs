using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject2.Models;

namespace FinalProject2.Controllers
{
    public class GrantReviewsController : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();

        // GET: GrantReviews
        public ActionResult Index()
        {
            var grantReviews = db.GrantReviews.Include(g => g.Employee).Include(g => g.GrantRequest);
            return View(grantReviews.ToList());
        }

        // GET: GrantReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantReview grantReview = db.GrantReviews.Find(id);
            if (grantReview == null)
            {
                return HttpNotFound();
            }
            return View(grantReview);
        }

        // GET: GrantReviews/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeKey");
            ViewBag.GrantRequestKey = new SelectList(db.GrantRequests, "GrantRequestKey", "GrantRequestExplanation");
            return View();
        }

        // POST: GrantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrantReviewKey,GrantReviewDate,GrantRequestKey,GrantRequestStatus,GrantAllocationAmount,EmployeeKey")] GrantReview grantReview)
        {
            if (ModelState.IsValid)
            {
                db.GrantReviews.Add(grantReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeKey", grantReview.EmployeeKey);
            ViewBag.GrantRequestKey = new SelectList(db.GrantRequests, "GrantRequestKey", "GrantRequestExplanation", grantReview.GrantRequestKey);
            return View(grantReview);
        }

        // GET: GrantReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantReview grantReview = db.GrantReviews.Find(id);
            if (grantReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeKey", grantReview.EmployeeKey);
            ViewBag.GrantRequestKey = new SelectList(db.GrantRequests, "GrantRequestKey", "GrantRequestExplanation", grantReview.GrantRequestKey);
            return View(grantReview);
        }

        // POST: GrantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrantReviewKey,GrantReviewDate,GrantRequestKey,GrantRequestStatus,GrantAllocationAmount,EmployeeKey")] GrantReview grantReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeKey", grantReview.EmployeeKey);
            ViewBag.GrantRequestKey = new SelectList(db.GrantRequests, "GrantRequestKey", "GrantRequestExplanation", grantReview.GrantRequestKey);
            return View(grantReview);
        }

        // GET: GrantReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantReview grantReview = db.GrantReviews.Find(id);
            if (grantReview == null)
            {
                return HttpNotFound();
            }
            return View(grantReview);
        }

        // POST: GrantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantReview grantReview = db.GrantReviews.Find(id);
            db.GrantReviews.Remove(grantReview);
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
