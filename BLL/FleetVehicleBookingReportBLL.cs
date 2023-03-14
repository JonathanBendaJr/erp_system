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
    public class FleetVehicleBookingReportBLL
    {
        FleetVehicleBookingReportDAO dao = new FleetVehicleBookingReportDAO();
        /*public static IEnumerable<SelectListItem> GetIncidentsForDropdown()
        {
            return (List<SelectListItem>)IncidentTypeDAO.GetApprovalsForDropdown();
        }*/

        public static IEnumerable<SelectListItem> GetApprovalsForDropdown()
        {
            return (List<SelectListItem>)RequestActionDAO.GetApprovalsForDropdown();
        }

        public bool AddFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            FleetVehicleBookingReport fvbr = new FleetVehicleBookingReport();
            fvbr.BookingID = model.BookingID;
            fvbr.DispatchDate = model.DispatchDate;
            fvbr.DispatchTime = model.DispacthTime;
            fvbr.ReturnDate = model.ReturnDate;
            fvbr.ReturnTime = model.ReturnTime;
            fvbr.ReportDescription = model.ReportDetails;
            fvbr.DriverID = UserStatic.EmployeeID;
            fvbr.AddDate = DateTime.Now;
            fvbr.LastUpdateDate = DateTime.Now;
            fvbr.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleBookingReport(fvbr);

            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingReportAdd, General.TableName.FleetVehicleBookingReport, ID);
            return true;
        }

        public List<FleetVehicleBookingReportDTO> GetFleetVehicleBookingReports()
        {
            return dao.GetFleetVehicleBookingReports();
        }

        public FleetVehicleBookingReportDTO UpdateFleetVehicleBookingReportWithID(int ID)
        {
            return dao.UpdateFleetVehicleBookingReportWithID(ID);
        }

        public bool UpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            dao.UpdateFleetVehicleBookingReport(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingReportUpdate, General.TableName.FleetVehicleBookingReport, model.ID);
            return true;
        }

        public void DeleteFleetVehicleBookingReport(int ID)
        {
            dao.DeleteFleetVehicleBookingReport(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingReportDelete, General.TableName.FleetVehicleBookingReport, ID);
        }

        public List<FleetVehicleBookingReportDTO> GetFleetVehicleBookingReportsForFleetManager()
        {
            return dao.GetFleetVehicleBookingReports();
        }

        public FleetVehicleBookingReportDTO FleetManagerUpdateFleetVehicleBookingReportWithID(int ID)
        {
            return dao.FleetManagerUpdateFleetVehicleBookingReportWithID(ID);
        }

        public bool FleetManagerUpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            dao.FleetManagerUpdateFleetVehicleBookingReport(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleBookingReportFleetManagerUpdate, General.TableName.FleetVehicleBookingReport, model.ID);
            return true;
        }

        public FleetVehicleBookingReportDTO FleetVehicleBookingReportDetailWithID(int ID)
        {
            return dao.FleetVehicleBookingReportDetailWithID(ID);
        }
    }
}
