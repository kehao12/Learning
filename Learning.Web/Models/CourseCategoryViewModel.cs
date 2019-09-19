using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Models
{
    public class CourseCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }



        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public bool Status { set; get; }

        public virtual IEnumerable<CourseViewModel> Courses { set; get; }
    }
}