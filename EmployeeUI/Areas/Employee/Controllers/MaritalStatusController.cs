using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class MaritalStatusController : Controller
    {

        MaritalStatusBLL bll = new MaritalStatusBLL();
        // GET: Employee/MaritalStatus
        public ActionResult AddMaritalStatus()
        {
            MaritalStatusDTO dto = new MaritalStatusDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddMaritalStatus(MaritalStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddMaritalStatus(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new MaritalStatusDTO();
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

        public ActionResult MaritalStatusList()
        {
            List<MaritalStatusDTO> model = bll.GetMaritalStatuses();
            return View(model);
        }

        public ActionResult UpdateMaritalStatus(int ID)
        {
            MaritalStatusDTO dto = bll.UpdateMaritalStatusWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateMaritalStatus(MaritalStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateMaritalStatus(model))
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

        public JsonResult DeleteMaritalStatus(int ID)
        {
            bll.DeleteMaritalStatus(ID);
            return Json("");
        }
    }
}