using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningStudent.Models;
using System.Net;
using System.Data.Entity;

namespace TrainningStudent.Controllers
{
    public class TrainerActionController : Controller
    {
        private Model1 db = new Model1();
        // GET: TrainerAction

        public new ActionResult Profile()
        {
            var userName = User.Identity.Name;
            var trainer = (from t in db.Trainers
                           where t.TrainerName.Equals(userName)
                           select t).FirstOrDefault();

            return View(trainer);

        }

        public ActionResult MyTopic()
        {
            var userName = User.Identity.Name;
            var Courses = (from e in db.Courses
                           where e.Topics.Any(m => m.Trainer.TrainerName.Equals(userName))
                           select e);
            return View(Courses.ToList());
        }

        [Authorize(Roles = "Trainer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainer")]
        public ActionResult Edit([Bind(Include = "TrainerID, TrainerName, Type, WorkPlace, Phone, Email,CourseID")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            return View(trainer);
        }
    }
}