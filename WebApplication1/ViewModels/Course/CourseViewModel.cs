using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.ViewModels.Course
{
    public class CourseViewModel
    {
        public List<CourseResponseViewModel> Courses { get; set;}
        public List<Instructors> Instructors { get; set;}

    }
}