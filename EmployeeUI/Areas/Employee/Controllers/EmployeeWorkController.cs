using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeWorkController : Controller
    {
        EmployeeWorkBLL workbll = new EmployeeWorkBLL();
        // GET: Employee/EmployeeWork
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployeeWork(int id)
        {
            EmployeeWorkDTO dto = new EmployeeWorkDTO();
            dto.EmployeeID = id;
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddEmployeeWork(EmployeeWorkDTO model)
        {
            if (ModelState.IsValid)
            {
                if (workbll.AddEmployeeWork(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeWorkDTO();
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

        public ActionResult EmployeeWorkList()
        {
            List<EmployeeWorkDTO> model = workbll.GetEmployeeWorks();
            return View(model);
        }

        public ActionResult UpdateEmployeeWork(int ID)
        {
            EmployeeWorkDTO dto = workbll.UpdateEmployeeWorkWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateEmployeeWork(EmployeeWorkDTO model)
        {
            if (ModelState.IsValid)
            {
                if (workbll.UpdateEmployeeWork(model))
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

        public JsonResult DeleteEmployeeWork(int ID)
        {
            workbll.DeleteEmployeeWork(ID);
            return Json("");
        }
    }
}