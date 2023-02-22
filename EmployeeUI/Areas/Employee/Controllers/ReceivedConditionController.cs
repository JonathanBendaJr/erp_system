using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class ReceivedConditionController : Controller
    {
        ReceivedConditionBLL bll = new ReceivedConditionBLL();
        // GET: Employee/ReceivedCondition
        public ActionResult AddReceivedCondition()
        {
            ReceivedConditionDTO dto = new ReceivedConditionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddReceivedCondition(ReceivedConditionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddReceivedCondition(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new ReceivedConditionDTO();
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

        public ActionResult ReceivedConditionList()
        {
            List<ReceivedConditionDTO> model = bll.GetReceivedConditions();
            return View(model);
        }

        public ActionResult UpdateReceivedCondition(int ID)
        {
            ReceivedConditionDTO dto = bll.UpdateReceivedConditionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateReceivedCondition(ReceivedConditionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateReceivedCondition(model))
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

        public JsonResult DeleteReceivedCondition(int ID)
        {
            bll.DeleteReceivedCondition(ID);
            return Json("");
        }
    }
}