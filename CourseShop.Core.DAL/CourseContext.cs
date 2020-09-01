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
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<CourseContributor> CourseContributors { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseInCategory> CoursesInCategories { get; set; }
        public DbSet<CoursePromotion> CoursePromotions { get; set; }
        public DbSet<CourseReview> CourseReviews { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(e => e.Property(ep => ep.Price).HasColumnType("DECIMAL(5,2)"));
            modelBuilder.Entity<CoursePromotion>(e => e.Property(ep => ep.PromotionalPrice).HasColumnType("DECIMAL(5,2)"));
            modelBuilder.Entity<CourseReview>(e => e.Property(ep => ep.Rating).HasColumnType("DECIMAL(5,2)"));

            modelBuilder.Entity<CourseContributor>().HasKey(o => new { o.CourseId, o.CourseContributorId });
            modelBuilder.Entity<CourseInCategory>().HasKey(o => new { o.CourseId, o.CourseCategoryId });

            modelBuilder.Entity<CourseImage>().HasKey(o => new { o.CourseId, o.ImageIndex });

            base.OnModelCreating(modelBuilder);
        }
    }
}
