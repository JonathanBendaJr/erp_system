using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class ItemRequisitionBLL
    {
        ItemRequisitionDAO dao = new ItemRequisitionDAO();
        public bool AddItemRequisition(ItemRequisitionDTO model)
        {
            ItemRequisition ir = new ItemRequisition();
            ir.EmployeeID = UserStatic.EmployeeID;
            ir.DepartmentID = UserStatic.DepartmentID;
            ir.Item = model.Item;
            ir.ItemDescription = model.ItemDescription;
            ir.Quantity = Convert.ToDecimal(model.Quantity);
            ir.UnitID = model.UnitID;
            ir.UrgencyID = model.UrgencyID;
            ir.AddDate = DateTime.Now;
            ir.LastUpdateDate = DateTime.Now;
            ir.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddItemRequisition(ir);

            LogDAO.AddLog(General.ProcessType.ItemRequisitionAdd, General.TableName.ItemRequisition, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetUnitsForDropdown()
        {
            return (List<SelectListItem>)UnitOfMeasurementDAO.GetUnitsForDropdown();
        }

        public static IEnumerable<SelectListItem> GetUrgenciesForDropdown()
        {
            return (List<SelectListItem>)LevelOfUrgencyDAO.GetUrgenciesForDropdown();
        }

        public List<ItemRequisitionDTO> GetItemRequisitions()
        {
            return dao.GetItemRequisitions();
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsPerLoginUser()
        {
            return dao.GetItemRequisitionsPerLoginUser();
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsPerDepartment()
        {
            return dao.GetItemRequisitionsPerDepartment();
        }

        public ItemRequisitionDTO UpdateItemRequisitionWithID(int ID)
        {
            return dao.UpdateItemRequisitionWithID(ID);
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsApproved()
        {
            return dao.GetItemRequisitionsApproved();
        }

        public ItemRequisitionDTO UpdateItemRequisitionManagerWithID(int ID)
        {
            return dao.UpdateItemRequisitionManagerWithID(ID);
        }

        public ItemRequisitionDTO UpdateItemRequisitionProcurementManagerWithID(int ID)
        {
            return dao.UpdateItemRequisitionProcurementManagerWithID(ID);
        }

        public ItemRequisitionDTO UpdateItemRequisitionProcurementOfficerWithID(int ID)
        {
            return dao.UpdateItemRequisitionProcurementOfficerWithID(ID);
        }

        public IEnumerable<SelectListItem> GetRequestStatusesForDropDown()
        {
            return (List<SelectListItem>)RequestStatusDAO.GetRequestStatusesForDropDown();
        }

        public bool UpdateItemRequisitionManager(ItemRequisitionDTO model)
        {
            dao.UpdateItemRequisitionManager(model);
            LogDAO.AddLog(General.ProcessType.ItemRequisitionManagerProcessRequest, General.TableName.ItemRequisition, model.ID);
            return true;
        }

        public bool UpdateItemRequisition(ItemRequisitionDTO model)
        {
            dao.UpdateItemRequisition(model);
            LogDAO.AddLog(General.ProcessType.ItemRequisitionUpdate, General.TableName.ItemRequisition, model.ID);
            return true;
        }

        public bool AcknowledgeItemReceived(ItemRequisitionDTO model)
        {
            dao.AcknowledgeItemReceived(model);
            LogDAO.AddLog(General.ProcessType.ItemRequisitionDeliveryReceived, General.TableName.ItemRequisition, model.ID);
            return true;
        }

        public ItemRequisitionDTO AcknowledgeItemReceivedWithID(int ID)
        {
            return dao.AcknowledgeItemReceivedWithID(ID);
        }

        public bool UpdateItemRequisitionProcurementManager(ItemRequisitionDTO model)
        {
            dao.UpdateItemRequisitionProcurementManager(model);
            LogDAO.AddLog(General.ProcessType.ItemRequisitionProcurementManagerProcessRequest, General.TableName.ItemRequisition, model.ID);
            return true;
        }

        public bool UpdateItemRequisitionProcurementOfficer(ItemRequisitionDTO model)
        {
            dao.UpdateItemRequisitionProcurementOfficer(model);
            LogDAO.AddLog(General.ProcessType.ItemRequisitionProcurementOfficerDeliveryItem, General.TableName.ItemRequisition, model.ID);
            return true;
        }
    }
}
