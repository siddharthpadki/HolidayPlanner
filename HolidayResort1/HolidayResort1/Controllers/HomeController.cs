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
            //var records = db.SummerHolidayResortPlanner;

            return View(db.HolidayPlanners.ToList());
        }



        public ActionResult Edit(int? id)
        {
            var edit_entry = from d in db.HolidayPlanners
                             where d.HolidayPlannerID == id
                             select d;

            HolidayPlanner edit_entry1 = db.HolidayPlanners.Find(id);


            //query db for specific index
            return View(edit_entry1);
        }

        [HttpPost]
        public ActionResult Edit(HolidayPlanner holiday)
        {
            if (holiday.Images == null)
            {
                holiday.Images = "http://xinature.com/wp-content/uploads/2016/08/lakes-forest-lake-mountains-clear-italy-beautiful-calm-crystal-anterselva-summer-south-sky-tyrol-blue-sun-water-mountain-image.jpg";
            }
            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(holiday);
        }

        public ActionResult Details(int? id)
        {
            HolidayPlanner holiday = db.HolidayPlanners.Find(id);
            return View(holiday);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayPlanner holiday = db.HolidayPlanners.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            HolidayPlanner holiday = db.HolidayPlanners.Find(id);
            db.HolidayPlanners.Remove(holiday);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "HolidayPlannerID, Images, Country, Resort, Profile, Like, Dislike")] HolidayPlanner holiday)
        {
            if (holiday.Images == null)
            {
                holiday.Images = "http://xinature.com/wp-content/uploads/2016/08/lakes-forest-lake-mountains-clear-italy-beautiful-calm-crystal-anterselva-summer-south-sky-tyrol-blue-sun-water-mountain-image.jpg";
            }
            if (ModelState.IsValid)
            {
                db.HolidayPlanners.Add(holiday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(holiday);
        }

        public ActionResult Like(int id)
        {
            HolidayPlanner holiday = db.HolidayPlanners.Find(id);

            int currentLikes = holiday.Like;
            holiday.Like = currentLikes + 1;

            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Dislike(int? id)
        {
            HolidayPlanner holiday = db.HolidayPlanners.Find(id);

            int currentDislikes = holiday.Dislike;
            holiday.Dislike = currentDislikes + 1;

            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}