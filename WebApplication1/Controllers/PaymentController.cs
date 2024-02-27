using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;
using WebApplication1.ViewModels.Payment;

namespace WebApplication1.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            using (AcademyContext dbContext = new AcademyContext())
            {
                PaymentResponseViewModel vm = new PaymentResponseViewModel();
                vm.Payments = dbContext.Payments.Where(x => x.Deleted == false).Select(y => new PaymentViewModel
                {
                    Id = y.Id,
                    CourseId = y.CourseId,
                    Installments = y.Installments,
                    CourseName = y.CourseId != null ? dbContext.Courses.FirstOrDefault(x => x.Id == y.CourseId).CourseName : string.Empty,
                    PaymentDate = y.PaymentDate,
                    StudentName = y.StudentsId != null ? dbContext.Students.FirstOrDefault(x => x.ID == y.StudentsId).StudentName : string.Empty,
                    StudentsId = y.StudentsId,
                    Amount=y.Amount
                }).ToList();
                vm.Students = dbContext.Students.Where(x => x.Deleted == false).Select(y => new StudentResponseViewModel
                {
                    ID = y.ID,
                    StudentName = y.StudentName
                }).ToList();
                return View(vm);
            }
        }
        //public string GetPaymentName(int paymentType)
        //{
        //    switch (paymentType)
        //    {
        //        case 0:
        //            return "Peşin";
        //        case 1:
        //            return "Kredi Kartı";
        //        case 2:
        //            return "Taksit";
        //        default:
        //            return "-";
        //    }
        //}

        [HttpPost]
        public ActionResult CreatePayment(PaymentViewModel model)
        {
            using (AcademyContext context = new AcademyContext())
            {
                context.Payments.Add(new Payments
                {
                   Amount=model.Amount,
                   PaymentDate=model.PaymentDate,
                   StudentsId=model.StudentsId,
                   CourseId=model.CourseId,

                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetPayment(int ID)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var payment = context.Payments.FirstOrDefault(x => x.Id == ID);
                return Json(payment, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdatePayment( UpdatePaymentViewModel model)
        {

            using (AcademyContext context = new AcademyContext())
            {
                var payment = context.Payments.FirstOrDefault(x => x.Id == model.Id);
                if (payment != null)
                {

                    payment.Amount = model.Amount;
                    payment.CourseId = model.CourseId;
                    payment.StudentsId = model.StudentsId;
                    payment.PaymentDate= model.PaymentDate;
                    payment.Installments = model.Installments;

                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeletePayment(int Id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var student = context.Payments.FirstOrDefault(x => x.Id == Id);
                if (student != null)
                {
                    student.Deleted = true;
                    context.SaveChanges();
                }
                return Json("Başarılı", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetCourseByStudentId(int studentId)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var student = context.Students.FirstOrDefault(x => x.ID == studentId);
                if(student != null)
                {
                    int? courseId = student.CourseId;
                    var course = context.Courses.Where(x => x.Id == courseId).ToList();                  
                    return Json(course, JsonRequestBehavior.AllowGet);
                }
                return Json(new List<Courses>(),JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}