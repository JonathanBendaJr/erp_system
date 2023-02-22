using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class LeaveActionController : Controller
    {
        LeaveActionBLL bll = new LeaveActionBLL();
        // GET: Employee/LeaveAction
        public ActionResult AddLeaveAction()
        {
            LeaveActionDTO dto = new LeaveActionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddLeaveAction(LeaveActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddLeaveAction(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new LeaveActionDTO();
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

        public ActionResult LeaveActionList()
        {
            List<LeaveActionDTO> model = bll.GetLeaveActions();
            return View(model);
        }

        public ActionResult UpdateLeaveAction(int ID)
        {
            LeaveActionDTO dto = bll.UpdateLeaveActionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateLeaveAction(LeaveActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateLeaveAction(model))
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

        public JsonResult DeleteLeaveAction(int ID)
        {
            bll.DeleteLeaveAction(ID);
            return Json("");
        }
    }
}