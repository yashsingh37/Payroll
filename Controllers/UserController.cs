using PayRoll_Practies_Exam_2.Bal;
using PayRoll_Practies_Exam_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll_Practies_Exam_2.Controllers
{
    public class UserController : Controller
    {
        UserHelper uh = new UserHelper();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tblUser user)
        {
            uh.Register(user);
            return RedirectToAction("Login", "User");
        }

        public bool EmailExists(string email)
        {
            return uh.EmailExists(email);
        }

        public bool ValidatePassword(string password)
        {
            return uh.ValidatePassword(password);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblLogin user)
        {
            if (uh.Login(user))
            {
                return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction("Login", "User");
        }

    }
}