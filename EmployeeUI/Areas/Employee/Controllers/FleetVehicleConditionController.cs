using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleConditionController : Controller
    {
        FleetVehicleConditionBLL bll = new FleetVehicleConditionBLL();
        // GET: Employee/FleetVehicleCondition
        public ActionResult AddFleetVehicleCondition()
        {
            FleetVehicleConditionDTO dto = new FleetVehicleConditionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddFleetVehicleCondition(FleetVehicleConditionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleCondition(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleConditionDTO();
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

        public ActionResult FleetVehicleConditionList()
        {
            List<FleetVehicleConditionDTO> model = bll.GetFleetVehicleConditions();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleCondition(int ID)
        {
            FleetVehicleConditionDTO dto = bll.UpdateFleetVehicleConditionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicleCondition(FleetVehicleConditionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleCondition(model))
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

        public JsonResult DeleteFleetVehicleCondition(int ID)
        {
            bll.DeleteFleetVehicleCondition(ID);
            return Json("");
        }
    }
}