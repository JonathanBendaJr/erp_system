using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleBookingController : Controller
    {
        // GET: Employee/FleetVehicleBooking
        FleetVehicleBookingBLL bll = new FleetVehicleBookingBLL();
        public ActionResult AddFleetVehicleBooking()
        {
            FleetVehicleBookingDTO model = new FleetVehicleBookingDTO();
            model.Counties = FleetVehicleBookingBLL.GetCountiesForDropdown();
            model.Drivers = FleetVehicleBookingBLL.GetDriversForDropdown();
            model.Vehicles = FleetVehicleBookingBLL.GetVehiclesForDropdown();
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleBooking(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleBookingDTO();
                    model.Counties = FleetVehicleBookingBLL.GetCountiesForDropdown();
                    model.Drivers = FleetVehicleBookingBLL.GetDriversForDropdown();
                    model.Vehicles = FleetVehicleBookingBLL.GetVehiclesForDropdown();
                    model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
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
            model.Counties = FleetVehicleBookingBLL.GetCountiesForDropdown();
            model.Drivers = FleetVehicleBookingBLL.GetDriversForDropdown();
            model.Vehicles = FleetVehicleBookingBLL.GetVehiclesForDropdown();
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
        public ActionResult FleetVehicleBookingList()
        {
            List<FleetVehicleBookingDTO> model = bll.GetFleetVehicleBookings();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleBooking(int ID)
        {
            FleetVehicleBookingDTO model = bll.UpdateFleetVehicleBookingWithID(ID);
            model.Counties = FleetVehicleBookingBLL.GetCountiesForDropdown();
            model.Drivers = FleetVehicleBookingBLL.GetDriversForDropdown();
            model.Vehicles = FleetVehicleBookingBLL.GetVehiclesForDropdown();
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleBooking(model))
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

        public JsonResult DeleteFleetVehicleBooking(int ID)
        {
            bll.DeleteFleetVehicleBooking(ID);
            return Json("");
        }

        public ActionResult DeptManagerUpdateFleetVehicleBooking(int ID)
        {
            FleetVehicleBookingDTO model = bll.DeptManagerUpdateFleetVehicleBooking(ID);
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult DeptManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.DeptManagerUpdateFleetVehicleBooking(model))
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

        public ActionResult FleetManagerUpdateFleetVehicleBooking(int ID)
        {
            FleetVehicleBookingDTO model = bll.FleetManagerUpdateFleetVehicleBooking(ID);
            model.Drivers = FleetVehicleBookingBLL.GetDriversForDropdown();
            model.Vehicles = FleetVehicleBookingBLL.GetVehiclesForDropdown();
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult FleetManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.FleetManagerUpdateFleetVehicleBooking(model))
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
        public ActionResult DeptManagerFleetVehicleBookingList()
        {
            List<FleetVehicleBookingDTO> model = bll.GetFleetVehicleBookingsForDeptManager();
            return View(model);
        }
        public ActionResult FleetManagerFleetVehicleBookingList()
        {
            List<FleetVehicleBookingDTO> model = bll.GetFleetVehicleBookingsForFleetManager();
            return View(model);
        }
        public ActionResult FleetDriverFleetVehicleBookingList()
        {
            List<FleetVehicleBookingDTO> model = bll.GetFleetVehicleBookingsForFleetDriver();
            return View(model);
        }

        public ActionResult FleetVehicleBookingDetail(int ID)
        {
            FleetVehicleBookingDTO model = bll.FleetVehicleBookingDetailWithID(ID);
            return View(model);
        }

        public ActionResult DeptManagerFleetVehicleBookingDetail(int ID)
        {
            FleetVehicleBookingDTO model = bll.DeptManagerFleetVehicleBookingDetailWithID(ID);
            return View(model);
        }
        public ActionResult FleetManagerFleetVehicleBookingDetail(int ID)
        {
            FleetVehicleBookingDTO model = bll.FleetManagerFleetVehicleBookingDetailWithID(ID);
            return View(model);
        }
        public ActionResult DriverFleetVehicleBookingDetail(int ID)
        {
            FleetVehicleBookingDTO model = bll.DriverFleetVehicleBookingDetailWithID(ID);
            return View(model);
        }
    }
}