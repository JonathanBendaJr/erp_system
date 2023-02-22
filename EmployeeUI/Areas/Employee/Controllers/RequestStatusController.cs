using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class RequestStatusController : Controller
    {
        RequestStatusBLL bll = new RequestStatusBLL();
        // GET: Employee/RequestStatus
        public ActionResult AddRequestStatus()
        {
            RequestStatusDTO dto = new RequestStatusDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddRequestStatus(RequestStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddRequestStatus(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new RequestStatusDTO();
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

        public ActionResult RequestStatusList()
        {
            List<RequestStatusDTO> model = bll.GetRequestStatuses();
            return View(model);
        }

        public ActionResult UpdateRequestStatus(int ID)
        {
            RequestStatusDTO dto = bll.UpdateRequestStatusWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateRequestStatus(RequestStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateRequestStatus(model))
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

        public JsonResult DeleteRequestStatus(int ID)
        {
            bll.DeleteRequestStatus(ID);
            return Json("");
        }
    }
}