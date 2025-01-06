using MVC_Project.Context;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Validators
{
    public class UniqueDepartmentAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseAgency db = new CourseAgency();
            var name = value as string;

            var deptID = (int?)validationContext.ObjectType.GetProperty("DeptID")?.GetValue(validationContext.ObjectInstance);
            var exists = db.Departments.Any(c => c.Name == name && c.DeptID != deptID);
            if (exists)
            {
                return new ValidationResult("Department Name Already Exists!!");
            }
            return ValidationResult.Success;
        }
    }
}
