using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<CourseViewModel> Courses { set; get; }
        public IEnumerable<CourseCategoryViewModel> CourseCategories { set; get; }
        public IEnumerable<CourseViewModel> LastestCourses{ set; get; }
        public IEnumerable<CourseViewModel> TopSaleCourses { set; get; }
    }
}