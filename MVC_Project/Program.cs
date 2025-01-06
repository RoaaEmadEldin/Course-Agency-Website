namespace MVC_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.MapControllerRoute(
                name: "Departments",
                pattern: "/Departments",
                defaults: new { controller = "Department", action = "GetAll" }

                );

            app.MapControllerRoute(
                name: "Instructors",
                pattern: "/Instructors",
                defaults: new { controller = "Instructor", action = "GetAll" }

                );

            app.MapControllerRoute(
                name: "Courses",
                pattern: "/Courses",
                defaults: new { controller = "Course", action = "GetAll" }

                );

            app.MapControllerRoute(
                name: "Trainees",
                pattern: "/Trainees",
                defaults: new { controller = "Trainee", action = "GetAll" }

                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
