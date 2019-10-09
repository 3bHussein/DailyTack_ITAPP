using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

//
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class DailyLogTbsController : Controller
    {
        private ITDBEntities db = new ITDBEntities();

        // GET: DailyLogTbs
        public ActionResult Index(int Page=1)
        {
            return View(db.DailyLogTbs.ToList().OrderBy(a=>a.Id).ToPagedList(Page,8));

        }

        // GET: DailyLogTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLogTb dailyLogTb = db.DailyLogTbs.Find(id);
            if (dailyLogTb == null)
            {
                return HttpNotFound();
            }
            return View(dailyLogTb);
        }

        // GET: DailyLogTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyLogTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,DateOfDay,Satement")] DailyLogTb dailyLogTb)
        {
            if (ModelState.IsValid)
            {
                db.DailyLogTbs.Add(dailyLogTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailyLogTb);
        }

        // GET: DailyLogTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLogTb dailyLogTb = db.DailyLogTbs.Find(id);
            if (dailyLogTb == null)
            {
                return HttpNotFound();
            }
            return View(dailyLogTb);
        }

        // POST: DailyLogTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,DateOfDay,Satement")] DailyLogTb dailyLogTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyLogTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyLogTb);
        }

        // GET: DailyLogTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLogTb dailyLogTb = db.DailyLogTbs.Find(id);
            if (dailyLogTb == null)
            {
                return HttpNotFound();
            }
            return View(dailyLogTb);
        }

        // POST: DailyLogTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyLogTb dailyLogTb = db.DailyLogTbs.Find(id);
            db.DailyLogTbs.Remove(dailyLogTb);
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






        public ActionResult fullsearch(string search)
        {

            return View("fullsearch", db.DailyLogTbs.Where(a => a.Day.Contains(search)));
        }

        public ActionResult fullsearch1(string search1)
        {

            return View("fullsearch1", db.DailyLogTbs.Where(a => a.DateOfDay.ToString().Contains(search1)));
        }

    }
}
