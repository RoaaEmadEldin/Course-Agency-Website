using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Context;
using MVC_Project.Models;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class TraineeController : Controller
    {
        CourseAgency db = new CourseAgency();

        [Route("/Trainees")]
        public IActionResult GetAll()
        {
            var trainees = db.Trainees.Include(t => t.Department).ToList();
            return View(trainees);
        }

        [Route("/Trainees/{id}")]
        public IActionResult Details(int id)
        {
            var trainee = db.Trainees.Include(t => t.Department).FirstOrDefault(t => t.Id == id);
            if (trainee != null)
            {
                var courseResults = db.CrsResults.Where(cr => cr.TraineeID == id).Include(cr => cr.Course).ToList();

                StudentWithCrsResultsVM tranieeDetails = new StudentWithCrsResultsVM();
                tranieeDetails.StudentImage = trainee.Image;
                tranieeDetails.StudentName = trainee.Name;
                tranieeDetails.DeptName = trainee.Department.Name;

                foreach (var cr in courseResults)
                {
                    var crsResVM = new CrsResultVM
                    {
                        CourseName = cr.Course.Name,
                        Degree = cr.Degree,
                        // MinDegree = cr.Course.MinDegreee
                        color = cr.Degree >= cr.Course.MinDegreee ? "green" : "red"
                    };

                    tranieeDetails.Courses.Add(crsResVM);

                }

                return View(tranieeDetails);
            }
            return View("Error", trainee);
        }

        [Route("/Trainees/New")]
        public IActionResult New()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View();
        }

        [Route("/Trainees/SaveNew")]
        [HttpPost]
        public IActionResult SaveNew(Trainee t)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(t);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("New", t);
        }

        [Route("/Trainees/Update/{id}")]
        public IActionResult Update(int id)
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var trainee = db.Trainees.Find(id);
            return View(trainee);
        }

        [Route("/Trainees/SaveUpdate")]
        [HttpPost]
        public IActionResult SaveUpdate(Trainee t)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Update(t);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("Update", t);
        }

        [Route("/Trainees/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

    }
}
