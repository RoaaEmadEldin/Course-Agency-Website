using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Context;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class DepartmentController : Controller
    {
        CourseAgency db = new CourseAgency();

        [Route("/Departments")]

        public IActionResult GetAll()
        {
            var depts = db.Departments.ToList();
            return View(depts);
        }

        [Route("/Departments/{id}")]
        public IActionResult Details(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.DeptID == id);
            return View(dept);
        }

        [Route("/Departments/New")]

        public IActionResult New()
        {
            return View();
        }

        [Route("/Departments/SaveNew")]

        [HttpPost]
        public IActionResult SaveNew(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("New", d);
        }

        [Route("/Departments/Update/{id}")]
        public IActionResult Update(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }

        [Route("/Departments/SaveUpdate")]
        [HttpPost]
        public IActionResult SaveUpdate(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Update(d);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Update", d);
        }

        [Route("/Departments/Delete/{id}")]

        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
