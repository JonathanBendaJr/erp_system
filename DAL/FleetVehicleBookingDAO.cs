using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleBookingDAO : PostContext
    {
        public int AddFleetVehicleBooking(FleetVehicleBookingRequest fvbr)
        {
            try
            {
                db.FleetVehicleBookingRequests.Add(fvbr);
                db.SaveChanges();
                return fvbr.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookings()
        {
            var fleetVehicleBookingList = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.EmployeeID == UserStatic.EmployeeID)
                                          join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                           join em in db.Employees on fvbr.EmployeeID equals em.ID
                                           join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                           join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                          join ct in db.Counties on fvbr.CountyID equals ct.ID
                                          join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                          join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                          join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                          join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                          select new
                                          {
                                              ID = fvbr.ID,
                                              EmpName = em.FName + " " + em.LName,
                                              DeptName = dept.DepartmentName,
                                              driverID = fvbr.AssignedDriverID,
                                              driverName = drv.FName + " " + drv.LName,
                                              vehID = fvbr.AssignedVehicleID,
                                              vehCode = veh.VehicleCode,
                                              location = fvbr.Location,
                                              bookDate = fvbr.BookingDate,
                                              bookingDesc = fvbr.BookingDescription,
                                              frmDate = fvbr.FromDate,
                                              toDate= fvbr.ToDate,
                                              depManID = fvbr.DepartmentManagerID,
                                              deptManagerName = dm.FName +" "+ dm.LName,
                                              depManAppID = fvbr.DepartmentManagerApprovalID,
                                              deptManagerAppStatus = dmas.RequestStatus,
                                              deptManagerMessage = fvbr.DepartmentManagerMessage,
                                              fleetManID = fvbr.FleetManagerID,
                                              fleetManagerName = fm.FName +" "+ fm.LName,
                                              fleetManAppID = fvbr.FleetManagerApprovalID,
                                              fleetManagerAppStatus = fmas.RequestStatus,
                                              fleetManagerMessage = fvbr.FleetManagerMessage,
                                              AddDate = fvbr.AddDate
                                          }).OrderByDescending(x => x.bookDate).ToList();
            List<FleetVehicleBookingDTO> dtolist = new List<FleetVehicleBookingDTO>();
            foreach (var item in fleetVehicleBookingList)
            {
                FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleBookingDTO DriverFleetVehicleBookingDetailWithID(int ID)
        {
            var fleetVehicleBookingDetail = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.ID == ID && x.AssignedDriverID == UserStatic.EmployeeID)
                                             join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                             join em in db.Employees on fvbr.EmployeeID equals em.ID
                                             join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                             join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                             join ct in db.Counties on fvbr.CountyID equals ct.ID
                                             join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                             join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                             join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                             join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                             select new
                                             {
                                                 ID = fvbr.ID,
                                                 EmpName = em.FName + " " + em.LName,
                                                 DeptName = dept.DepartmentName,
                                                 driverID = fvbr.AssignedDriverID,
                                                 driverName = drv.FName + " " + drv.LName,
                                                 vehID = fvbr.AssignedVehicleID,
                                                 vehCode = veh.VehicleCode,
                                                 location = fvbr.Location,
                                                 bookDate = fvbr.BookingDate,
                                                 bookingDesc = fvbr.BookingDescription,
                                                 frmDate = fvbr.FromDate,
                                                 toDate = fvbr.ToDate,
                                                 depManID = fvbr.DepartmentManagerID,
                                                 deptManagerName = dm.FName + " " + dm.LName,
                                                 depManAppID = fvbr.DepartmentManagerApprovalID,
                                                 deptManagerAppStatus = dmas.RequestStatus,
                                                 deptManagerMessage = fvbr.DepartmentManagerMessage,
                                                 fleetManID = fvbr.FleetManagerID,
                                                 fleetManagerName = fm.FName + " " + fm.LName,
                                                 fleetManAppID = fvbr.FleetManagerApprovalID,
                                                 fleetManagerAppStatus = fmas.RequestStatus,
                                                 fleetManagerMessage = fvbr.FleetManagerMessage,
                                                 AddDate = fvbr.AddDate
                                             }).OrderByDescending(x => x.bookDate);
            FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
            foreach (var item in fleetVehicleBookingDetail)
            {
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
            }
            return dto;
        }

        public FleetVehicleBookingDTO FleetManagerFleetVehicleBookingDetailWithID(int ID)
        {
            var fleetVehicleBookingDetail = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.ID == ID && x.FleetManagerID == UserStatic.EmployeeID)
                                             join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                             join em in db.Employees on fvbr.EmployeeID equals em.ID
                                             join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                             join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                             join ct in db.Counties on fvbr.CountyID equals ct.ID
                                             join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                             join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                             join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                             join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                             select new
                                             {
                                                 ID = fvbr.ID,
                                                 EmpName = em.FName + " " + em.LName,
                                                 DeptName = dept.DepartmentName,
                                                 driverID = fvbr.AssignedDriverID,
                                                 driverName = drv.FName + " " + drv.LName,
                                                 vehID = fvbr.AssignedVehicleID,
                                                 vehCode = veh.VehicleCode,
                                                 location = fvbr.Location,
                                                 bookDate = fvbr.BookingDate,
                                                 bookingDesc = fvbr.BookingDescription,
                                                 frmDate = fvbr.FromDate,
                                                 toDate = fvbr.ToDate,
                                                 depManID = fvbr.DepartmentManagerID,
                                                 deptManagerName = dm.FName + " " + dm.LName,
                                                 depManAppID = fvbr.DepartmentManagerApprovalID,
                                                 deptManagerAppStatus = dmas.RequestStatus,
                                                 deptManagerMessage = fvbr.DepartmentManagerMessage,
                                                 fleetManID = fvbr.FleetManagerID,
                                                 fleetManagerName = fm.FName + " " + fm.LName,
                                                 fleetManAppID = fvbr.FleetManagerApprovalID,
                                                 fleetManagerAppStatus = fmas.RequestStatus,
                                                 fleetManagerMessage = fvbr.FleetManagerMessage,
                                                 AddDate = fvbr.AddDate
                                             }).OrderByDescending(x => x.bookDate);
            FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
            foreach (var item in fleetVehicleBookingDetail)
            {
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
            }
            return dto;
        }

        public FleetVehicleBookingDTO DeptManagerFleetVehicleBookingDetailWithID(int ID)
        {
            var fleetVehicleBookingDetail = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.ID == ID && x.DepartmentManagerID == UserStatic.EmployeeID)
                                             join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                             join em in db.Employees on fvbr.EmployeeID equals em.ID
                                             join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                             join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                             join ct in db.Counties on fvbr.CountyID equals ct.ID
                                             join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                             join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                             join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                             join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                             select new
                                             {
                                                 ID = fvbr.ID,
                                                 EmpName = em.FName + " " + em.LName,
                                                 DeptName = dept.DepartmentName,
                                                 driverID = fvbr.AssignedDriverID,
                                                 driverName = drv.FName + " " + drv.LName,
                                                 vehID = fvbr.AssignedVehicleID,
                                                 vehCode = veh.VehicleCode,
                                                 location = fvbr.Location,
                                                 bookDate = fvbr.BookingDate,
                                                 bookingDesc = fvbr.BookingDescription,
                                                 frmDate = fvbr.FromDate,
                                                 toDate = fvbr.ToDate,
                                                 depManID = fvbr.DepartmentManagerID,
                                                 deptManagerName = dm.FName + " " + dm.LName,
                                                 depManAppID = fvbr.DepartmentManagerApprovalID,
                                                 deptManagerAppStatus = dmas.RequestStatus,
                                                 deptManagerMessage = fvbr.DepartmentManagerMessage,
                                                 fleetManID = fvbr.FleetManagerID,
                                                 fleetManagerName = fm.FName + " " + fm.LName,
                                                 fleetManAppID = fvbr.FleetManagerApprovalID,
                                                 fleetManagerAppStatus = fmas.RequestStatus,
                                                 fleetManagerMessage = fvbr.FleetManagerMessage,
                                                 AddDate = fvbr.AddDate
                                             }).OrderByDescending(x => x.bookDate);
            FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
            foreach (var item in fleetVehicleBookingDetail)
            {
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
            }
            return dto;
        }

        public FleetVehicleBookingDTO FleetVehicleBookingDetailWithID(int ID)
        {
            var fleetVehicleBookingDetail = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.ID ==ID)
                                           join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                           join em in db.Employees on fvbr.EmployeeID equals em.ID
                                           join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                           join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                           join ct in db.Counties on fvbr.CountyID equals ct.ID
                                           join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                           join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               EmpName = em.FName + " " + em.LName,
                                               DeptName = dept.DepartmentName,
                                               driverID = fvbr.AssignedDriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               vehID = fvbr.AssignedVehicleID,
                                               vehCode = veh.VehicleCode,
                                               location = fvbr.Location,
                                               bookDate = fvbr.BookingDate,
                                               bookingDesc = fvbr.BookingDescription,
                                               frmDate = fvbr.FromDate,
                                               toDate = fvbr.ToDate,
                                               depManID = fvbr.DepartmentManagerID,
                                               deptManagerName = dm.FName + " " + dm.LName,
                                               depManAppID = fvbr.DepartmentManagerApprovalID,
                                               deptManagerAppStatus = dmas.RequestStatus,
                                               deptManagerMessage = fvbr.DepartmentManagerMessage,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.RequestStatus,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.bookDate);
            FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
            foreach (var item in fleetVehicleBookingDetail)
            {
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
            }
            return dto;
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForFleetDriver()
        {
            var fleetVehicleBookingDriverList = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.AssignedDriverID == UserStatic.EmployeeID && x.FleetManagerApprovalID == 1)
                                           join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                           join em in db.Employees on fvbr.EmployeeID equals em.ID
                                           join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                           join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                           join ct in db.Counties on fvbr.CountyID equals ct.ID
                                           join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                           join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               DeptName = dept.DepartmentName,
                                               EmpName = em.FName + " " + em.LName,
                                               driverID = fvbr.AssignedDriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               vehID = fvbr.AssignedVehicleID,
                                               vehCode = veh.VehicleCode,
                                               location = fvbr.Location,
                                               bookDate = fvbr.BookingDate,
                                               bookingDesc = fvbr.BookingDescription,
                                               frmDate = fvbr.FromDate,
                                               toDate = fvbr.ToDate,
                                               depManID = fvbr.DepartmentManagerID,
                                               deptManagerName = dm.FName + " " + dm.LName,
                                               depManAppID = fvbr.DepartmentManagerApprovalID,
                                               deptManagerAppStatus = dmas.RequestStatus,
                                               deptManagerMessage = fvbr.DepartmentManagerMessage,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.RequestStatus,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.bookDate).ToList();
            List<FleetVehicleBookingDTO> dtolist = new List<FleetVehicleBookingDTO>();
            foreach (var item in fleetVehicleBookingDriverList)
            {
                FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForFleetManager()
        {
            var fleetVehicleBookingList = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false)
                                           join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                           join em in db.Employees on fvbr.EmployeeID equals em.ID
                                           join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                           join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                           join ct in db.Counties on fvbr.CountyID equals ct.ID
                                           join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                           join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               DeptName = dept.DepartmentName,
                                               EmpName = em.FName +" "+ em.LName, 
                                               driverID = fvbr.AssignedDriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               vehID = fvbr.AssignedVehicleID,
                                               vehCode = veh.VehicleCode,
                                               location = fvbr.Location,
                                               bookDate = fvbr.BookingDate,
                                               bookingDesc = fvbr.BookingDescription,
                                               frmDate = fvbr.FromDate,
                                               toDate = fvbr.ToDate,
                                               depManID = fvbr.DepartmentManagerID,
                                               deptManagerName = dm.FName + " " + dm.LName,
                                               depManAppID = fvbr.DepartmentManagerApprovalID,
                                               deptManagerAppStatus = dmas.RequestStatus,
                                               deptManagerMessage = fvbr.DepartmentManagerMessage,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.RequestStatus,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.bookDate).ToList();
            List<FleetVehicleBookingDTO> dtolist = new List<FleetVehicleBookingDTO>();
            foreach (var item in fleetVehicleBookingList)
            {
                FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public List<FleetVehicleBookingDTO> GetFleetVehicleBookingsForDeptManager()
        {
            var fleetVehicleBookingListforFleetManager = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.DepartmentID == UserStatic.DepartmentID)
                                           join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                           join em in db.Employees on fvbr.EmployeeID equals em.ID
                                           join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                           join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                           join ct in db.Counties on fvbr.CountyID equals ct.ID
                                           join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                           join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               EmpName = em.FName + " " + em.LName,
                                               DeptName= dept.DepartmentName,
                                               driverID = fvbr.AssignedDriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               vehID = fvbr.AssignedVehicleID,
                                               vehCode = veh.VehicleCode,
                                               location = fvbr.Location,
                                               bookDate = fvbr.BookingDate,
                                               bookingDesc = fvbr.BookingDescription,
                                               frmDate = fvbr.FromDate,
                                               toDate = fvbr.ToDate,
                                               depManID = fvbr.DepartmentManagerID,
                                               deptManagerName = dm.FName + " " + dm.LName,
                                               depManAppID = fvbr.DepartmentManagerApprovalID,
                                               deptManagerAppStatus = dmas.RequestStatus,
                                               deptManagerMessage = fvbr.DepartmentManagerMessage,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.RequestStatus,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.bookDate).ToList();
            List<FleetVehicleBookingDTO> dtolist = new List<FleetVehicleBookingDTO>();
            foreach (var item in fleetVehicleBookingListforFleetManager)
            {
                FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
                dto.ID = item.ID;
                dto.EmployeeName = item.EmpName;
                dto.DepartmentName = item.DeptName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;

                dtolist.Add(dto);
            }
            return dtolist;
        }

        public void FleetManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            try
            {
                FleetVehicleBookingRequest fvbr = db.FleetVehicleBookingRequests.First(x => x.ID == model.ID);
                fvbr.AssignedDriverID = model.AssignedDriverID;
                fvbr.AssignedVehicleID = model.AssignedVehicleID;
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
        public void DeptManagerUpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            try
            {
                FleetVehicleBookingRequest fvbr = db.FleetVehicleBookingRequests.First(x => x.ID == model.ID);
                fvbr.DepartmentManagerApprovalID = model.DepartmentManagerApprovalID;
                fvbr.DepartmentManagerID = UserStatic.EmployeeID;
                fvbr.DepartmentManagerMessage = model.DepartmentManagerMessage;
                fvbr.LastUpdateDate = DateTime.Now;
                fvbr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FleetVehicleBookingDTO DeptManagerUpdateFleetVehicleBooking(int ID)
        {
            var fleetVehicleBookingDeatil = (from fvbr in db.FleetVehicleBookingRequests.Where(x => x.isDeleted == false && x.ID == ID)
                                           join drv in db.Employees on fvbr.AssignedDriverID equals drv.ID
                                             join em in db.Employees on fvbr.EmployeeID equals em.ID
                                             join dept in db.Departments on fvbr.DepartmentID equals dept.ID
                                             join veh in db.FleetVehicles on fvbr.AssignedVehicleID equals veh.ID
                                           join ct in db.Counties on fvbr.CountyID equals ct.ID
                                           join dm in db.Employees on fvbr.DepartmentManagerID equals dm.ID
                                           join fm in db.Employees on fvbr.FleetManagerID equals fm.ID
                                           join dmas in db.RequestStatus on fvbr.DepartmentManagerApprovalID equals dmas.ID
                                           join fmas in db.RequestStatus on fvbr.FleetManagerApprovalID equals fmas.ID
                                           select new
                                           {
                                               ID = fvbr.ID,
                                               DeptName = dept.DepartmentName,
                                               EmpName = em.FName + " " + em.LName,
                                               driverID = fvbr.AssignedDriverID,
                                               driverName = drv.FName + " " + drv.LName,
                                               vehID = fvbr.AssignedVehicleID,
                                               vehCode = veh.VehicleCode,
                                               location = fvbr.Location,
                                               bookDate = fvbr.BookingDate,
                                               bookingDesc = fvbr.BookingDescription,
                                               frmDate = fvbr.FromDate,
                                               toDate = fvbr.ToDate,
                                               depManID = fvbr.DepartmentManagerID,
                                               deptManagerName = dm.FName + " " + dm.LName,
                                               depManAppID = fvbr.DepartmentManagerApprovalID,
                                               deptManagerAppStatus = dmas.RequestStatus,
                                               deptManagerMessage = fvbr.DepartmentManagerMessage,
                                               fleetManID = fvbr.FleetManagerID,
                                               fleetManagerName = fm.FName + " " + fm.LName,
                                               fleetManAppID = fvbr.FleetManagerApprovalID,
                                               fleetManagerAppStatus = fmas.RequestStatus,
                                               fleetManagerMessage = fvbr.FleetManagerMessage,
                                               AddDate = fvbr.AddDate
                                           }).OrderByDescending(x => x.bookDate).ToList();
            FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
            foreach (var item in fleetVehicleBookingDeatil)
            {
                dto.ID = item.ID;
                dto.DepartmentName = item.DeptName;
                dto.EmployeeName = item.EmpName;
                dto.AssignedDriverID = Convert.ToInt32(item.driverID);
                dto.AssignedDriverName = item.driverName;
                dto.AssignedVehicleID = Convert.ToInt32(item.vehID);
                dto.AssignedVehicleCode = item.vehCode;
                dto.Location = item.location;
                dto.BookingDescription = item.bookingDesc;
                dto.BookingDate = item.bookDate;
                dto.FromDate = item.frmDate;
                dto.ToDate = item.toDate;
                dto.DepartmentManagerID = Convert.ToInt32(item.depManID);
                dto.DepartmentManagerName = item.deptManagerName;
                dto.DepartmentManagerMessage = item.deptManagerMessage;
                dto.DepartmentManagerApprovalID = Convert.ToInt32(item.depManAppID);
                dto.DepartmentManagerApprovalStatus = item.deptManagerAppStatus;
                dto.FleetManagerID = Convert.ToInt32(item.fleetManID);
                dto.FleetManagerName = item.fleetManagerName;
                dto.FleetManagerMessage = item.fleetManagerMessage;
                dto.FleetManagerApprovalID = Convert.ToInt32(item.fleetManAppID);
                dto.FleetManagerApprovalStatus = item.fleetManagerAppStatus;
            }
            return dto;
        }

        public FleetVehicleBookingDTO UpdateFleetVehicleBookingWithID(int ID)
        {
            try
            {
                FleetVehicleBookingRequest fvbr = db.FleetVehicleBookingRequests.First(x => x.ID == ID);
                FleetVehicleBookingDTO dto = new FleetVehicleBookingDTO();
                dto.ID = fvbr.ID;
                dto.EmployeeID = fvbr.EmployeeID;
                dto.Location = fvbr.Location;
                dto.CountyID = fvbr.CountyID;
                dto.BookingDescription = fvbr.BookingDescription;
                dto.FromDate = fvbr.FromDate;
                dto.ToDate = fvbr.ToDate;
                dto.AssignedDriverID = Convert.ToInt32(fvbr.AssignedDriverID);
                dto.AssignedVehicleID = Convert.ToInt32(fvbr.AssignedVehicleID);
                dto.DepartmentManagerApprovalID = Convert.ToInt32(fvbr.DepartmentManagerApprovalID);
                dto.DepartmentManagerID = Convert.ToInt32(fvbr.DepartmentManagerID);
                dto.DepartmentManagerMessage = fvbr.DepartmentManagerMessage;
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

        public void UpdateFleetVehicleBooking(FleetVehicleBookingDTO model)
        {
            try
            {
                FleetVehicleBookingRequest fvbr = db.FleetVehicleBookingRequests.First(x => x.ID == model.ID);
                fvbr.Location = model.Location;
                fvbr.CountyID = model.CountyID;
                fvbr.BookingDescription = model.BookingDescription;
                fvbr.FromDate = model.FromDate;
                fvbr.ToDate = model.ToDate;
                fvbr.LastUpdateDate = DateTime.Now;
                fvbr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFleetVehicleBooking(int ID)
        {
            try
            {
                FleetVehicleBookingRequest fvbr = db.FleetVehicleBookingRequests.First(x => x.ID == ID);
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
