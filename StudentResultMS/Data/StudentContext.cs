using Microsoft.EntityFrameworkCore;
using StudentResultMS.Models;

namespace StudentResultMS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}