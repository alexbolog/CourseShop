using CourseShop.Core.Entities;
using CourseShop.Core.Entities.FSM;
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
        public DbSet<AppCourseList> AppLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CoursesInOrder> CoursesInOrder { get; set; }

        public DbSet<FSMTransition> FSMTransitions { get; set; }
        public DbSet<FSMCondition> FSMConditions { get; set; }
        public DbSet<FSMAction> FSMActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(e => e.Property(ep => ep.Price).HasColumnType("DECIMAL(5,2)"));
            modelBuilder.Entity<CoursePromotion>(e => e.Property(ep => ep.PromotionalPrice).HasColumnType("DECIMAL(5,2)"));
            modelBuilder.Entity<CourseReview>(e => e.Property(ep => ep.Rating).HasColumnType("DECIMAL(5,2)"));

            modelBuilder.Entity<CourseContributor>().HasKey(o => new { o.CourseId, o.CourseContributorId });
            modelBuilder.Entity<CourseInCategory>().HasKey(o => new { o.CourseId, o.CourseCategoryId });

            modelBuilder.Entity<CourseImage>().HasKey(o => new { o.CourseId, o.ImageIndex });

            modelBuilder.Entity<AppCourseList>().HasKey(o => new { o.CourseId, o.ApplicationUserId, o.CourseListTypeId });
            modelBuilder.Entity<AppCourseList>().Ignore(o => o.CourseListType);

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().Ignore(o => o.OrderStatus);
            modelBuilder.Entity<Order>().Ignore(o => o.Courses);
            modelBuilder.Entity<Order>(e => e.Property(ep => ep.TotalPrice).HasColumnType("DECIMAL(5,2)"));

            modelBuilder.Entity<CoursesInOrder>().HasKey(o => new { o.OrderId, o.CourseId });

            modelBuilder.Entity<FSMTransition>().Ignore(o => o.Actions);
            modelBuilder.Entity<FSMTransition>().Ignore(o => o.Conditions);

            modelBuilder.Entity<FSMCondition>().Ignore(o => o.ConditionType);
            modelBuilder.Entity<FSMAction>().Ignore(o => o.ActionType);

            base.OnModelCreating(modelBuilder);
        }
    }
}
