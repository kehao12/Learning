using Learning.Model.Abstract;
using Learning.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Learning.Data
{
    public class LearningDbContext: IdentityDbContext<ApplicationUser>
    {
        public LearningDbContext(): base("LearningConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<Error> Errors { get; set; }

        public static LearningDbContext Create()
        {
            return new LearningDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
