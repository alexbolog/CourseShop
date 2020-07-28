using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.DAL
{
    public class CourseContext : IdentityDbContext<ApplicationUser>
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(e => e.Property(ep => ep.Price).HasColumnType("DECIMAL(5,2)"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
