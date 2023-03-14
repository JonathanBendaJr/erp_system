using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleMaintenanceRequestController : Controller
    {
        FleetVehicleMaintenanceRequestBLL bll = new FleetVehicleMaintenanceRequestBLL();
        // GET: Employee/FleetVehicleMaintenanceRequest
        public ActionResult AddFleetVehicleMaintenanceRequest()
        {
            FleetVehicleMaintenanceRequestDTO model = new FleetVehicleMaintenanceRequestDTO();
            model.Approvals = FleetVehicleMaintenanceRequestBLL.GetApprovalsForDropdown();
            model.Vehicles = FleetVehicleMaintenanceRequestBLL.GetVehiclesForDropdown();
            model.VehichleStatuses = FleetVehicleMaintenanceRequestBLL.GetVehicleStatusForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleMaintenanceRequest(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleMaintenanceRequestDTO();
                    model.Approvals = FleetVehicleMaintenanceRequestBLL.GetApprovalsForDropdown();
                    return View(model);
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.Approvals = FleetVehicleMaintenanceRequestBLL.GetApprovalsForDropdown();
            model.Vehicles = FleetVehicleMaintenanceRequestBLL.GetVehiclesForDropdown();
            model.VehichleStatuses = FleetVehicleMaintenanceRequestBLL.GetVehicleStatusForDropdown();
            return View(model);
        }
        public ActionResult FleetVehicleBookingReportList()
        {
            List<FleetVehicleMaintenanceRequestDTO> model = bll.GetFleetVehicleMaintenanceRequests();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleBookingReport(int ID)
        {
            FleetVehicleMaintenanceRequestDTO model = bll.UpdateFleetVehicleMaintenanceRequestWithID(ID);
            model.Approvals = FleetVehicleMaintenanceRequestBLL.GetApprovalsForDropdown();
            model.Vehicles = FleetVehicleMaintenanceRequestBLL.GetVehiclesForDropdown();
            model.VehichleStatuses = FleetVehicleMaintenanceRequestBLL.GetVehicleStatusForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleMaintenanceRequest(model))
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

        public JsonResult DeleteFleetVehicleMaintenanceRequest(int ID)
        {
            bll.DeleteFleetVehicleMaintenanceRequest(ID);
            return Json("");
        }
    }
}