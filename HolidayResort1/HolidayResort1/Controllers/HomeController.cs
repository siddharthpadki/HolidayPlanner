using HolidayResort1.Context;
using HolidayResort1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HolidayResort1.Controllers
{
    public class HomeController : Controller
    {
        private HolidayDBContext db = new HolidayDBContext();
        // GET: Home
        public ActionResult Index()
        {
            var records = db.SummerHolidayResortPlanner;

            return View(records.ToList());
        }



        public ActionResult Edit(int? id)
        {
            var edit_entry = from d in db.SummerHolidayResortPlanner
                             where d.HolidayPlannerID == id
                             select d;

            HolidayPlanner edit_entry1 = db.SummerHolidayResortPlanner.Find(id);


            //query db for specific index
            return View(edit_entry1);
        }

        [HttpPost]
        public ActionResult Edit(HolidayPlanner holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(holiday);
            }
        }

        public ActionResult Details(int? id)
        {
            HolidayPlanner holiday = db.SummerHolidayResortPlanner.Find(id);
            return View(holiday);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayPlanner holiday = db.SummerHolidayResortPlanner.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            HolidayPlanner holiday = db.SummerHolidayResortPlanner.Find(id);
            db.SummerHolidayResortPlanner.Remove(holiday);
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HolidayPlanner holiday)
        {
            if (ModelState.IsValid)
            {
                db.SummerHolidayResortPlanner.Add(holiday);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(holiday);
            }

        }



    }
}