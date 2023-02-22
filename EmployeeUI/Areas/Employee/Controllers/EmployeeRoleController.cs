using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeRoleController : Controller
    {
        EmployeeRoleBLL bll = new EmployeeRoleBLL();
        // GET: Employee/EmployeeRole
        public ActionResult AddEmployeeRole()
        {
            EmployeeRoleDTO dto = new EmployeeRoleDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddEmployeeRole(EmployeeRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddEmployeeRole(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeRoleDTO();
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

        public ActionResult EmployeeRoleList()
        {
            List<EmployeeRoleDTO> model = bll.GetEmployeeRoles();
            return View(model);
        }

        public ActionResult UpdateEmployeeRole(int ID)
        {
            EmployeeRoleDTO dto = bll.UpdateEmployeeRoleWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateEmployeeRole(EmployeeRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateEmployeeRole(model))
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

        public JsonResult DeleteEmployeeRole(int ID)
        {
            bll.DeleteEmployeeRole(ID);
            return Json("");
        }
    }
}