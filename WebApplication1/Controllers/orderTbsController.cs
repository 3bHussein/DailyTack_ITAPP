using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class orderTbsController : Controller
    {
        private ITDBEntities db = new ITDBEntities();

        // GET: orderTbs
        public ActionResult Index()
        {
            return View(db.orderTbs.ToList());
        }

        // GET: orderTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderTb orderTb = db.orderTbs.Find(id);
            if (orderTb == null)
            {
                return HttpNotFound();
            }
            return View(orderTb);
        }

        // GET: orderTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: orderTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OrderN,quantity,Day")] orderTb orderTb)
        {
            if (ModelState.IsValid)
            {
                db.orderTbs.Add(orderTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderTb);
        }

        // GET: orderTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderTb orderTb = db.orderTbs.Find(id);
            if (orderTb == null)
            {
                return HttpNotFound();
            }
            return View(orderTb);
        }

        // POST: orderTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OrderN,quantity,Day")] orderTb orderTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderTb);
        }

        // GET: orderTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderTb orderTb = db.orderTbs.Find(id);
            if (orderTb == null)
            {
                return HttpNotFound();
            }
            return View(orderTb);
        }

        // POST: orderTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderTb orderTb = db.orderTbs.Find(id);
            db.orderTbs.Remove(orderTb);
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
