using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Course { Id = 1, Name = "Microsoft Web Development"});
            modelBuilder.Entity<Department>().HasData(new Course { Id = 2, Name = "Microsoft Desktop Development"});

            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Microsoft Web Services", NumberOfClasses = 32 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "ASP.NET Core MVC", NumberOfClasses = 44 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "Introduction to Web Development", NumberOfClasses = 32 });

            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, FirstName = "John", LastName = "Doe", DepartmentId = 1});
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, FirstName = "Mira", LastName = "Doe", DepartmentId = 1 });
        }
    } 
}
