using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XpressKuponXpressKupon.Data;
using XpressKuponXpressKupon.Models;

namespace XpressKuponXpressKupon.Controllers
{
    public class RewardPointsController : Controller
    {
        private XpressKuponXpressKuponContext db = new XpressKuponXpressKuponContext();

        // GET: RewardPoints
        public ActionResult Index()
        {
            return View(db.RewardPoints.ToList());
        }

        // GET: RewardPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RewardPoint rewardPoint = db.RewardPoints.Find(id);
            if (rewardPoint == null)
            {
                return HttpNotFound();
            }
            return View(rewardPoint);
        }

        // GET: RewardPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RewardPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Points,PointsHeld,TransactionTime,StoreId")] RewardPoint rewardPoint)
        {
            if (ModelState.IsValid)
            {
                db.RewardPoints.Add(rewardPoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rewardPoint);
        }

        // GET: RewardPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RewardPoint rewardPoint = db.RewardPoints.Find(id);
            if (rewardPoint == null)
            {
                return HttpNotFound();
            }
            return View(rewardPoint);
        }

        // POST: RewardPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Points,PointsHeld,TransactionTime,StoreId")] RewardPoint rewardPoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rewardPoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rewardPoint);
        }

        // GET: RewardPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RewardPoint rewardPoint = db.RewardPoints.Find(id);
            if (rewardPoint == null)
            {
                return HttpNotFound();
            }
            return View(rewardPoint);
        }

        // POST: RewardPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RewardPoint rewardPoint = db.RewardPoints.Find(id);
            db.RewardPoints.Remove(rewardPoint);
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
