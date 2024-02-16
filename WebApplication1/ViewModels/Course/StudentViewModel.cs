using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels.Course
{
    public class StudentViewModel
    {
        public List<StudentResponseViewModel>Students { get; set; }
        public List<Courses>Courses { get; set; }
    }
}