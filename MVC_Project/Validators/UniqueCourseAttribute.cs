using MVC_Project.Context;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Validators
{
    public class UniqueCourseAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseAgency db = new CourseAgency();
            var name = value as string;

            var courseID = (int?)validationContext.ObjectType.GetProperty("Id")?.GetValue(validationContext.ObjectInstance);
            var exists = db.Courses.Any(c => c.Name == name && c.Id !=  courseID);
            if (exists)
            {
                return new ValidationResult("Course Name Already Exists!!");
            }
            return ValidationResult.Success;
        }
    }
}
