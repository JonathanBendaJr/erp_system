using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class UnitOfMeasurementController : Controller
    {
        UnitOfMeasurementBLL bll = new UnitOfMeasurementBLL();
        // GET: Employee/UnitOfMeasurement
        public ActionResult AddUnitOfMeasurement()
        {
            UnitOfMeasurementDTO dto = new UnitOfMeasurementDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddUnitOfMeasurement(UnitOfMeasurementDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddUnitOfMeasurement(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new UnitOfMeasurementDTO();
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

        public ActionResult UnitOfMeasurementList()
        {
            List<UnitOfMeasurementDTO> model = bll.GetUnitOfMeasurements();
            return View(model);
        }

        public ActionResult UpdateUnitOfMeasurement(int ID)
        {
            UnitOfMeasurementDTO dto = bll.UpdateUnitOfMeasurementWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateUnitOfMeasurement(UnitOfMeasurementDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateUnitOfMeasurement(model))
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

        public JsonResult DeleteUnitOfMeasurement(int ID)
        {
            bll.DeleteUnitOfMeasurement(ID);
            return Json("");
        }
    }
}