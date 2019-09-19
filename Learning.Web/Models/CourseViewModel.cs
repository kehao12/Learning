using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Models
{
    public class CourseViewModel
    {
        public int ID { get; set; }
     
        public string Name { get; set; }
       
        public string Alias { get; set; }
       
        public string Description { get; set; }

       
        public int CategoryID { get; set; }
       
        public string Image { get; set; }
       
        public decimal Price { get; set; }

        public int? ViewCount { get; set; }

        public virtual CourseCategoryViewModel CourseCategory { set; get; }

        public virtual IEnumerable<CourseTagViewModel> CourseTags { set; get; }
    }
}