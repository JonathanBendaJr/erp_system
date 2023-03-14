using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemRequisitionDAO : PostContext
    {
        public int AddItemRequisition(ItemRequisition ir)
        {
            try
            {
                db.ItemRequisitions.Add(ir);
                db.SaveChanges();
                return ir.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<ItemRequisitionDTO> GetItemRequisitions()
        {
            var itemRequisitionList = (from ir in db.ItemRequisitions.Where(x => x.isDeleted == false)
                                          join emp in db.Employees on ir.EmployeeID equals emp.ID
                                          join dep in db.Departments on ir.DepartmentID equals dep.ID
                                          join un in db.UnitOfMeasurements on ir.UnitID equals un.ID
                                          join ur in db.LevelOfUrgencies on ir.UrgencyID equals ur.ID
                                          /*join man in db.Employees on ir.ManagerID equals man.ID
                                          join procman in db.Employees on ir.ProcurementManagerID equals procman.ID
                                          join proc in db.Employees on ir.ProcurementOfficerID equals proc.ID
                                          join mansts in db.RequestStatus on ir.ManagerApprovalID equals mansts.ID
                                          join procmansts in db.RequestStatus on ir.ProcurementManagerApprovalID equals procmansts.ID*/
                                       select new
                                          {
                                              ID = ir.ID,
                                              EmpID = ir.EmployeeID,
                                              EmpName = emp.FName + " "+ emp.LName,
                                              Dept =dep.DepartmentName,
                                              unit =un.MeasuringUnit,
                                              Urgency = ur.LevelOfUrgency1,
                                              ManageID = ir.ManagerID,
                                             /* ManagerName = man.FName + " " + man.LName,
                                              ManagerAppStatus = mansts.RequestStatus,
                                              ProcManID = ir.ProcurementManagerID,
                                              ProcManName = procman.FName + " " + procman.LName,
                                              ProcManAppStatus= procmansts.RequestStatus,
                                              ProcOffID = ir.ProcurementOfficerID,
                                              ProcOffName = proc.FName + " " + proc.LName,*/
                                              Item = ir.Item,
                                              ItemDesc = ir.ItemDescription,
                                              Qty = ir.Quantity,
                                              ManagerAppDate = ir.ManagerApprovalDate,
                                              ManagerAppMessage = ir.ManagerMessage,
                                              ProcManagerAppDate = ir.ProcurementManagerApprovalDate,
                                              ProcManagerAppMessage = ir.ProcurementManagerMessage,
                                              ProcOffDelivered = ir.PocurementOfficerDeliver,
                                              ProcOffDeliveryDate = ir.ProcurementOfficerDeliverDate,
                                              DeliveryQty = ir.DeliveryQuantity,
                                              EmpReceived =ir.EmployeeReceived,
                                              EmpReceivedDate = ir.EmployeeReceivedDate,
                                              AddDate = ir.AddDate
                                          }).OrderByDescending(x => x.AddDate).ToList();
            List<ItemRequisitionDTO> dtolist = new List<ItemRequisitionDTO>();
            foreach (var item in itemRequisitionList)
            {
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.EmployeeName = item.EmpName;
                dto.DepartmentName = item.Dept;
                dto.UnitName = item.unit;
                dto.UrgencyType = item.Urgency;

                /*dto.ManagerName = item.ManagerName;
                dto.ManagerApprovalStatusName = item.ManagerAppStatus;
                dto.ManagerApprovalMessage = item.ManagerAppMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(item.ManagerAppDate);

                dto.ProcurementManagerName = item.ProcManName;
                dto.ProcurementManagerApprovalStatusName = item.ProcManAppStatus;*/
                dto.ProcurementManagerApprovalMessage = item.ProcManagerAppMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(item.ProcManagerAppDate);
              /*  dto.ProcurementOfficerName = item.ProcOffName;*/
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(item.ProcOffDelivered);
                dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(item.ProcOffDeliveryDate);

                dto.Item = item.Item;
                dto.ItemDescription = item.ItemDesc;
                dto.Quantity = Convert.ToDouble(item.Qty);
                dto.DeliverQUantity = Convert.ToDouble(item.DeliveryQty);
                dto.EmployeeReceived = Convert.ToBoolean(item.EmpReceived);
                dto.EmployeeReceivedDate = Convert.ToDateTime(item.EmpReceivedDate);

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public void UpdateItemRequisition(ItemRequisitionDTO model)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == model.ID);
                ir.Item = model.Item;
                ir.ItemDescription = model.ItemDescription;
                ir.Quantity = Convert.ToDecimal(model.Quantity);
                ir.UnitID = model.UnitID;
                ir.UrgencyID = model.UrgencyID;
                ir.LastUpdateDate = DateTime.Now;
                ir.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ItemRequisitionDTO AcknowledgeItemReceivedWithID(int ID)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == ID);
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.ID = ir.ID;
                dto.EmployeeID = ir.EmployeeID;
                dto.Item = ir.Item;
                dto.ItemDescription = ir.ItemDescription;
                dto.Quantity = Convert.ToDouble(ir.Quantity);
                dto.UnitID = ir.UnitID;

                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == dto.UnitID);
                dto.UnitName = um.MeasuringUnit;
                dto.UrgencyID = ir.UrgencyID;

                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == dto.UrgencyID);
                dto.UrgencyType = lou.LevelOfUrgency1;

                EmpDepManSupPosition emp = db.EmpDepManSupPositions.First(x => x.EmployeeID == dto.EmployeeID);
                dto.ManagerID = emp.ManagerRoleID;
                Employee man = db.Employees.First(x => x.ID == dto.ManagerID);
                dto.ManagerName = man.FName + " " + man.LName;
                dto.ManagerApprovalID = Convert.ToInt32(ir.ManagerApprovalID);
                dto.ManagerApprovalMessage = ir.ManagerMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(ir.ManagerApprovalDate);

                dto.ProcurementManagerID = Convert.ToInt32(ir.ProcurementManagerID);
                Employee em = db.Employees.First(x => x.ID == dto.ProcurementManagerID);
                dto.ProcurementManagerName =em.FName +" "+ em.LName;
                dto.ProcurementManagerApprovalID = Convert.ToInt32(ir.ProcurementManagerApprovalID);
                dto.ProcurementManagerApprovalMessage = ir.ProcurementManagerMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(ir.ProcurementManagerApprovalDate);

                dto.ProcurementOfficerID = Convert.ToInt32(ir.ProcurementOfficerID);
                Employee off = db.Employees.First(x => x.ID == dto.ProcurementOfficerID);
                dto.ProcurementManagerName = off.FName + " " + off.LName;
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(ir.PocurementOfficerDeliver);
                dto.DeliverQUantity = Convert.ToDouble(ir.DeliveryQuantity);
                //dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(ir.ProcurementOfficerDeliverDate);

                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AcknowledgeItemReceived(ItemRequisitionDTO model)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == model.ID);
                ir.EmployeeReceived = model.EmployeeReceived;
                ir.EmployeeReceivedDate = DateTime.Now;
                ir.LastUpdateDate = DateTime.Now;
                ir.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateItemRequisitionProcurementOfficer(ItemRequisitionDTO model)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == model.ID);
                ir.ProcurementOfficerID = UserStatic.EmployeeID;
                ir.PocurementOfficerDeliver = model.ProcurementOfficerDeliver;
                ir.DeliveryQuantity = Convert.ToDecimal(model.DeliverQUantity);
                ir.ProcurementOfficerDeliverDate = DateTime.Now;
                ir.LastUpdateDate = DateTime.Now;
                ir.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsApproved()
        {
            var itemRequisitionList = (from ir in db.ItemRequisitions.Where(x => x.isDeleted == false && x.ManagerApprovalID == 1 && x.ProcurementManagerApprovalID == 1)
                                       join emp in db.Employees on ir.EmployeeID equals emp.ID
                                       join dep in db.Departments on ir.DepartmentID equals dep.ID
                                       join un in db.UnitOfMeasurements on ir.UnitID equals un.ID
                                       join ur in db.LevelOfUrgencies on ir.UrgencyID equals ur.ID
                                       /*join man in db.Employees on ir.ManagerID equals man.ID
                                       join procman in db.Employees on ir.ProcurementManagerID equals procman.ID
                                       join proc in db.Employees on ir.ProcurementOfficerID equals proc.ID
                                       join mansts in db.RequestStatus on ir.ManagerApprovalID equals mansts.ID
                                       join procmansts in db.RequestStatus on ir.ProcurementManagerApprovalID equals procmansts.ID*/
                                       select new
                                       {
                                           ID = ir.ID,
                                           EmpID = ir.EmployeeID,
                                           EmpName = emp.FName + " " + emp.LName,
                                           Dept = dep.DepartmentName,
                                           unit = un.MeasuringUnit,
                                           Urgency = ur.LevelOfUrgency1,
                                           ManageID = ir.ManagerID,
                                           /* ManagerName = man.FName + " " + man.LName,
                                            ManagerAppStatus = mansts.RequestStatus,
                                            ProcManID = ir.ProcurementManagerID,
                                            ProcManName = procman.FName + " " + procman.LName,
                                            ProcManAppStatus= procmansts.RequestStatus,
                                            ProcOffID = ir.ProcurementOfficerID,
                                            ProcOffName = proc.FName + " " + proc.LName,*/
                                           Item = ir.Item,
                                           ItemDesc = ir.ItemDescription,
                                           Qty = ir.Quantity,
                                           ManagerAppDate = ir.ManagerApprovalDate,
                                           ManagerAppMessage = ir.ManagerMessage,
                                           ProcManagerAppDate = ir.ProcurementManagerApprovalDate,
                                           ProcManagerAppMessage = ir.ProcurementManagerMessage,
                                           ProcOffDelivered = ir.PocurementOfficerDeliver,
                                           ProcOffDeliveryDate = ir.ProcurementOfficerDeliverDate,
                                           DeliveryQty = ir.DeliveryQuantity,
                                           EmpReceived = ir.EmployeeReceived,
                                           EmpReceivedDate = ir.EmployeeReceivedDate,
                                           AddDate = ir.AddDate
                                       }).OrderByDescending(x => x.AddDate).ToList();
            List<ItemRequisitionDTO> dtolist = new List<ItemRequisitionDTO>();
            foreach (var item in itemRequisitionList)
            {
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.EmployeeName = item.EmpName;
                dto.DepartmentName = item.Dept;
                dto.UnitName = item.unit;

                dto.UrgencyType = item.Urgency;

                /*dto.ManagerName = item.ManagerName;
                dto.ManagerApprovalStatusName = item.ManagerAppStatus;
                dto.ManagerApprovalMessage = item.ManagerAppMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(item.ManagerAppDate);

                dto.ProcurementManagerName = item.ProcManName;
                dto.ProcurementManagerApprovalStatusName = item.ProcManAppStatus;*/
                dto.ProcurementManagerApprovalMessage = item.ProcManagerAppMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(item.ProcManagerAppDate);
                /*  dto.ProcurementOfficerName = item.ProcOffName;*/
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(item.ProcOffDelivered);
                dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(item.ProcOffDeliveryDate);

                dto.Item = item.Item;
                dto.ItemDescription = item.ItemDesc;
                dto.Quantity = Convert.ToDouble(item.Qty);
                dto.DeliverQUantity = Convert.ToDouble(item.DeliveryQty);
                dto.EmployeeReceived = Convert.ToBoolean(item.EmpReceived);
                dto.EmployeeReceivedDate = Convert.ToDateTime(item.EmpReceivedDate);

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public void UpdateItemRequisitionProcurementManager(ItemRequisitionDTO model)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == model.ID);
                ir.ProcurementManagerApprovalID = model.ProcurementManagerApprovalID;
                ir.ProcurementManagerID = UserStatic.EmployeeID;
                ir.ProcurementManagerApprovalDate = DateTime.Now;
                ir.ProcurementManagerMessage = model.ProcurementManagerApprovalMessage;
                ir.LastUpdateDate = DateTime.Now;
                ir.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateItemRequisitionManager(ItemRequisitionDTO model)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == model.ID);
                ir.ManagerApprovalID = model.ManagerApprovalID;
                ir.ManagerID = UserStatic.EmployeeID;
                ir.ManagerApprovalDate = DateTime.Now;
                ir.ManagerMessage = model.ManagerApprovalMessage;
                ir.LastUpdateDate = DateTime.Now;
                ir.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ItemRequisitionDTO UpdateItemRequisitionProcurementOfficerWithID(int ID)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == ID);
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.ID = ir.ID;
                dto.EmployeeID = ir.EmployeeID;
                dto.Item = ir.Item;
                dto.ItemDescription = ir.ItemDescription;
                dto.Quantity = Convert.ToDouble(ir.Quantity);
                dto.UnitID = ir.UnitID;
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == dto.UnitID);
                dto.UnitName = um.MeasuringUnit;
                dto.UrgencyID = ir.UrgencyID;
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == dto.UrgencyID);
                dto.UrgencyType = lou.LevelOfUrgency1;

                EmpDepManSupPosition emp = db.EmpDepManSupPositions.First(x => x.EmployeeID == dto.EmployeeID);
                dto.ManagerID = emp.ManagerRoleID;
                Employee man = db.Employees.First(x => x.ID == dto.ManagerID);
                dto.ManagerName = man.FName + " " + man.LName;
                dto.ManagerApprovalID = Convert.ToInt32(ir.ManagerApprovalID);
                dto.ManagerApprovalMessage = ir.ManagerMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(ir.ManagerApprovalDate);

                dto.ProcurementManagerID = Convert.ToInt32(ir.ProcurementManagerID);
                Employee em = db.Employees.First(x => x.ID == dto.ProcurementManagerID);
                dto.ProcurementManagerName = em.FName + " " + em.LName;
                dto.ProcurementManagerApprovalID = Convert.ToInt32(ir.ProcurementManagerApprovalID);
                dto.ProcurementManagerApprovalMessage = ir.ProcurementManagerMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(ir.ProcurementManagerApprovalDate);

                dto.ProcurementOfficerID = UserStatic.EmployeeID;
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(ir.PocurementOfficerDeliver);
                dto.DeliverQUantity = Convert.ToDouble(ir.DeliveryQuantity);
                //dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(ir.ProcurementOfficerDeliverDate);

                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItemRequisitionDTO UpdateItemRequisitionProcurementManagerWithID(int ID)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == ID);
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.ID = ir.ID;
                dto.EmployeeID = ir.EmployeeID;
                dto.Item = ir.Item;
                dto.ItemDescription = ir.ItemDescription;
                dto.Quantity = Convert.ToDouble(ir.Quantity);
                dto.UnitID = ir.UnitID;
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == dto.UnitID);
                dto.UnitName = um.MeasuringUnit;
                dto.UrgencyID = ir.UrgencyID;
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == dto.UrgencyID);
                dto.UrgencyType = lou.LevelOfUrgency1;

                EmpDepManSupPosition emp = db.EmpDepManSupPositions.First(x => x.EmployeeID == dto.EmployeeID);
                dto.ManagerID = emp.ManagerRoleID;
                Employee man = db.Employees.First(x => x.ID == dto.ManagerID);
                dto.ManagerName = man.FName + " " + man.LName;
                dto.ManagerApprovalID = Convert.ToInt32(ir.ManagerApprovalID);
                dto.ManagerApprovalMessage = ir.ManagerMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(ir.ManagerApprovalDate);
                //dto.ManagerApprovalDate = Convert.ToDateTime(ir.ManagerApprovalDate);

                dto.ProcurementManagerID = UserStatic.EmployeeID;
                dto.ProcurementManagerApprovalID = Convert.ToInt32(ir.ProcurementManagerApprovalID);
                dto.ProcurementManagerApprovalMessage = ir.ProcurementManagerMessage;
                //dto.ProcurementManagerApprovalDate = Convert.ToDateTime(ir.ProcurementManagerApprovalDate);

                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItemRequisitionDTO UpdateItemRequisitionManagerWithID(int ID)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == ID);
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.ID = ir.ID;
                dto.EmployeeID = ir.EmployeeID;
                dto.Item = ir.Item;
                dto.ItemDescription = ir.ItemDescription;
                dto.Quantity = Convert.ToDouble(ir.Quantity);
                dto.UnitID = ir.UnitID;
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == dto.UnitID);
                dto.UnitName = um.MeasuringUnit;
                dto.UrgencyID = ir.UrgencyID;
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == dto.UrgencyID);
                dto.UrgencyType = lou.LevelOfUrgency1;
                EmpDepManSupPosition emp = db.EmpDepManSupPositions.First(x => x.EmployeeID == dto.EmployeeID);
                dto.ManagerID = emp.ManagerRoleID;
                dto.ManagerApprovalID = Convert.ToInt32(ir.ManagerApprovalID);
                dto.ManagerApprovalMessage = ir.ManagerMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(ir.ManagerApprovalDate);
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItemRequisitionDTO UpdateItemRequisitionWithID(int ID)
        {
            try
            {
                ItemRequisition ir = db.ItemRequisitions.First(x => x.ID == ID);
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.ID = ir.ID;
                dto.EmployeeID = ir.EmployeeID;
                dto.Item = ir.Item;
                dto.ItemDescription = ir.ItemDescription;
                dto.Quantity = Convert.ToDouble(ir.Quantity);
                dto.UnitID = ir.UnitID;
                dto.UrgencyID = ir.UrgencyID;
                dto.EmployeeReceived = Convert.ToBoolean(ir.EmployeeReceived);
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsPerDepartment()
        {
            var itemRequisitionList = (from ir in db.ItemRequisitions.Where(x => x.isDeleted == false && x.DepartmentID == UserStatic.DepartmentID)
                                       join emp in db.Employees on ir.EmployeeID equals emp.ID
                                       join dep in db.Departments on ir.DepartmentID equals dep.ID
                                       join un in db.UnitOfMeasurements on ir.UnitID equals un.ID
                                       join ur in db.LevelOfUrgencies on ir.UrgencyID equals ur.ID
                                       /*join man in db.Employees on ir.ManagerID equals man.ID
                                       join procman in db.Employees on ir.ProcurementManagerID equals procman.ID
                                       join proc in db.Employees on ir.ProcurementOfficerID equals proc.ID
                                       join mansts in db.RequestStatus on ir.ManagerApprovalID equals mansts.ID
                                       join procmansts in db.RequestStatus on ir.ProcurementManagerApprovalID equals procmansts.ID*/
                                       select new
                                       {
                                           ID = ir.ID,
                                           EmpID = ir.EmployeeID,
                                           EmpName = emp.FName + " " + emp.LName,
                                           Dept = dep.DepartmentName,
                                           unit = un.MeasuringUnit,
                                           Urgency = ur.LevelOfUrgency1,
                                           ManageID = ir.ManagerID,
                                           /*ManagerName = man.FName + " " + man.LName,
                                           ManagerAppStatus = mansts.RequestStatus,
                                           ProcManID = ir.ProcurementManagerID,
                                           ProcManName = procman.FName + " " + procman.LName,
                                           ProcManAppStatus = procmansts.RequestStatus,
                                           ProcOffID = ir.ProcurementOfficerID,
                                           ProcOffName = proc.FName + " " + proc.LName,*/
                                           Item = ir.Item,
                                           ItemDesc = ir.ItemDescription,
                                           Qty = ir.Quantity,
                                           ManagerAppDate = ir.ManagerApprovalDate,
                                           ManagerAppMessage = ir.ManagerMessage,
                                           ProcManagerAppDate = ir.ProcurementManagerApprovalDate,
                                           ProcManagerAppMessage = ir.ProcurementManagerMessage,
                                           ProcOffDelivered = ir.PocurementOfficerDeliver,
                                           ProcOffDeliveryDate = ir.ProcurementOfficerDeliverDate,
                                           DeliveryQty = ir.DeliveryQuantity,
                                           EmpReceived = ir.EmployeeReceived,
                                           EmpReceivedDate = ir.EmployeeReceivedDate,
                                           AddDate = ir.AddDate
                                       }).OrderByDescending(x => x.AddDate).ToList();
            List<ItemRequisitionDTO> dtolist = new List<ItemRequisitionDTO>();
            foreach (var item in itemRequisitionList)
            {
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.EmployeeName = item.EmpName;
                dto.DepartmentName = item.Dept;
                dto.UnitName = item.unit;
                dto.UrgencyType = item.Urgency;
                /*dto.ManagerName = item.ManagerName;
                dto.ManagerApprovalStatusName = item.ManagerAppStatus;
                dto.ManagerApprovalMessage = item.ManagerAppMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(item.ManagerAppDate);

                dto.ProcurementManagerName = item.ProcManName;
                dto.ProcurementManagerApprovalStatusName = item.ProcManAppStatus;
                dto.ProcurementManagerApprovalMessage = item.ProcManagerAppMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(item.ProcManagerAppDate);
                dto.ProcurementOfficerName = item.ProcOffName;
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(item.ProcOffDelivered);
                dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(item.ProcOffDeliveryDate);*/

                dto.Item = item.Item;
                dto.ItemDescription = item.ItemDesc;
                dto.Quantity = Convert.ToDouble(item.Qty);
                dto.DeliverQUantity = Convert.ToDouble(item.DeliveryQty);
                dto.EmployeeReceived = Convert.ToBoolean(item.EmpReceived);
                dto.EmployeeReceivedDate = Convert.ToDateTime(item.EmpReceivedDate);

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public List<ItemRequisitionDTO> GetItemRequisitionsPerLoginUser()
        {
            var itemRequisitionList = (from ir in db.ItemRequisitions.Where(x => x.isDeleted == false && x.EmployeeID == UserStatic.EmployeeID)
                                       join emp in db.Employees on ir.EmployeeID equals emp.ID
                                       join dep in db.Departments on ir.DepartmentID equals dep.ID
                                       join un in db.UnitOfMeasurements on ir.UnitID equals un.ID
                                       join ur in db.LevelOfUrgencies on ir.UrgencyID equals ur.ID
                                       /*join man in db.Employees on ir.ManagerID equals man.ID
                                       join procman in db.Employees on ir.ProcurementManagerID equals procman.ID
                                       join proc in db.Employees on ir.ProcurementOfficerID equals proc.ID
                                       join mansts in db.RequestStatus on ir.ManagerApprovalID equals mansts.ID
                                       join procmansts in db.RequestStatus on ir.ProcurementManagerApprovalID equals procmansts.ID*/
                                       select new
                                       {
                                           ID = ir.ID,
                                           EmpID = ir.EmployeeID,
                                           EmpName = emp.FName + " " + emp.LName,
                                           Dept = dep.DepartmentName,
                                           unit = un.MeasuringUnit,
                                           Urgency = ur.LevelOfUrgency1,
                                           ManageID = ir.ManagerID,
                                          /* ManagerName = man.FName + " " + man.LName,
                                           ManagerAppStatus = mansts.RequestStatus,
                                           ProcManID = ir.ProcurementManagerID,
                                           ProcManName = procman.FName + " " + procman.LName,
                                           ProcManAppStatus = procmansts.RequestStatus,
                                           ProcOffID = ir.ProcurementOfficerID,
                                           ProcOffName = proc.FName + " " + proc.LName,*/
                                           Item = ir.Item,
                                           ItemDesc = ir.ItemDescription,
                                           Qty = ir.Quantity,
                                           ManagerAppDate = ir.ManagerApprovalDate,
                                           ManagerAppMessage = ir.ManagerMessage,
                                           ProcManagerAppDate = ir.ProcurementManagerApprovalDate,
                                           ProcManagerAppMessage = ir.ProcurementManagerMessage,
                                           ProcOffDelivered = ir.PocurementOfficerDeliver,
                                           ProcOffDeliveryDate = ir.ProcurementOfficerDeliverDate,
                                           DeliveryQty = ir.DeliveryQuantity,
                                           EmpReceived = ir.EmployeeReceived,
                                           EmpReceivedDate = ir.EmployeeReceivedDate,
                                           AddDate = ir.AddDate
                                       }).OrderByDescending(x => x.AddDate).ToList();
            List<ItemRequisitionDTO> dtolist = new List<ItemRequisitionDTO>();
            foreach (var item in itemRequisitionList)
            {
                ItemRequisitionDTO dto = new ItemRequisitionDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.EmployeeName = item.EmpName;
                dto.DepartmentName = item.Dept;
                dto.UnitName = item.unit;
                dto.UrgencyType = item.Urgency;
                /*dto.ManagerName = item.ManagerName;
                dto.ManagerApprovalStatusName = item.ManagerAppStatus;
                dto.ManagerApprovalMessage = item.ManagerAppMessage;
                dto.ManagerApprovalDate = Convert.ToDateTime(item.ManagerAppDate);

                dto.ProcurementManagerName = item.ProcManName;
                dto.ProcurementManagerApprovalStatusName = item.ProcManAppStatus;
                dto.ProcurementManagerApprovalMessage = item.ProcManagerAppMessage;
                dto.ProcurementManagerApprovalDate = Convert.ToDateTime(item.ProcManagerAppDate);
                dto.ProcurementOfficerName = item.ProcOffName;
                dto.ProcurementOfficerDeliver = Convert.ToBoolean(item.ProcOffDelivered);
                dto.ProcurementOfficerDeliveryDate = Convert.ToDateTime(item.ProcOffDeliveryDate);*/

                dto.Item = item.Item;
                dto.ItemDescription = item.ItemDesc;
                dto.Quantity = Convert.ToDouble(item.Qty);
                dto.DeliverQUantity = Convert.ToDouble(item.DeliveryQty);
                dto.EmployeeReceived = Convert.ToBoolean(item.EmpReceived);
                dto.EmployeeReceivedDate = Convert.ToDateTime(item.EmpReceivedDate);

                dtolist.Add(dto);
            }
            return dtolist;
        }
    }
}
