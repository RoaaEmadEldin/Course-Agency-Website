using Microsoft.AspNetCore.Mvc;
using MVC_Project.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Course
    {
        public int Id { get; set; }

        [DisplayName("Course Name")]
        [MinLength(2, ErrorMessage = "Name must be more than 1 character!")]
        [MaxLength(20, ErrorMessage = "Name must be less than 21 characters")]
        [StringLength(20)]
        [UniqueCourse]
        public string Name { get; set; }

        public int Degree { get; set; }

        [Remote("minDegreeValid", "CustomValidations", AdditionalFields = nameof(Degree), ErrorMessage = "Minimum Degree must be Smaller than the Course Degree!")]
        [DisplayName("Minimum Degree")]
        public int MinDegreee {  get; set; }

        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int? DeptID { get; set; }
        public Department? Department { get; set; }


        public ICollection<Instuctor>? Instuctors { get; set; }
        public ICollection<CrsResult>? CrsResults { get; set; }
    }
}
