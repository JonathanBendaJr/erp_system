using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    
    public class RelationshipController : Controller
    {
        RelationshipBLL bll = new RelationshipBLL();
        // GET: Employee/Relationship
        public ActionResult AddRelationship()
        {
            RelationshipDTO dto = new RelationshipDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddRelationship(RelationshipDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddRelationship(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new RelationshipDTO();
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

        public ActionResult RelationshipList()
        {
            List<RelationshipDTO> model = bll.GetRelationships();
            return View(model);
        }

        public ActionResult UpdateRelationship(int ID)
        {
            RelationshipDTO dto = bll.UpdateRelationshipWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateRelationship(RelationshipDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateRelationship(model))
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

        public JsonResult DeleteRelationship(int ID)
        {
            bll.DeleteRelationship(ID);
            return Json("");
        }
    }
}