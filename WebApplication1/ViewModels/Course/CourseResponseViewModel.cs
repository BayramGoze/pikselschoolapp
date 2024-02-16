using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Course
{
    public class CourseResponseViewModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CourseName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? InstructorId { get; set; }

        public string InstructorName { get; set; }
    }
}