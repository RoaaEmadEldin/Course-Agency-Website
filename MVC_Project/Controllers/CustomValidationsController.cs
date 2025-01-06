using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class CustomValidationsController : Controller
    {
        public IActionResult minDegreeValid(int Degree, int MinDegreee)
        {
            if (MinDegreee < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
