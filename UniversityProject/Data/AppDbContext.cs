using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Models;

namespace UniversityProject.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }


        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<UniversityManager> UniversityManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>()
           .HasKey(f => new { f.StudentId, f.UniversityId });

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Student)
                .WithMany(s => s.FollowedUniversities)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.University)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UniversityId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define the relationship for Enrollments table
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define the relationship for Reactions table
            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Reactions)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Scholarship>()
               .Property(s => s.Amount)
               .HasColumnType("decimal(18, 2)"); // Specify precision and scale here


            // Define the many-to-many relationship between Student and University for FollowedUniversities
            modelBuilder.Entity<Follow>()
                .HasKey(f => new { f.StudentId, f.UniversityId });

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Student)
                .WithMany(s => s.FollowedUniversities)
                .HasForeignKey(f => f.StudentId);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.University)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UniversityId);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Departments)
                .WithMany(d => d.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorDepartment",
                    j => j.HasOne<Department>().WithMany().HasForeignKey("DepartmentsDepartmentId").OnDelete(DeleteBehavior.NoAction),
                    j => j.HasOne<Instructor>().WithMany().HasForeignKey("InstructorsId").OnDelete(DeleteBehavior.NoAction)
                );

            modelBuilder.Entity<UniversityManager>()
                .HasOne(um => um.University)
                .WithMany(u => u.Managers)
                .HasForeignKey(um => um.UniversityId);


            base.OnModelCreating(modelBuilder);

        }

    }
}
