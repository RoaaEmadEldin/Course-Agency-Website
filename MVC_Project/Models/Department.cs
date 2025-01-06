using MVC_Project.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }

        [DisplayName("Department Name")]
        [MinLength(2, ErrorMessage = "Name must be more than 1 character!")]
        [MaxLength(20, ErrorMessage = "Name must be less than 21 characters")]
        [StringLength(20)]
        [UniqueDepartment]
        public string Name { get; set; }

        [StringLength(20)]
        public string? Manager { get; set; }

        public ICollection<Instuctor>? Instuctors { get; set; }
        public ICollection<Trainee>? Trainees { get; set; }
        public ICollection<Course>? Courses { get; set; }


    }
}
