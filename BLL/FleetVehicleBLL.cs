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
    public class FleetVehicleBLL
    {
        FleetVehicleDAO dao = new FleetVehicleDAO();
        public static IEnumerable<SelectListItem> GetTypeListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetTypeListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetOwnershipStatusListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetOwnershipStatusListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetUnitListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetUnitListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetVehicleStatusListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetVehicleStatusListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetRegistrationStatusListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetRegistrationStatusListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetReceivedConditionListForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetReceivedConditionListForDropdown();
        }

        public void AddFleetVehicle(FleetVehicleDTO model)
        {
            FleetVehicle fv = new FleetVehicle();
            fv.VehicleCode = model.VehicleCode;
            fv.VehicleStatusID = model.VehicleStatusID;
            fv.UnitID = model.UnitID;
            fv.OwnershipStatusID = model.OwnershipStatusID;
            fv.Model = model.Model;
            fv.Make = model.Make;
            fv.Year = model.Year;
            fv.TypeID = model.TypeID;
            fv.VIN = model.VIN;
            fv.Mileage = Convert.ToDecimal(model.Mileage);
            fv.Color = model.Color;
            fv.FuelTankSize = model.FuelTankSize;
            fv.FuelTankType = model.FuelTankType;
            fv.RecieveDate = model.ReceivedDate;
            fv.RecieveConditionID = model.ReceivedConditionID;
            fv.RegistrationStatusID = model.RegistrationStatusID;
            fv.PlateNumber = model.PlateNumber;
            fv.AddDate = DateTime.Now;
            fv.LastUpdateDate = DateTime.Now;
            fv.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicle(fv);

            LogDAO.AddLog(General.ProcessType.FleetVehicleAdd, General.TableName.FleetVehicle, ID);
        }

        public FleetVehicleDTO UpdateFleetVehicleWithID(int ID)
        {
            return dao.UpdateFleetVehicleWithID(ID);
        }

        public FleetVehicleDTO GetFleetVehicleDetailsByID(int ID)
        {
            return dao.GetFleetVehicleDetailsByID(ID);
        }

        public List<FleetVehicleDTO> GetFleetVehicles()
        {
            return dao.GetFleetVehicles();
        }

        public void UpdateFleetVehicle(FleetVehicleDTO model)
        {
            dao.UpdateFleetVehicle(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleUpdate, General.TableName.FleetVehicle, model.ID);
        }

        public void DeleteFleetVehicle(int ID)
        {
            dao.DeleteFleetVehicle(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleDelete, General.TableName.FleetVehicle, ID);
        }

        public FleetVehicleDTO ViewFleetVehicleCardWithID(int ID)
        {
            return dao.GetFleetVehicleDetailsByID(ID);
        }
    }
}
