using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Context;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class InstructorController : Controller
    {
        CourseAgency db = new CourseAgency();

        [Route("/Instructors")]
        public IActionResult GetAll()
        {
            var instructors = db.Instuctors.Include(i => i.Course).Include(i => i.Department).ToList(); 
            return View(instructors);
        }

        [Route("/Instructors/{id}")]
        public IActionResult Details(int id)
        {
            var inst = db.Instuctors.Include(i => i.Course).Include(i => i.Department).FirstOrDefault(i => i.InstID == id);
            return View(inst);
        }

        [Route("/Instructors/New")]
        public IActionResult New()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;

            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;
            return View();
        }

        [Route("/Instructors/SaveNew")]
        [HttpPost]
        public IActionResult SaveNew(Instuctor i)
        {
            if (ModelState.IsValid)
            {
                db.Instuctors.Add(i);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;

            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;
            return View("New", i);
        }

        [Route("/Instructors/Update/{id}")]
        public IActionResult Update(int id)
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;

            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;

            var inst = db.Instuctors.Find(id);
            return View(inst);
        }

        [Route("/Instructors/SaveUpdate")]
        [HttpPost]
        public IActionResult SaveUpdate(Instuctor i)
        {
            if (ModelState.IsValid)
            {
                db.Instuctors.Update(i);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;

            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;

            return View("Update", i);
        }

        [Route("/Instructors/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var inst = db.Instuctors.Find(id);
            db.Instuctors.Remove(inst);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
