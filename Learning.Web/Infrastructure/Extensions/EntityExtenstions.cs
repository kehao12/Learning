using Learning.Model.Models;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Infrastructure.Extensions
{
    public static class EntityExtenstions
    {
        public static void UpdatepostCategory(this PostCategory postCategory,PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
         
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdateCourseCategory(this CourseCategory courseCategory, CourseCategoryViewModel courseCategoryVm)
        {
            courseCategory.ID = courseCategoryVm.ID;
            courseCategory.Name = courseCategoryVm.Name;
            courseCategory.Description = courseCategoryVm.Description;
            courseCategory.Alias = courseCategoryVm.Alias;
            courseCategory.ParentID = courseCategoryVm.ParentID;
            courseCategory.DisplayOrder = courseCategoryVm.DisplayOrder;
            

            courseCategory.CreatedDate = courseCategoryVm.CreatedDate;
            courseCategory.CreatedBy = courseCategoryVm.CreatedBy;
            courseCategory.UpdatedDate = courseCategoryVm.UpdatedDate;
            courseCategory.UpdatedBy = courseCategoryVm.UpdatedBy;

            courseCategory.Status = courseCategoryVm.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
     
            post.Status = postVm.Status;
        }

        public static void UpdateCourse(this Course course, CourseViewModel courseVm)
        {
            course.ID = courseVm.ID;
            course.Name = courseVm.Name;
            course.Description = courseVm.Description;
            course.Alias = courseVm.Alias;
            course.CategoryID = courseVm.CategoryID;
            course.Price = courseVm.Price;
            course.Image = courseVm.Image;

            course.ViewCount = courseVm.ViewCount;

            course.CreatedDate = courseVm.CreatedDate;
            course.CreatedBy = courseVm.CreatedBy;
            course.UpdatedDate = courseVm.UpdatedDate;
            course.UpdatedBy = courseVm.UpdatedBy;

            course.Status = courseVm.Status;
        }
    }
}