using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeDependantController : Controller
    {
        EmployeeDependantBLL edbll = new EmployeeDependantBLL();
        // GET: Employee/EmployeeDependant
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployeeDependant(int id)
        {
            EmployeeDependantDTO model = new EmployeeDependantDTO();
            model.RelationshipList = EmployeeDependantBLL.GetRelationshipListForDropdown();
            model.EmployeeID = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployeeDependant(EmployeeDependantDTO model)
        {
            if (ModelState.IsValid)
            {
                if (edbll.AddEmployeeDependant(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeDependantDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.RelationshipList = EmployeeDependantBLL.GetRelationshipListForDropdown();
            return View(model);
        }

        public ActionResult EmployeeDependantList()
        {
            List<EmployeeDependantDTO> model = edbll.GetEmployeeDependants();
            return View(model);
        }

        public ActionResult UpdateEmployeeDependant(int ID)
        {
            EmployeeDependantDTO model = edbll.UpdateEmployeeDependantWithID(ID);
            model.RelationshipList = EmployeeDependantBLL.GetRelationshipListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateEmployeeDependant(EmployeeDependantDTO model)
        {
            if (ModelState.IsValid)
            {
                if (edbll.UpdateEmployeeDependant(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            model.RelationshipList = EmployeeDependantBLL.GetRelationshipListForDropdown();
            return View(model);
        }

        public JsonResult DeleteEmployeeDependant(int ID)
        {
            edbll.DeleteEmployeeDependant(ID);
            return Json("");
        }
    }
}