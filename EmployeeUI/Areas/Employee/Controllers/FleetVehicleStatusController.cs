using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleStatusController : Controller
    {
        FleetVehicleStatusBLL bll = new FleetVehicleStatusBLL();
        // GET: Employee/FleetVehicleStatus
        public ActionResult AddFleetVehicleStatus()
        {
            FleetVehicleStatusDTO dto = new FleetVehicleStatusDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddFleetVehicleStatus(FleetVehicleStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleStatus(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleStatusDTO();
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

        public ActionResult FleetVehicleStatusList()
        {
            List<FleetVehicleStatusDTO> model = bll.GetFleetVehicleStatuss();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleStatus(int ID)
        {
            FleetVehicleStatusDTO dto = bll.UpdateFleetVehicleStatusWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicleStatus(FleetVehicleStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleStatus(model))
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

        public JsonResult DeleteFleetVehicleStatus(int ID)
        {
            bll.DeleteFleetVehicleStatus(ID);
            return Json("");
        }
    }
}