using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class DegreeController : Controller
    {
        DegreeBLL bll = new DegreeBLL();
        // GET: Employee/Degree
        public ActionResult AddDegree()
        {
            DegreeDTO dto = new DegreeDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddDegree(DegreeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddDegree(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new DegreeDTO();
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

        public ActionResult DegreeList()
        {
            List<DegreeDTO> model = bll.GetDregrees();
            return View(model);
        }

        public ActionResult UpdateDegree(int ID)
        {
            DegreeDTO dto = bll.UpdateDegreeWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateDegree(DegreeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateDegree(model))
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

        public JsonResult DeleteDegree(int ID)
        {
            bll.DeleteDegree(ID);
            return Json("");
        }
    }
}