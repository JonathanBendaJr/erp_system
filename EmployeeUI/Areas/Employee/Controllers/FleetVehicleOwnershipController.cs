using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleOwnershipController : Controller
    {
        FleetVehicleOwnershipBLL bll = new FleetVehicleOwnershipBLL();
        // GET: Employee/FleetVehicleOwnership
        public ActionResult AddFleetVehicleOwnership()
        {
            FleetVehicleOwnershipDTO dto = new FleetVehicleOwnershipDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddFleetVehicleOwnership(FleetVehicleOwnershipDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleOwnership(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleOwnershipDTO();
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

        public ActionResult FleetVehicleOwnershipList()
        {
            List<FleetVehicleOwnershipDTO> model = bll.GetFleetVehicleOwnerships();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleOwnership(int ID)
        {
            FleetVehicleOwnershipDTO dto = bll.UpdateFleetVehicleOwnershipWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicleOwnership(FleetVehicleOwnershipDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleOwnership(model))
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

        public JsonResult DeleteFleetVehicleOwnership(int ID)
        {
            bll.DeleteFleetVehicleOwnership(ID);
            return Json("");
        }
    }
}