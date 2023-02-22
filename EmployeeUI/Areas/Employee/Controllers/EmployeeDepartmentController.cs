using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        EmployeeDepartmentBLL edptbll = new EmployeeDepartmentBLL();
        // GET: Employee/EmployeeDeparmtent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployeeDepartment(int id)
        {
            EmployeeDepartmentDTO model = new EmployeeDepartmentDTO();
            model.PositionList = EmployeeDepartmentBLL.GetPositionListForDropdown();
            model.ManagerList = EmployeeDepartmentBLL.GetManagerListForDropdown();
            model.SupervisorList = EmployeeDepartmentBLL.GetSupervisorListForDropdown();
            model.DepartmentList = EmployeeDepartmentBLL.GetDepartmentListForDropdown();
            model.EmployeeID = id;
            model.employeeDTO = EmployeeDepartmentBLL.GetEmployeeDetail(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployeeDepartment(EmployeeDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                if (edptbll.AddEmployeeDepartment(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
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
        public ActionResult EmployeeDepartmentList()
        {
            List<EmployeeDepartmentDTO> model = edptbll.GetEmployeeDepartments();
            return View(model);
        }
        public ActionResult UpdateEmployeeDepartment(int ID)
        {
            EmployeeDepartmentDTO model = edptbll.UpdateEmployeeDepartmentWithID(ID);
            model.PositionList = EmployeeDepartmentBLL.GetPositionListForDropdown();
            model.ManagerList = EmployeeDepartmentBLL.GetManagerListForDropdown();
            model.SupervisorList = EmployeeDepartmentBLL.GetSupervisorListForDropdown();
            model.DepartmentList = EmployeeDepartmentBLL.GetDepartmentListForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmployeeDepartment(EmployeeDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                if (edptbll.UpdateEmployeeDepartment(model))
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
        public JsonResult DeleteEmployeeDepartment(int ID)
        {
            edptbll.DeleteEmployeeDepartment(ID);
            return Json("");
        }

    }
}