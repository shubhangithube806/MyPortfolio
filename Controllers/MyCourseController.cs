using MyPortfolio.CommonFiles;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class MyCourseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Course> courseList = db.Course.Where(m => m.PortfolioUserId == portfolioUserId)
                                               .OrderBy(m => m.StartDate).ToList();

            return View(courseList);
        }

        // GET: MyCourse
        [HttpGet]
        public ActionResult SaveCourse(Guid? courseId)
        {
            Course course = new Course();

            if (courseId != null)
            {
                course = db.Course.Where(m => m.CourseId == courseId).FirstOrDefault();
            }
            return View(course);
        }


        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.CourseId == Guid.Empty)
                {
                    //Add Course
                    course.CourseId = Guid.NewGuid();
                    course.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Course.Add(course);
                    db.SaveChanges();
                }
                else
                {
                    //Edit Course
                    db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyCourse");
            }

            return View(course);
        }

        public ActionResult DeleteCourse(Guid courseId)
        {
            Course course = db.Course.Where(e => e.CourseId == courseId).FirstOrDefault();

            if (course != null)
            {
                db.Course.Remove(course);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyCourse");
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