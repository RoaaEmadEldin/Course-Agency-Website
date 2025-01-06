using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [DisplayName("Trainee Name")]
        [MinLength(3, ErrorMessage = "Name must be more than 2 characters!")]
        [MaxLength(20, ErrorMessage = "Name must be less than 21 characters")]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string? Image { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }
        public int? Grade { get; set; }



        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int? DeptId { get; set; }
        public Department? Department { get; set; }

        public ICollection<CrsResult>? CrsResults { get; set; }

    }
}
