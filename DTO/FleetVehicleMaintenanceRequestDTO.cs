using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class FleetVehicleMaintenanceRequestDTO
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string VehicleCode { get; set; }
        public IEnumerable<SelectListItem> Vehicles { get; set; }
        public int VehicleStatusID { get; set; }
        public string VehicleStatus { get; set; }
        public IEnumerable<SelectListItem> VehichleStatuses { get; set; }
        public string  MaintenanceDetail { get; set; }
        public DateTime DueDate { get; set; }
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public int FleetManagerID { get; set; }
        public string FleetManagerName { get; set; }
        public int FleetManagerApprovalID { get; set; }
        public string FleetManagerApprovalStatus { get; set; }
        public IEnumerable<SelectListItem> Approvals { get; set; }
        public string FleetManagerMessage { get; set; }


    }
}
