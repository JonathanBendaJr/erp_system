using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class TaskActionController : Controller
    {
        TaskActionBLL bll = new TaskActionBLL();
        // GET: Employee/TaskAction
        public ActionResult AddTaskAction()
        {
            TaskActionDTO dto = new TaskActionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddTaskAction(TaskActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddTaskAction(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new TaskActionDTO();
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

        public ActionResult TaskActionList()
        {
            List<TaskActionDTO> model = bll.GetTaskActions();
            return View(model);
        }

        public ActionResult UpdateTaskAction(int ID)
        {
            TaskActionDTO dto = bll.UpdateTaskActionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateTaskAction(TaskActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateTaskAction(model))
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

        public JsonResult DeleteTaskAction(int ID)
        {
            bll.DeleteTaskAction(ID);
            return Json("");
        }
    }
}