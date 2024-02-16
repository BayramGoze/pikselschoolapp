using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;
using WebApplication1.ViewModels.Lesson;

namespace WebApplication1.Controllers
{
    public class InstructorsController : Controller
    {
        // GET: Instructors
        public ActionResult Index()
        {         
            using (AcademyContext dbContext = new AcademyContext())
            {
                InstructorViewModel viewModel = new InstructorViewModel();
                viewModel.Instructors = dbContext.Instructors.Where(x => x.Deleted == false).Select(y => new InstructorResponsiveViewModel
                {
                    InstructorName = y.InstructorName,
                    InstructorAge=y.InstructorAge,
                    InstructorExpert = y.InstructorExpert,                
                    Id = y.Id,
                 
                }).ToList();
                return View(viewModel);
            }


        }
        [HttpPost]
        public ActionResult CreateInstructor(CreateInstructorViewModel model)
        {
            //Create Instructor to db 
            using (AcademyContext context = new AcademyContext())
            {
                context.Instructors.Add(new Instructors
                {
                    InstructorName = model.InstructorName,
                    InstructorExpert = model.InstructorExpert,
                    InstructorAge = model.InstructorAge.ToString(),
                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateInstructor(UpdateInstructorViewModel model)
        {

            using (AcademyContext context = new AcademyContext())
            {
                var instructor = context.Instructors.FirstOrDefault(x => x.Id == model.Id);
                if (instructor != null)
                {
                    instructor.InstructorName = model.InstructorName;
                    instructor.InstructorExpert = model.InstructorExpert;
                    instructor.InstructorAge = model.InstructorAge.ToString();
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetInstructor(int ID)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var instructor = context.Instructors.FirstOrDefault(x => x.Id == ID);
                return Json(instructor, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult DeleteInstructor( int ID)
        {
            using (AcademyContext context =new AcademyContext())
            {
                var instructor =context.Instructors.FirstOrDefault(x=>x.Id == ID);
                if (instructor != null)
                {
                    instructor.Deleted = true;
                    context.SaveChanges();
                }
                return Json("Başarılı", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
