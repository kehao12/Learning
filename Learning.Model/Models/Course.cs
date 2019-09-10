using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Models
{
    [Table("Courses")]
    class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CourseCategory CourseCategory { get; set; }
       

        public string Image { get; set; }
        public decimal Price { get; set; }
       



    }
}
