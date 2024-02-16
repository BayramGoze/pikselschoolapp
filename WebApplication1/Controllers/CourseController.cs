using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;
using WebApplication1.ViewModels.Lesson;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            using (AcademyContext dbContext = new AcademyContext())
            {                
                CourseViewModel vm = new CourseViewModel();
                vm.Courses = dbContext.Courses.Where(x => x.Deleted == false).Select(y => new CourseResponseViewModel
                {
                    
                    CourseName = y.CourseName,
                    Id = y.Id,
                    EndDate = y.EndDate,
                    StartDate = y.StartDate,
                    InstructorId = y.InstructorId,
                    InstructorName = y.InstructorId != null ?  (dbContext.Instructors.FirstOrDefault(a => a.Id == y.InstructorId).InstructorName ?? string.Empty) : string.Empty
                }).ToList();
                vm.Instructors = dbContext.Instructors.Where(x=>x.Deleted == false).ToList();
                return View(vm);              
            }
        }

        [HttpPost]
        public ActionResult CreateCourse(CreateCourseViewModel model)
        {
            //Create Lesson to db 
            using (AcademyContext context = new AcademyContext())
            {
                context.Courses.Add(new Courses
                {
                    CourseName = model.CourseName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreateDate = DateTime.Now,
                    InstructorId = model.InstructorId,
                });
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCourse(UpdateCourseViewModel model)
        {

            using (AcademyContext context = new AcademyContext())
            {
                var course = context.Courses.FirstOrDefault(x => x.Id == model.Id);
                if (course != null)
                {
                    course.CourseName = model.CourseName;
                    course.StartDate = model.StartDate;
                    course.EndDate= model.EndDate;
                    course.InstructorId = model.InstructorId; 
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public JsonResult DeleteCourse(int id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var course = context.Courses.FirstOrDefault(x => x.Id == id);
                if (course != null)
                {
                    course.Deleted = true;
                    context.Entry(course).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChangesAsync();
                }
            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCourse(int ID)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var course = context.Courses.FirstOrDefault(x => x.Id == ID);
                return Json(course, JsonRequestBehavior.AllowGet);
            }
        }
    }
}