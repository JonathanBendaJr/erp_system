using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class LeaveTypeController : Controller
    {
        LeaveTypeBLL bll = new LeaveTypeBLL();
        // GET: Employee/LeaveType
        public ActionResult AddLeaveType()
        {
            LeaveTypeDTO dto = new LeaveTypeDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddLeaveType(LeaveTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddLeaveType(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new LeaveTypeDTO();
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

        public ActionResult LeaveTypeList()
        {
            List<LeaveTypeDTO> model = bll.GetLeaveTypes();
            return View(model);
        }

        public ActionResult UpdateLeaveType(int ID)
        {
            LeaveTypeDTO dto = bll.UpdateLeaveTypeWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateLeaveType(LeaveTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateLeaveType(model))
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

        public JsonResult DeleteLeaveType(int ID)
        {
            bll.DeleteLeaveType(ID);
            return Json("");
        }
    }
}