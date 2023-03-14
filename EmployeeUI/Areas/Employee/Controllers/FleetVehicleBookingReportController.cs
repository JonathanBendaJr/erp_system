using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleBookingReportController : Controller
    {
        FleetVehicleBookingReportBLL bll = new FleetVehicleBookingReportBLL();
        // GET: Employee/FleetVehicleBookingReport
        public ActionResult AddFleetVehicleBookingReport(int ID)
        {
            FleetVehicleBookingReportDTO model = new FleetVehicleBookingReportDTO();
            model.Approvals = FleetVehicleBookingReportBLL.GetApprovalsForDropdown();
            model.BookingID = ID;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleBookingReport(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleBookingReportDTO();
                    model.Approvals = FleetVehicleBookingReportBLL.GetApprovalsForDropdown();
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
            model.Approvals = FleetVehicleBookingReportBLL.GetApprovalsForDropdown();
            return View(model);
        }
        public ActionResult FleetVehicleBookingReportList()
        {
            List<FleetVehicleBookingReportDTO> model = bll.GetFleetVehicleBookingReports();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleBookingReport(int ID)
        {
            FleetVehicleBookingReportDTO model = bll.UpdateFleetVehicleBookingReportWithID(ID);
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleBookingReport(model))
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

        public JsonResult DeleteFleetVehicleBookingReport(int ID)
        {
            bll.DeleteFleetVehicleBookingReport(ID);
            return Json("");
        }

        public ActionResult FleetManagerFleetVehicleBookingReportList()
        {
            List<FleetVehicleBookingReportDTO> model = bll.GetFleetVehicleBookingReportsForFleetManager();
            return View(model);
        }

        public ActionResult FleetManagerUpdateFleetVehicleBookingReport(int ID)
        {
            FleetVehicleBookingReportDTO model = bll.FleetManagerUpdateFleetVehicleBookingReportWithID(ID);
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult FleetManagerUpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.FleetManagerUpdateFleetVehicleBookingReport(model))
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

        public ActionResult FleetVehicleBookingReportDetail(int ID)
        {
            FleetVehicleBookingReportDTO model = bll.FleetVehicleBookingReportDetailWithID(ID);
            model.Approvals = FleetVehicleBookingBLL.GetApprovalsForDropdown();
            return View(model);
        }
    }
}