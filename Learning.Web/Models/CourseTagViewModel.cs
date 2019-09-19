using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Models
{
    public class CourseTagViewModel
    {
        public int CourseID { set; get; }

        public string TagID { set; get; }

        public virtual CourseViewModel Course { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}