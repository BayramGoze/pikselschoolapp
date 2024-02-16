using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Course
{
    public class UpdateInstructorViewModel
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
        public string InstructorExpert { get; set; }
        public string InstructorAge { get; set; }
    }
}