using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class ResolutionTypeController : Controller
    {
        ResolutionTypeBLL bll = new ResolutionTypeBLL();

        // GET: Employee/ResolutionType
        public ActionResult AddResolutionType()
        {
            ResolutionTypeDTO dto = new ResolutionTypeDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddResolutionType(ResolutionTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddResolutionType(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new ResolutionTypeDTO();
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

        public ActionResult ResolutionTypeList()
        {
            List<ResolutionTypeDTO> model = bll.GetResolutionTypes();
            return View(model);
        }

        public ActionResult UpdateResolutionType(int ID)
        {
            ResolutionTypeDTO dto = bll.UpdateResolutionTypeWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateResolutionType(ResolutionTypeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateResolutionType(model))
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

        public JsonResult DeleteResolutionType(int ID)
        {
            bll.DeleteResolutionType(ID);
            return Json("");
        }
    }
}