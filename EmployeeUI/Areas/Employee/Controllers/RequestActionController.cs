using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class RequestActionController : Controller
    {
        RequestActionBLL bll = new RequestActionBLL();
        // GET: Employee/RequestAction
        public ActionResult AddRequestAction()
        {
            RequestActionDTO dto = new RequestActionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddRequestAction(RequestActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddRequestAction(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new RequestActionDTO();
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

        public ActionResult RequestActionList()
        {
            List<RequestActionDTO> model = bll.GetRequestActions();
            return View(model);
        }

        public ActionResult UpdateRequestAction(int ID)
        {
            RequestActionDTO dto = bll.UpdateRequestActionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateRequestAction(RequestActionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateRequestAction(model))
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

        public JsonResult DeleteRequestAction(int ID)
        {
            bll.DeleteRequestAction(ID);
            return Json("");
        }
    }
}