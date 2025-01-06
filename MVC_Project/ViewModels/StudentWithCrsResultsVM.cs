namespace MVC_Project.ViewModels
{
    public class StudentWithCrsResultsVM
    {
        public string? StudentImage { get; set; }
        public string StudentName { get; set; }
        public string DeptName { get; set; }
        public List<CrsResultVM> Courses { get; set; } = new List<CrsResultVM>();
    }
}
