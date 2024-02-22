using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;
using WebApplication1.ViewModels.Login;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            using (AcademyContext context = new AcademyContext())
            {
                var userlogin = context.Users.FirstOrDefault(x => x.UserName == model.Email && x.Password==model.Password && x.IsActive==true);
                if (userlogin != null)
                {
                   return RedirectToAction("Index", "Student");
                }
                return RedirectToAction("Index");

            }          
        }

    }
  
}