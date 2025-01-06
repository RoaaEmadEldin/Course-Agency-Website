using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Instuctor
    {
        [Key]
        public int InstID {  get; set; }

        [DisplayName("Instructor Name")]
        [MinLength(3, ErrorMessage = "Name must be more than 2 characters!")]
        [MaxLength(20, ErrorMessage = "Name must be less than 21 characters!")]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? Image {  get; set; } 

        [Range(5000, 15000, ErrorMessage = "Salary must be between 5000 and 15000")]
        public int? Salary { get; set; }
        
        [StringLength(50)]
        public string? Address { get; set; }


        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int? DeptId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        [DisplayName("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
