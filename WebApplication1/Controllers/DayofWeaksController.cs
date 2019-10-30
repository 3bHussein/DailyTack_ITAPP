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
    public class DayofWeaksController : Controller
    {
        private ITDBEntities db = new ITDBEntities();

        // GET: DayofWeaks
        public ActionResult Index()
        {
            return View(db.DayofWeaks.ToList());
        }

        // GET: DayofWeaks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayofWeak dayofWeak = db.DayofWeaks.Find(id);
            if (dayofWeak == null)
            {
                return HttpNotFound();
            }
            return View(dayofWeak);
        }

        // GET: DayofWeaks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayofWeaks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day")] DayofWeak dayofWeak)
        {
            if (ModelState.IsValid)
            {
                db.DayofWeaks.Add(dayofWeak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayofWeak);
        }

        // GET: DayofWeaks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayofWeak dayofWeak = db.DayofWeaks.Find(id);
            if (dayofWeak == null)
            {
                return HttpNotFound();
            }
            return View(dayofWeak);
        }

        // POST: DayofWeaks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day")] DayofWeak dayofWeak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayofWeak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayofWeak);
        }

        // GET: DayofWeaks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayofWeak dayofWeak = db.DayofWeaks.Find(id);
            if (dayofWeak == null)
            {
                return HttpNotFound();
            }
            return View(dayofWeak);
        }

        // POST: DayofWeaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayofWeak dayofWeak = db.DayofWeaks.Find(id);
            db.DayofWeaks.Remove(dayofWeak);
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
