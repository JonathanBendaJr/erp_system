using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class PositionController : Controller
    {
        PositionBLL bll = new PositionBLL();
        // GET: Employee/Position
        public ActionResult AddPosition()
        {
            PositionDTO dto = new PositionDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddPosition(PositionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddPosition(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new PositionDTO();
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

        public ActionResult PositionList()
        {
            List<PositionDTO> model = bll.GetPositions();
            return View(model);
        }

        public ActionResult UpdatePosition(int ID)
        {
            PositionDTO dto = bll.UpdatePositionWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdatePosition(PositionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdatePosition(model))
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

        public JsonResult DeletePosition(int ID)
        {
            bll.DeletePosition(ID);
            return Json("");
        }
    }
}