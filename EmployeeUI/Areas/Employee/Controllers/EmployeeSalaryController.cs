using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        EmployeeSalaryBLL salbll = new EmployeeSalaryBLL();
        // GET: Employee/EmployeeSalary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployeeSalary(int id)
        {
            EmployeeSalaryDTO model = new EmployeeSalaryDTO();
            model.PayGradeList = EmployeeSalaryBLL.GetPayGradeListForDropdown();
            model.EmployeeID = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployeeSalary(EmployeeSalaryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (salbll.AddEmployeeSalary(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeSalaryDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return RedirectToAction("EmployeeList", "Employee");
        }

        public ActionResult UpdateEmployeeSalaryList()
        {
            List<EmployeeSalaryDTO> model = salbll.GetUpdateEmployeeSalaries();
            return View(model);
        }

        public ActionResult UpdateEmployeeSalary(int ID)
        {
            EmployeeSalaryDTO model = salbll.UpdateEmployeeSalaryWithID(ID);
            model.PayGradeList = EmployeeSalaryBLL.GetPayGradeListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateEmployeeSalary(EmployeeSalaryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (salbll.UpdateEmployeeSalary(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return RedirectToAction("EmployeeList", "Employee");
        }

        public JsonResult DeleteEmployeeSalary(int ID)
        {
            salbll.DeleteEmployeeSalary(ID);
            return Json("");
        }
    }
}