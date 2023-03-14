using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleMaintenanceRequestDAO : PostContext
    {
        public List<FleetVehicleMaintenanceRequestDTO> GetFleetVehicleMaintenanceRequests()
        {
            var fleetVehicleMaintenanceRequestList = (from fvbr in db.FleetVehicleMaintenanceRequests.Where(x => x.isDeleted == false)
                                                 join drv in db.Employees on fvbr.DriverID equals drv.ID
                                                 join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                                 join fmas in db.RequestActions on fvbr.FleetManagerApprovalID equals fmas.ID
                                                 join veh in db.FleetVehicles on fvbr.VehicleID equals veh.ID
                                                 join vhs in db.FleetVehicleStatus on fvbr.VehicleStatusID equals vhs.ID
                                                 select new
                                                 {
                                                     ID = fvbr.ID,
                                                     driverID = fvbr.DriverID,
                                                     driverName = drv.FName + " " + drv.LName,
                                                     vehicleID = fvbr.VehicleID,
                                                     vehicleCode = veh.VehicleCode,
                                                     vehicleStatusID = fvbr.VehicleStatusID,
                                                     vehicleStatus = vhs.Status,
                                                     fleetManID = fvbr.FleetManagerID,
                                                     fleetManagerName = fm.FName + " " + fm.LName,
                                                     fleetManAppID = fvbr.FleetManagerApprovalID,
                                                     fleetManagerAppStatus = fmas.Action,
                                                     fleetManagerMessage = fvbr.FleetManagerMessage,
                                                     maintenanceDetials = fvbr.MaintenanceDetail,
                                                     dueDate =  fvbr.DueDate,
                                                     AddDate = fvbr.AddDate
                                                 }).OrderByDescending(x => x.AddDate).ToList();
            List<FleetVehicleMaintenanceRequestDTO> dtolist = new List<FleetVehicleMaintenanceRequestDTO>();
            foreach (var item in fleetVehicleMaintenanceRequestList)
            {
                FleetVehicleMaintenanceRequestDTO dto = new FleetVehicleMaintenanceRequestDTO();
                dto.ID = item.ID;
                dto.DriverID = Convert.ToInt32(item.driverID);
                dto.DriverName = item.driverName;
                dto.VehicleID = item.vehicleID;
                dto.VehicleCode = item.vehicleCode;
                dto.VehicleStatusID = item.vehicleStatusID;
                dto.VehicleStatus = item.vehicleStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
                dto.MaintenanceDetail = item.maintenanceDetials;
                dto.DueDate = Convert.ToDateTime(item.dueDate);
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleMaintenanceRequestDTO UpdateFleetVehicleMaintenanceRequestWithID(int ID)
        {
            try
            {
                FleetVehicleMaintenanceRequest fvbr = db.FleetVehicleMaintenanceRequests.First(x => x.ID == ID);
                FleetVehicleMaintenanceRequestDTO dto = new FleetVehicleMaintenanceRequestDTO();
                dto.ID = fvbr.ID;
                dto.DueDate = Convert.ToDateTime(fvbr.DueDate);
                dto.VehicleID = fvbr.VehicleID;
                dto.VehicleStatusID = fvbr.VehicleStatusID;
                dto.MaintenanceDetail = fvbr.MaintenanceDetail;
                dto.DriverID = Convert.ToInt32(fvbr.DriverID);
                dto.FleetManagerApprovalID = Convert.ToInt32(fvbr.FleetManagerApprovalID);
                dto.FleetManagerID = Convert.ToInt32(fvbr.FleetManagerID);
                dto.FleetManagerMessage = fvbr.FleetManagerMessage;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequest fvbr)
        {
            try
            {
                db.FleetVehicleMaintenanceRequests.Add(fvbr);
                db.SaveChanges();
                return fvbr.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequestDTO model)
        {
            try
            {
                FleetVehicleMaintenanceRequest fvbr = db.FleetVehicleMaintenanceRequests.First(x => x.ID == model.ID);
                fvbr.VehicleStatusID = model.VehicleStatusID;
                fvbr.VehicleID = model.VehicleID;
                fvbr.DueDate = model.DueDate;
                fvbr.MaintenanceDetail = model.MaintenanceDetail;
                fvbr.FleetManagerApprovalID = model.FleetManagerApprovalID;
                fvbr.FleetManagerID = UserStatic.EmployeeID;
                fvbr.FleetManagerMessage = model.FleetManagerMessage;
                fvbr.LastUpdateDate = DateTime.Now;
                fvbr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFleetVehicleMaintenanceRequest(int ID)
        {
            try
            {
                FleetVehicleMaintenanceRequest fvbr = db.FleetVehicleMaintenanceRequests.First(x => x.ID == ID);
                fvbr.isDeleted = true;
                fvbr.DeletedDate = DateTime.Now;
                fvbr.LastUpdateDate = DateTime.Now;
                fvbr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
