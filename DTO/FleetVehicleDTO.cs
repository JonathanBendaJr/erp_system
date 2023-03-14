using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class FleetVehicleDTO
    {
        public int ID { get; set; }
        public string VehicleCode { get; set; }
        public string VIN { get; set; }
        public string Mileage { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
        public int OwnershipStatusID { get; set; }
        public string OwnershipStatusName { get; set; }
        public IEnumerable<SelectListItem> OwnershipStatusList { get; set; }
        public int Year { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public IEnumerable<SelectListItem> UnitList { get; set; }
        public int VehicleStatusID { get; set; }
        public string VehicleStatusName { get; set; }
        public IEnumerable<SelectListItem> VehicleStatusList { get; set; }
        public int RegistrationStatusID { get; set; }
        public string RegistrationStatusName { get; set; }
        public IEnumerable<SelectListItem> RegistrationStatusList { get; set; }
        public int ReceivedConditionID { get; set; }
        public string ReceivedConditionName { get; set; }
        public IEnumerable<SelectListItem> ReceivedConditionList { get; set; }
        public string Color { get; set; }
        public int FuelTankSize { get; set; }
        public string FuelTankType { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string PlateNumber { get; set; }

    }
}
