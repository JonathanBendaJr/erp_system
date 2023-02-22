using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class PayGradeController : Controller
    {
        PayGradeBLL bll = new PayGradeBLL();
        // GET: Employee/PayGrade
        public ActionResult AddPayGrade()
        {
            PayGradeDTO model = new PayGradeDTO();
            model.PositionList = PayGradeBLL.GetPositionListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPayGrade(PayGradeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddPayGrade(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new PayGradeDTO();
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
            model.PositionList = PayGradeBLL.GetPositionListForDropdown();
            return View(model);
        }

        public ActionResult PayGradeList()
        {
            List<PayGradeDTO> model = bll.GetPayGrades();
            return View(model);
        }

        public ActionResult UpdatePayGrade(int ID)
        {
            PayGradeDTO model = bll.UpdatePayGradeWithID(ID);
            model.PositionList = PayGradeBLL.GetPositionListForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePayGrade(PayGradeDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdatePayGrade(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            model.PositionList = PayGradeBLL.GetPositionListForDropdown();
            return View(model);
        }

        public JsonResult DeletePayGrade(int ID)
        {
            bll.DeletePayGrade(ID);
            return Json("");
        }
    }
}