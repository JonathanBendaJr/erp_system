using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class FleetVehicleDriverDTO
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string VehicleCode { get; set; }
        public IEnumerable<SelectListItem> Vehicles { get; set; }
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public IEnumerable<SelectListItem> Drivers { get; set; }

    }
}
