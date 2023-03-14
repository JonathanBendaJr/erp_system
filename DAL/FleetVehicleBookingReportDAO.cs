using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleBookingReportDAO : PostContext
    {
        public int AddFleetVehicleBookingReport(FleetVehicleBookingReport fvbr)
        {
            try
            {
                db.FleetVehicleBookingReports.Add(fvbr);
                db.SaveChanges();
                return fvbr.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleBookingReportDTO> GetFleetVehicleBookingReports()
        {
            var fleetVehicleBookingReportList = (from fvbr in db.FleetVehicleBookingReports.Where(x => x.isDeleted == false)
                                           join drv in db.Employees on fvbr.DriverID equals drv.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join fmas in db.RequestActions on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               driverID = fvbr.DriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               dispacthDate = fvbr.DispatchDate,
                                               dispatchTime = fvbr.DispatchTime,
                                               reportDetails = fvbr.ReportDescription,
                                               returnDate = fvbr.ReturnDate,
                                               returnTime = fvbr.ReturnTime,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.Action,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.AddDate).ToList();
            List<FleetVehicleBookingReportDTO> dtolist = new List<FleetVehicleBookingReportDTO>();
            foreach (var item in fleetVehicleBookingReportList)
            {
                FleetVehicleBookingReportDTO dto = new FleetVehicleBookingReportDTO();
                dto.ID = item.ID;
                dto.DriverID = Convert.ToInt32(item.driverID);
                dto.DriverName = item.driverName;
                dto.DispatchDate = item.dispacthDate;
                dto.DispacthTime = item.dispatchTime;
                dto.ReturnTime = item.returnTime;
                dto.ReturnDate = item.returnDate;
                dto.ReportDetails = item.reportDetails;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleBookingReportDTO FleetVehicleBookingReportDetailWithID(int ID)
        {
            var fleetVehicleBookingReportDetails = (from fvbr in db.FleetVehicleBookingReports.Where(x => x.isDeleted == false && x.ID ==ID)
                                                 join drv in db.Employees on fvbr.DriverID equals drv.ID
                                                 join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                                 join fmas in db.RequestActions on fvbr.FleetManagerApprovalID equals fmas.ID
                                                 select new
                                                 {
                                                     ID = fvbr.ID,
                                                     driverID = fvbr.DriverID,
                                                     driverName = drv.FName + " " + drv.LName,
                                                     dispacthDate = fvbr.DispatchDate,
                                                     dispatchTime = fvbr.DispatchTime,
                                                     returnDate = fvbr.ReturnDate,
                                                     returnTime = fvbr.ReturnTime,
                                                     reportDetails = fvbr.ReportDescription,
                                                     fleetManID = fvbr.FleetManagerID,
                                                     fleetManagerName = fm.FName + " " + fm.LName,
                                                     fleetManAppID = fvbr.FleetManagerApprovalID,
                                                     fleetManagerAppStatus = fmas.Action,
                                                     fleetManagerMessage = fvbr.FleetManagerMessage,
                                                     AddDate = fvbr.AddDate
                                                 }).OrderByDescending(x => x.AddDate).ToList();
            FleetVehicleBookingReportDTO dto = new FleetVehicleBookingReportDTO();
            foreach (var item in fleetVehicleBookingReportDetails)
            {
                dto.ID = item.ID;
                dto.DriverID = Convert.ToInt32(item.driverID);
                dto.DriverName = item.driverName;
                dto.DispatchDate = item.dispacthDate;
                dto.DispacthTime = item.dispatchTime;
                dto.ReturnTime = item.returnTime;
                dto.ReturnDate = item.returnDate;
                dto.ReportDetails = item.reportDetails;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

            }
            return dto;
        }

        public void FleetManagerUpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            try
            {
                FleetVehicleBookingReport fvbr = db.FleetVehicleBookingReports.First(x => x.ID == model.ID);
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

        public FleetVehicleBookingReportDTO FleetManagerUpdateFleetVehicleBookingReportWithID(int ID)
        {
            try
            {
                FleetVehicleBookingReport fvbr = db.FleetVehicleBookingReports.First(x => x.ID == ID);
                FleetVehicleBookingReportDTO dto = new FleetVehicleBookingReportDTO();
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

        

        public FleetVehicleBookingReportDTO UpdateFleetVehicleBookingReportWithID(int ID)
        {
            try
            {
                FleetVehicleBookingReport fvbr = db.FleetVehicleBookingReports.First(x => x.ID == ID);
                FleetVehicleBookingReportDTO dto = new FleetVehicleBookingReportDTO();
                dto.ID = fvbr.ID;
                dto.BookingID = fvbr.BookingID;
                dto.DispatchDate = fvbr.DispatchDate;
                dto.DispacthTime = fvbr.DispatchTime;
                dto.ReturnDate = fvbr.ReturnDate;
                dto.ReturnTime = fvbr.ReturnTime;
                dto.ReportDetails = fvbr.ReportDescription;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleBookingReport(FleetVehicleBookingReportDTO model)
        {
            try
            {
                FleetVehicleBookingReport fvbr = db.FleetVehicleBookingReports.First(x => x.ID == model.ID);
                fvbr.DispatchDate = model.DispatchDate;
                fvbr.DispatchTime = model.DispacthTime;
                fvbr.ReturnDate = model.ReturnDate;
                fvbr.ReturnTime = model.ReturnTime;
                fvbr.ReportDescription = model.ReportDetails;
                fvbr.LastUpdateDate = DateTime.Now;
                fvbr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFleetVehicleBookingReport(int ID)
        {
            try
            {
                FleetVehicleBookingReport fvbr = db.FleetVehicleBookingReports.First(x => x.ID == ID);
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
