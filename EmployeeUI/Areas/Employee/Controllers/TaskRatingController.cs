using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class TaskRatingController : Controller
    {
        TaskRatingBLL bll = new TaskRatingBLL();
        // GET: Employee/TaskRating
        public ActionResult AddTaskRating()
        {
            TaskRatingDTO dto = new TaskRatingDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddTaskRating(TaskRatingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddTaskRating(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new TaskRatingDTO();
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

        public ActionResult TaskRatingList()
        {
            List<TaskRatingDTO> model = bll.GetTaskRatings();
            return View(model);
        }

        public ActionResult UpdateTaskRating(int ID)
        {
            TaskRatingDTO dto = bll.UpdateTaskRatingWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateTaskRating(TaskRatingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateTaskRating(model))
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

        public JsonResult DeleteTaskRating(int ID)
        {
            bll.DeleteTaskRating(ID);
            return Json("");
        }
    }
}