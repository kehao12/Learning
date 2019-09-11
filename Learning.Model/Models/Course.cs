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
    [Table("Courses")]
    class Course: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CourseCategory CourseCategory { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int? ViewCount { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }




    }
}
