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
    public class FleetVehicleDriverBLL
    {
        FleetVehicleDriverDAO dao = new FleetVehicleDriverDAO();
        public static IEnumerable<SelectListItem> GetVehiclesForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetVehiclesForDropdown();
        }

        public static IEnumerable<SelectListItem> GetDriversForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetDriversForDropdown();
        }

        public bool AddFleetVehicleDriver(FleetVehicleDriverDTO model)
        {
            FleetDriverVehicleAssignment fvd = new FleetDriverVehicleAssignment();
            fvd.DriverID = model.DriverID;
            fvd.VehicleID = model.VehicleID;
            fvd.AddDate = DateTime.Now;
            fvd.LastUpdateDate = DateTime.Now;
            fvd.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleDriver(fvd);

            LogDAO.AddLog(General.ProcessType.FleetVehicleDriverAdd, General.TableName.FleetVehicleDriver, ID);
            return true;
        }

        public List<FleetVehicleDriverDTO> GetFleetVehiclesDrivers()
        {
            return dao.GetFleetVehiclesDrivers();
        }

        public FleetVehicleDriverDTO UpdateFleetVehicleDriverWithID(int ID)
        {
            return dao.UpdateFleetVehicleDriverWithID(ID);
        }

        public bool UpdateFleetVehicleDriver(FleetVehicleDriverDTO model)
        {
            dao.UpdateFleetVehicleDriver(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleDriverUpdate, General.TableName.FleetVehicleDriver, model.ID);
            return true;
        }

        public void DeleteFleetVehicleDriver(int ID)
        {
            dao.DeleteFleetVehicleDriver(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleDriverDelete, General.TableName.FleetVehicleDriver, ID);
        }
    }
}
