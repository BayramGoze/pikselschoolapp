using System;

namespace WebApplication1.ViewModels.Lesson
{
    public class CreateCourseViewModel
    {
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        public int InstructorId { get; set; }

    }
}