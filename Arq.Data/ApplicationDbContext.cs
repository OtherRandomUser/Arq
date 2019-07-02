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
            modelBuilder.Entity<CoRequirement>()
                .HasOne(c => c.Requirement)
                .WithMany(s => s.CoRequirements)
                .HasForeignKey(c => c.RequirementId);

            modelBuilder.Entity<CoRequirement>()
                .HasOne(c => c.Subject)
                .WithMany(s => s.CoRequiredBy)
                .HasForeignKey(c => c.SubjectId);

            modelBuilder.Entity<Equivalence>()
                .HasOne(e => e.Equivalent)
                .WithMany(s => s.Equivalences)
                .HasForeignKey(e => e.EquivalentId);

            modelBuilder.Entity<Equivalence>()
                .HasOne(e => e.Subject)
                .WithMany(s => s.EquivaleTo)
                .HasForeignKey(c => c.SubjectId);

            modelBuilder.Entity<Prerequisite>()
                .HasOne(p => p.Requirement)
                .WithMany(s => s.Prerequisites)
                .HasForeignKey(p => p.RequirementId);

            modelBuilder.Entity<Prerequisite>()
                .HasOne(p => p.Subject)
                .WithMany(s => s.RequiredBy)
                .HasForeignKey(c => c.SubjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}