using Arq.Domain;
using Microsoft.EntityFrameworkCore;

namespace Arq.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CoRequirement> CoRequirements { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Equivalence> Equivalences { get; set; }
        public DbSet<Prerequisite> Prerequisites { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}