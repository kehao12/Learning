using Learning.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Models
{
    [Table("Lessons")]
    public class Lesson: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Video { get; set; }
        public string  Doccument { get; set; }

        [ForeignKey("CourseID")]
        public virtual IEnumerable<Course> Courses { get; set; }
        [ForeignKey("ParentID")]
        public virtual IEnumerable<Lesson> Lessons { get; set; }
    }
}
