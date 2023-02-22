using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class StatusController : Controller
    {
        StatusBLL bll = new StatusBLL();
        // GET: Employee/Status
        public ActionResult AddStatus()
        {
            StatusDTO dto = new StatusDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddStatus(StatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddStatus(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new StatusDTO();
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

        public ActionResult StatusList()
        {
            List<StatusDTO> model = bll.GetStatuses();
            return View(model);
        }

        public ActionResult UpdateStatus(int ID)
        {
            StatusDTO dto = bll.UpdateStatusWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateStatus(StatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateStatus(model))
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

        public JsonResult DeleteStatus(int ID)
        {
            bll.DeleteStatus(ID);
            return Json("");
        }
    }
}