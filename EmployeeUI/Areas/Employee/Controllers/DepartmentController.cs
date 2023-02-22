using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL bll = new DepartmentBLL();
        // GET: Employee/Department
        public ActionResult AddDepartment()
        {
            DepartmentDTO dto = new DepartmentDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddDepartment(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new DepartmentDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public ActionResult DepartmentList()
        {
            List<DepartmentDTO> model = bll.GetDepartments();
            return View(model);
        }

        public ActionResult UpdateDepartment(int ID)
        {
            DepartmentDTO dto = bll.UpdateDepartmentWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateDepartment(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public JsonResult DeleteDepartment(int ID)
        {
            bll.DeleteDepartment(ID);
            return Json("");
        }
    }
}