using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class CountyController : Controller
    {
        CountyBLL bll = new CountyBLL();
        // GET: Employee/County
        public ActionResult AddCounty()
        {
            CountyDTO dto = new CountyDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddCounty(CountyDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddCounty(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new CountyDTO();
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

        public ActionResult CountyList()
        {
            List<CountyDTO> model = bll.GetCounties();
            return View(model);
        }

        public ActionResult UpdateCounty(int ID)
        {
            CountyDTO dto = bll.UpdateCountyWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateCounty(CountyDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateCounty(model))
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

        public JsonResult DeleteCounty(int ID)
        {
            bll.DeleteCounty(ID);
            return Json("");
        }
    }
}