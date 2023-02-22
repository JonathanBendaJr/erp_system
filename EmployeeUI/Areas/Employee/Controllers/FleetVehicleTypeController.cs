using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class FleetVehicleTypeController : Controller
    {
        FleetVehicleTypeBLL bll = new FleetVehicleTypeBLL();
        // GET: Employee/FleetVehicleType
        public ActionResult AddFleetVehicleType()
        {
            FleetVehicleTypeDTO dto = new FleetVehicleTypeDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddFleetVehicleType(FleetVehicleTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddFleetVehicleType(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new FleetVehicleTypeDTO();
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

        public ActionResult FleetVehicleTypeList()
        {
            List<FleetVehicleTypeDTO> model = bll.GetFleetVehicleTypes();
            return View(model);
        }

        public ActionResult UpdateFleetVehicleType(int ID)
        {
            FleetVehicleTypeDTO dto = bll.UpdateFleetVehicleTypeWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateFleetVehicleType(FleetVehicleTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateFleetVehicleType(model))
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

        public JsonResult DeleteFleetVehicleType(int ID)
        {
            bll.DeleteFleetVehicleType(ID);
            return Json("");
        }
    }
}