using System;
using System.ComponentModel.DataAnnotations;

namespace lms_core.Models.CourseViewModels
{
    public class MatriculationDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}