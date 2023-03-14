using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleRegistrationController : Controller
    {
        FleetVehicleRegistrationBLL bll = new FleetVehicleRegistrationBLL();
        // GET: Employee/FleetVehicleRegistration
        public ActionResult AddFleetVehicleRegistration()
        {
            FleetVehicleRegistrationDTO dto = new FleetVehicleRegistrationDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddFleetVehicleRegistration(FleetVehicleRegistrationDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleRegistration(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleRegistrationDTO();
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

        public ActionResult FleetVehicleRegistrationList()
        {
            List<FleetVehicleRegistrationDTO> model = bll.GetFleetVehicleRegistrations();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleRegistration(int ID)
        {
            FleetVehicleRegistrationDTO dto = bll.UpdateFleetVehicleRegistrationWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicleRegistration(FleetVehicleRegistrationDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleRegistration(model))
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

        public JsonResult DeleteFleetVehicleRegistration(int ID)
        {
            bll.DeleteFleetVehicleRegistration(ID);
            return Json("");
        }
    }
}