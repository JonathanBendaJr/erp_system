using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class LevelOfUrgencyController : Controller
    {
        LevelOfUrgencyBLL bll = new LevelOfUrgencyBLL();
        // GET: Employee/LevelOfUrgency
        public ActionResult AddLevelOfUrgency()
        {
            LevelOfUrgencyDTO dto = new LevelOfUrgencyDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddLevelOfUrgency(LevelOfUrgencyDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddLevelOfUrgency(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new LevelOfUrgencyDTO();
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

        public ActionResult LevelOfUrgencyList()
        {
            List<LevelOfUrgencyDTO> model = bll.GetLevelOfUrgencies();
            return View(model);
        }

        public ActionResult UpdateLevelOfUrgency(int ID)
        {
            LevelOfUrgencyDTO dto = bll.UpdateLevelOfUrgencyWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateLevelOfUrgency(LevelOfUrgencyDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateLevelOfUrgency(model))
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

        public JsonResult DeleteLevelOfUrgency(int ID)
        {
            bll.DeleteLevelOfUrgency(ID);
            return Json("");
        }
    }
}