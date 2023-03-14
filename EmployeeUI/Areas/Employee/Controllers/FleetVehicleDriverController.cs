using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleDriverController : Controller
    {
        FleetVehicleDriverBLL bll = new FleetVehicleDriverBLL();
        public ActionResult AddFleetVehicleDriver()
        {
            FleetVehicleDriverDTO model = new FleetVehicleDriverDTO();
            model.Vehicles = FleetVehicleDriverBLL.GetVehiclesForDropdown();
            model.Drivers = FleetVehicleDriverBLL.GetDriversForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddFleetVehicleDriver(FleetVehicleDriverDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleDriver(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleDriverDTO();
                    model.Vehicles = FleetVehicleDriverBLL.GetVehiclesForDropdown();
                    model.Drivers = FleetVehicleDriverBLL.GetDriversForDropdown();
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
            model.Vehicles = FleetVehicleDriverBLL.GetVehiclesForDropdown();
            model.Drivers = FleetVehicleDriverBLL.GetDriversForDropdown();
            return View(model);
        }

        public ActionResult FleetVehicleDriverList()
        {
            List<FleetVehicleDriverDTO> model= bll.GetFleetVehiclesDrivers();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleDriver(int ID)
        {
            FleetVehicleDriverDTO model = bll.UpdateFleetVehicleDriverWithID(ID);
            model.Vehicles = FleetVehicleDriverBLL.GetVehiclesForDropdown();
            model.Drivers = FleetVehicleDriverBLL.GetDriversForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateFleetVehicleDriver(FleetVehicleDriverDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleDriver(model))
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

        public JsonResult DeleteFleetVehicleDriver(int ID)
        {
            bll.DeleteFleetVehicleDriver(ID);
            return Json("");
        }
    }
}