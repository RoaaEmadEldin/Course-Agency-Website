using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Context;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class CourseController : Controller
    {
        CourseAgency db = new CourseAgency();

        [Route("/Courses")]
        public IActionResult GetAll()
        {
            var courses = db.Courses.Include(c => c.Department).ToList();
            return View(courses);
        }

        [Route("/Courses/{id}")]
        public IActionResult Details(int id)
        {
            var course = db.Courses.Include(c => c.Department).Include(c => c.Instuctors).FirstOrDefault(c => c.Id == id);
            return View(course);
        }

        [Route("/Courses/New")]

        public IActionResult New()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View();
        }

        [Route("/Courses/SaveNew")]

        [HttpPost]
        public IActionResult SaveNew(Course c)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("New", c);
        }

        [Route("/Courses/Update/{id}")]

        public IActionResult Update(int id)
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var course = db.Courses.Find(id);
            return View(course);
        }

        [Route("/Courses/SaveUpdate")]

        [HttpPost]
        public IActionResult SaveUpdate(Course c)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Update(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("Update", c);
        }

        [Route("/Courses/Delete/{id}")]

        public IActionResult Delete(int id)
        {
            var course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
