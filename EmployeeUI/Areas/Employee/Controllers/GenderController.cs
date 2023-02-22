using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class GenderController : Controller
    {
        GenderBLL bll = new GenderBLL();
        // GET: Employee/Gender
        public ActionResult AddGender()
        {
            GenderDTO dto = new GenderDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddGender(GenderDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddGender(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new GenderDTO();
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

        public ActionResult GenderList()
        {
            List<GenderDTO> model = bll.GetGenders();
            return View(model);
        }

        public ActionResult UpdateGender(int ID)
        {
            GenderDTO dto = bll.UpdateGenderWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateGender(GenderDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateGender(model))
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

        public JsonResult DeleteGender(int ID)
        {
            bll.DeleteGender(ID);
            return Json("");
        }
    }
}