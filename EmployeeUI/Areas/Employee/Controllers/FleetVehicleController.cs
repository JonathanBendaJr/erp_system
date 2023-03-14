using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleController : Controller
    {
        
        FleetVehicleBLL bll = new FleetVehicleBLL();
        public ActionResult AddFleetVehicle()
        {
            FleetVehicleDTO model = new FleetVehicleDTO();
            model.TypeList = FleetVehicleBLL.GetTypeListForDropdown();
            model.OwnershipStatusList = FleetVehicleBLL.GetOwnershipStatusListForDropdown();
            model.UnitList = FleetVehicleBLL.GetUnitListForDropdown();
            model.VehicleStatusList = FleetVehicleBLL.GetVehicleStatusListForDropdown();
            model.RegistrationStatusList = FleetVehicleBLL.GetRegistrationStatusListForDropdown();
            model.ReceivedConditionList = FleetVehicleBLL.GetReceivedConditionListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFleetVehicle(FleetVehicleDTO model)
        {
            if (ModelState.IsValid)
            {
                bll.AddFleetVehicle(model);
                ViewBag.ProcessState = General.Messages.AddSuccess;
                ModelState.Clear();
                model = new FleetVehicleDTO();
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.TypeList = FleetVehicleBLL.GetTypeListForDropdown();
            model.OwnershipStatusList = FleetVehicleBLL.GetOwnershipStatusListForDropdown();
            model.UnitList = FleetVehicleBLL.GetUnitListForDropdown();
            model.VehicleStatusList = FleetVehicleBLL.GetVehicleStatusListForDropdown();
            model.RegistrationStatusList = FleetVehicleBLL.GetRegistrationStatusListForDropdown();
            model.ReceivedConditionList = FleetVehicleBLL.GetReceivedConditionListForDropdown();
            return View(model);
        }

        public ActionResult FleetVehicleList()
        {
            List<FleetVehicleDTO> model = bll.GetFleetVehicles();
            return View(model);
        }

        public ActionResult ViewFleetVehicleCard(int ID)
        {
            FleetVehicleDTO model = bll.GetFleetVehicleDetailsByID(ID);
            //model = fvcbll.ViewFleetVehicleCardWithID(ID);
            return View(model);
        }

        public ActionResult UpdateFleetVehicle(int ID)
        {
            FleetVehicleDTO model = bll.UpdateFleetVehicleWithID(ID);
            model.TypeList = FleetVehicleBLL.GetTypeListForDropdown();
            model.OwnershipStatusList = FleetVehicleBLL.GetOwnershipStatusListForDropdown();
            model.UnitList = FleetVehicleBLL.GetUnitListForDropdown();
            model.VehicleStatusList = FleetVehicleBLL.GetVehicleStatusListForDropdown();
            model.RegistrationStatusList = FleetVehicleBLL.GetRegistrationStatusListForDropdown();
            model.ReceivedConditionList = FleetVehicleBLL.GetReceivedConditionListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicle(FleetVehicleDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                bll.UpdateFleetVehicle(model);
                ViewBag.ProcessState = General.Messages.UpdateSuccess;
            }
            model.TypeList = FleetVehicleBLL.GetTypeListForDropdown();
            model.OwnershipStatusList = FleetVehicleBLL.GetOwnershipStatusListForDropdown();
            model.UnitList = FleetVehicleBLL.GetUnitListForDropdown();
            model.VehicleStatusList = FleetVehicleBLL.GetVehicleStatusListForDropdown();
            model.RegistrationStatusList = FleetVehicleBLL.GetRegistrationStatusListForDropdown();
            model.ReceivedConditionList = FleetVehicleBLL.GetReceivedConditionListForDropdown();
            return View(model);
        }

        public ActionResult FleetVehicleCard(int ID)
        {
            FleetVehicleDTO model = new FleetVehicleDTO();
            model = bll.ViewFleetVehicleCardWithID(ID);
            return View(model);
        }
        public JsonResult DeleteFleetVehicle(int ID)
        {
            bll.DeleteFleetVehicle(ID);
            return Json("");
        }
    }
}