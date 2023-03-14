using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class FleetVehicleBookingDTO
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public int CountyID { get; set; }
        public string CountyName { get; set; }
        public IEnumerable<SelectListItem> Counties { get; set; }
        public string BookingDescription { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int AssignedDriverID { get; set; }
        public string AssignedDriverName { get; set; }
        public IEnumerable<SelectListItem> Drivers { get; set; }
        public int AssignedVehicleID { get; set; }
        public string AssignedVehicleCode { get; set; }
        public IEnumerable<SelectListItem> Vehicles { get; set; }
        public int DepartmentManagerApprovalID { get; set; }
        public IEnumerable<SelectListItem> Approvals { get; set; }
        public string DepartmentManagerApprovalStatus { get; set; }
        public int DepartmentManagerID { get; set; }
        public string DepartmentManagerName { get; set; }
        public string DepartmentManagerMessage { get; set; }
        public int FleetManagerApprovalID { get; set; }
        public string FleetManagerApprovalStatus { get; set; }
        public int FleetManagerID { get; set; }
        public string FleetManagerName { get; set; }
        public string FleetManagerMessage { get; set; }

    }
}
