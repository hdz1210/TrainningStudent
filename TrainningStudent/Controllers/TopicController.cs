using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using TrainningStudent.Models;
using System.Data.Entity;
using System.Data;

namespace TrainningStudent.Controllers
{
   
    public class TopicController : Controller
    {
        private Model1 db = new Model1();
        // GET: Topic
        public ActionResult Index()
        {
            var topic = db.Topics.Include(t => t.Course).Include(t => t.Trainer);
            return View(topic.ToList());
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Topics/Create
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName");
            return View();
        }

        // POST: Topics/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult Create([Bind(Include = "TopicID,TopicName,CourseID,TrainerID,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", topic.CourseID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", topic.TrainerID);
            return View(topic);
        }

        // GET: Topics/Edit/5
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", topic.CourseID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", topic.TrainerID);
            return View(topic);
        }
        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult Edit([Bind(Include = "TopicID,TopicName,CourseID,TrainerID,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", topic.CourseID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", topic.TrainerID);
            return View(topic);
        }

        // GET: Topics/Delete/5
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainer, Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
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