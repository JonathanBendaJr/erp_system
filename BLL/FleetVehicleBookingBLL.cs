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
    public class FleetVehicleBookingBLL
    {
        FleetVehicleBookingDAO dao = new FleetVehicleBookingDAO();
        public bool AddFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            FleetVehicleBookingRequest fvbr = new FleetVehicleBookingRequest();
            fvbr.EmployeeID = UserStatic.EmployeeID;
            fvbr.DepartmentID = UserStatic.DepartmentID;
            fvbr.Location = model.Location;
            fvbr.CountyID = model.CountyID;
            fvbr.BookingDescription = model.BookingDescription;
            fvbr.FromDate = model.FromDate;
            fvbr.ToDate = model.ToDate;
            fvbr.AssignedDriverID = model.AssignedDriverID;
            fvbr.AssignedVehicleID = model.AssignedVehicleID;
            fvbr.BookingDate = DateTime.Now;
            fvbr.AddDate = DateTime.Now;
            fvbr.LastUpdateDate = DateTime.Now;
            fvbr.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleBooking(fvbr);

            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingAdd, General.TableName.FleetVehicleBooking, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetApprovalsForDropdown()
        {
            return (List<SelectListItem>)RequestActionDAO.GetApprovalsForDropdown();
        }

        public static IEnumerable<SelectListItem> GetCountiesForDropdown()
        {
            return (List<SelectListItem>)CountyDAO.GetCountiesForDropdown();
        }

        public static IEnumerable<SelectListItem> GetDriversForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetDriversForDropdown();
        }

        public static IEnumerable<SelectListItem> GetVehiclesForDropdown()
        {
            return (List<SelectListItem>)FleetVehicleDAO.GetVehiclesForDropdown();
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookings()
        {
            return dao.GetFleetVehicleBookings();
        }

        public FleetVehicleBookingDTO UpdateFleetVehicleBookingWithID(int ID)
        {
            return dao.UpdateFleetVehicleBookingWithID(ID);
        }

        public bool UpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            dao.UpdateFleetVehicleBooking(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingUpdate, General.TableName.FleetVehicleBooking, model.ID);
            return true;
        }

        public void DeleteFleetVehicleBooking(int ID)
        {
            dao.DeleteFleetVehicleBooking(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingDelete, General.TableName.FleetVehicleBooking, ID);
        }

        public FleetVehicleBookingDTO DeptManagerUpdateFleetVehicleBooking(int ID)
        {
            return dao.DeptManagerUpdateFleetVehicleBooking(ID);
        }

        public bool DeptManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            dao.DeptManagerUpdateFleetVehicleBooking(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingDepartmentManagerApprovalUpdate, General.TableName.FleetVehicleBooking, model.ID);
            return true;
        }

        public FleetVehicleBookingDTO FleetManagerUpdateFleetVehicleBooking(int ID)
        {
            return dao.DeptManagerUpdateFleetVehicleBooking(ID);
        }

        public bool FleetManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            dao.FleetManagerUpdateFleetVehicleBooking(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingFleetManagerApprovalUpdate, General.TableName.FleetVehicleBooking, model.ID);
            return true;
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForDeptManager()
        {
            return dao.GetFleetVehicleBookingsForDeptManager();
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForFleetManager()
        {
            return dao.GetFleetVehicleBookingsForFleetManager();
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForFleetDriver()
        {
            return dao.GetFleetVehicleBookingsForFleetDriver();
        }

        public FleetVehicleBookingDTO FleetVehicleBookingDetailWithID(int ID)
        {
            return dao.FleetVehicleBookingDetailWithID(ID);
        }

        public FleetVehicleBookingDTO DeptManagerFleetVehicleBookingDetailWithID(int ID)
        {
            return dao.DeptManagerFleetVehicleBookingDetailWithID(ID);
        }

        public FleetVehicleBookingDTO FleetManagerFleetVehicleBookingDetailWithID(int ID)
        {
            return dao.FleetManagerFleetVehicleBookingDetailWithID(ID);
        }

        public FleetVehicleBookingDTO DriverFleetVehicleBookingDetailWithID(int ID)
        {
            return dao.DriverFleetVehicleBookingDetailWithID(ID);
        }
    }
}
