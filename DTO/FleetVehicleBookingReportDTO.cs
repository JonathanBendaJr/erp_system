using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class FleetVehicleBookingReportDTO
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public TimeSpan DispacthTime { get; set; }
        public TimeSpan ReturnTime { get; set; }
        public string ReportDetails { get; set; }
        public bool Incident { get; set; }
       /* public int IncidentTypeID { get; set; }
        public string IncidentName { get; set; }
        public IEnumerable<SelectListItem> Incidents { get; set; }
        public int ResolutionTypeID { get; set; }
        public string ResolutionName { get; set; }
        public IEnumerable<SelectListItem> Resolutions { get; set; }*/
       /* public string ResolutionDetails { get; set; }*/
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public int FleetManagerID { get; set; }
        public string FleetManagerName { get; set; }
        public int FleetManagerApprovalID { get; set; }
        public IEnumerable<SelectListItem> Approvals { get; set; }
        public string FleetManagerApprovalStatus { get; set; }
        public string FleetManagerMessage { get; set; }
    }
}
