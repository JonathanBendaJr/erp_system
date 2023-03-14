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
    public class FleetVehicleMaintenanceRequestBLL
    {
        FleetVehicleMaintenanceRequestDAO dao = new FleetVehicleMaintenanceRequestDAO();
        public bool AddFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequestDTO model)
        {
            FleetVehicleMaintenanceRequest fvbr = new FleetVehicleMaintenanceRequest();
            fvbr.VehicleID = model.VehicleID;
            fvbr.VehicleStatusID = model.VehicleStatusID;
            fvbr.MaintenanceDetail = model.MaintenanceDetail;
            fvbr.DueDate = model.DueDate;            
            fvbr.DriverID = UserStatic.EmployeeID;
            fvbr.AddDate = DateTime.Now;
            fvbr.LastUpdateDate = DateTime.Now;
            fvbr.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleMaintenanceRequest(fvbr);

            LogDAO.AddLog(General.ProcessType.FleetVehicleMaintenanceRequestAdd, General.TableName.FleetVehicleMaintenanceRequest, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetApprovalsForDropdown()
        {
            return (List<SelectListItem>)RequestActionDAO.GetApprovalsForDropdown();
        }

        public static IEnumerable<SelectListItem> GetVehiclesForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetVehiclesForDropdown();

        }

        public static IEnumerable<SelectListItem> GetVehicleStatusForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleStatusDAO.GetVehicleStatusForDropdown();

        }

        public List<FleetVehicleMaintenanceRequestDTO> GetFleetVehicleMaintenanceRequests()
        {
            return dao.GetFleetVehicleMaintenanceRequests();
        }

        public FleetVehicleMaintenanceRequestDTO UpdateFleetVehicleMaintenanceRequestWithID(int ID)
        {
            return dao.UpdateFleetVehicleMaintenanceRequestWithID(ID);
        }

        public bool UpdateFleetVehicleMaintenanceRequest(FleetVehicleMaintenanceRequestDTO model)
        {
            dao.UpdateFleetVehicleMaintenanceRequest(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleMaintenanceRequestUpdate, General.TableName.FleetVehicleMaintenanceRequest, model.ID);
            return true;
        }

        public void DeleteFleetVehicleMaintenanceRequest(int ID)
        {
            dao.DeleteFleetVehicleMaintenanceRequest(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleMaintenanceRequestDelete, General.TableName.FleetVehicleMaintenanceRequest, ID);
        }
    }
}
