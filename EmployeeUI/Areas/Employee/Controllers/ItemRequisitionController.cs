
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class ItemRequisitionController : Controller
    {
        ItemRequisitionBLL bll = new ItemRequisitionBLL();
        // GET: Employee/ItemRequisition
        public ActionResult AddItemRequisition()
        {
            ItemRequisitionDTO model = new ItemRequisitionDTO();
            model.Units = ItemRequisitionBLL.GetUnitsForDropdown();
            model.Urgencies = ItemRequisitionBLL.GetUrgenciesForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddItemRequisition(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddItemRequisition(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new ItemRequisitionDTO();
                    model.Units = ItemRequisitionBLL.GetUnitsForDropdown();
                    model.Urgencies = ItemRequisitionBLL.GetUrgenciesForDropdown();
                    return View(model);
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
            model.Units = ItemRequisitionBLL.GetUnitsForDropdown();
            model.Urgencies = ItemRequisitionBLL.GetUrgenciesForDropdown();
            return View(model);
        }
        public ActionResult ItemRequisitionList()
        {
            List<ItemRequisitionDTO> model = bll.GetItemRequisitions();
            return View(model);
        }
        public ActionResult ItemRequisitionListProcurementOfficer()
        {
            List<ItemRequisitionDTO> model = bll.GetItemRequisitionsApproved();
            return View(model);
        }

        public ActionResult ItemRequisitionListPerLoginUser()
        {
            List<ItemRequisitionDTO> model = bll.GetItemRequisitionsPerLoginUser();
            return View(model);
        }
        public ActionResult ItemRequisitionListPerDepartment()
        {
            List<ItemRequisitionDTO> model = bll.GetItemRequisitionsPerDepartment();
            return View(model);
        }

        public ActionResult UpdateItemRequisition(int ID)
        {
            ItemRequisitionDTO model = bll.UpdateItemRequisitionWithID(ID);
            model.Units = ItemRequisitionBLL.GetUnitsForDropdown();
            model.Urgencies = ItemRequisitionBLL.GetUrgenciesForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateItemRequisition(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateItemRequisition(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    return RedirectToAction("ItemRequisitionListPerLoginUser", "ItemRequisition");
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public ActionResult AcknowledgeItemReceived(int ID)
        {
            ItemRequisitionDTO model = bll.AcknowledgeItemReceivedWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult AcknowledgeItemReceived(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AcknowledgeItemReceived(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    return RedirectToAction("ItemRequisitionListPerLoginUser", "ItemRequisition");
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }


        public ActionResult UpdateItemRequisitionManager(int ID)
        {
            ItemRequisitionDTO model = bll.UpdateItemRequisitionManagerWithID(ID);
            model.ManagerApprovalStatuses = bll.GetRequestStatusesForDropDown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateItemRequisitionManager(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateItemRequisitionManager(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    return RedirectToAction("ItemRequisitionListPerDepartment", "ItemRequisition");
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }
        public ActionResult UpdateItemRequisitionProcurementManager(int ID)
        {
            ItemRequisitionDTO model = bll.UpdateItemRequisitionProcurementManagerWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateItemRequisitionProcurementManager(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateItemRequisitionProcurementManager(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    return RedirectToAction("ItemRequisitionList", "ItemRequisition");
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }
        public ActionResult UpdateItemRequisitionProcurementOfficer(int ID)
        {
            ItemRequisitionDTO model = bll.UpdateItemRequisitionProcurementOfficerWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateItemRequisitionProcurementOfficer(ItemRequisitionDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateItemRequisitionProcurementOfficer(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    return RedirectToAction("ItemRequisitionListProcurementOfficer", "ItemRequisition");
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

    }
}