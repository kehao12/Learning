namespace Learning.Data.Migrations
{
    using Learning.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Learning.Data.LearningDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Learning.Data.LearningDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            CreateSlide(context);

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new LearningDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new LearningDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(Learning.Data.LearningDbContext context)
        {
            if (context.CourseCategories.Count() == 0)
            {
                List<CourseCategory> listProductCategory = new List<CourseCategory>()
            {
                new CourseCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new CourseCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new CourseCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new CourseCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.CourseCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        private void CreateSlide(LearningDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="Assets/client/img/banner/banner1.jpg",
                       },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="Assets/client/img/banner/banner1.jpg",
                    },
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}
