using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (AcademyContext dbContext = new AcademyContext())
            {
                StudentViewModel vm = new StudentViewModel();
                vm.Students = dbContext.Students.Where(x => x.Deleted == false).Select(y => new StudentResponseViewModel
                {
                    StudentName = y.StudentName,
                    RecordDate = y.RecordDate,
                    ID = y.ID,
                    CourseAmount = y.CourseAmount,
                    Telephone = y.Telephone,
                    Adress = y.Adress,
                    Education = y.Education,
                    PaymentDay = y.PaymentDay,
                    PaymentType = y.PaymentType,
                    InstalmentCount = y.InstalmentCount,
                    Birthday = y.Birthday,
                    IdentityNumber = y.IdentityNumber,
                    Email = y.Email,
                    CourseId = y.CourseId,
                    CourseName = y.CourseId != null ? dbContext.Courses.FirstOrDefault(x => x.Id == y.CourseId).CourseName : string.Empty
                }).ToList();
                if (vm.Students.Any())
                {
                    vm.Students.ForEach((student) =>
                    {
                        student.PaymentName = GetPaymentName(student.PaymentType ?? -1);
                    });
                }
                vm.Courses = dbContext.Courses.Where(x => x.Deleted == false).ToList();
                return View(vm);
            }

        }

        public string GetPaymentName(int paymentType)
        {
            switch (paymentType)
            {
                case 0:
                    return "Peşin";
                case 1:
                    return "Kredi Kartı";
                case 2:
                    return "Taksit";
                default:
                    return "-";
            }
        }

        [HttpPost]
        public ActionResult CreateStudent(CreateStudentViewModel model)
        {
            using (AcademyContext context = new AcademyContext())
            {
                context.Students.Add(new Students
                {
                    StudentName = model.StudentName,
                    IdentityNumber = model.IdentityNumber,
                    Email = model.Email,
                    CourseId = model.CourseId,
                    CourseAmount = model.CourseAmount,
                    Telephone = model.Telephone,
                    Education = model.Education,
                    PaymentDay = model.PaymentDay,
                    PaymentType = model.PaymentType,
                    Birthday = model.Birthday,
                    InstalmentCount = model.InstalmentCount,
                    Adress = model.Adress

                });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetStudent(int ID)
        {
            using (AcademyContext context = new AcademyContext())
            {
                var student = context.Students.FirstOrDefault(x => x.ID == ID);
                return Json(student,JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateStudent(UpdateStudentViewModel model)
        {

            using (AcademyContext context = new AcademyContext())
            {
                var student = context.Students.FirstOrDefault(x => x.ID == model.ID);
                if(student != null)
                {
                    student.Adress = model.Adress;
                    student.StudentName = model.StudentName;
                    student.IdentityNumber = model.IdentityNumber;
                    student.Email = model.Email;
                    student.CourseId = model.CourseId;
                    student.CourseAmount = model.CourseAmount;
                    student.Telephone = model.Telephone;
                    student.Education = model.Education;
                    student.PaymentDay = model.PaymentDay;
                    student.PaymentType = model.PaymentType;
                    student.Birthday = model.Birthday;
                    student.InstalmentCount = model.InstalmentCount;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteStudent(int Id)
        {
            using(AcademyContext context=new AcademyContext())
            {
                var student = context.Students.FirstOrDefault(x => x.ID ==Id);
                if (student!=null)
                {
                    student.Deleted = true;
                    context.SaveChanges();
                }
                return Json("Başarılı", JsonRequestBehavior.AllowGet);
            }
        }
       
    }
}