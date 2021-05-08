using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lms_core.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalHours { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public ICollection<Matriculation> Matriculations { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
