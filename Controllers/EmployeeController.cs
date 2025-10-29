using PayRoll_Practies_Exam_2.Bal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayRoll_Practies_Exam_2.Models;

namespace PayRoll_Practies_Exam_2.Controllers
{
    public class EmployeeController : Controller
    {
        CategoryHelper ch = new CategoryHelper();
        EmployeeHelper eh = new EmployeeHelper();
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            List<EmployeModel> employee = eh.GetAll();
            return View(employee);
        }

        public ActionResult Add()
        {
            ViewBag.Designation = ch.GetAllCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeModel employee)
        {
            eh.Add(employee);
            return RedirectToAction("Index","Employee");
        }



        public ActionResult Edit(int id)
        {
            
           EmployeModel employee =  eh.GetOne(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeModel employee)
        {
            eh.Edit(employee);
            return RedirectToAction("Index", "Employee");
        }

        public JsonResult Designation()
        {
            return Json(ch.GetAllCategory(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            
           EmployeModel user = eh.GetOne(id);
            eh.Delete(user);
            return RedirectToAction("Index","Employee");
        }


        public ActionResult Payroll(int id)
        {
            EmployeModel user = eh.GetOne(id);
            eh.UpdatePayroll(user);
            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
    }
}