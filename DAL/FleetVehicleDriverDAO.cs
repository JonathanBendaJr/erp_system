using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleDriverDAO : PostContext
    {
        public int AddFleetVehicleDriver(FleetDriverVehicleAssignment fvd)
        {
            try
            {
                db.FleetDriverVehicleAssignments.Add(fvd);
                db.SaveChanges();
                return fvd.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleDriverDTO> GetFleetVehiclesDrivers()
        {
            var fleetVehicleDriverList = (from fvd in db.FleetDriverVehicleAssignments.Where(x => x.isDeleted == false)
                                       join emp in db.Employees on fvd.DriverID equals emp.ID
                                       join veh in db.FleetVehicles on fvd.VehicleID equals veh.ID
                                       select new
                                       {
                                           ID = fvd.ID,
                                           EmpID = fvd.DriverID,
                                           EmpName = emp.FName + " " + emp.LName,
                                           VehCode = veh.VehicleCode,
                                           AddDate = fvd.AddDate
                                       }).OrderByDescending(x => x.AddDate).ToList();
            List<FleetVehicleDriverDTO> dtolist = new List<FleetVehicleDriverDTO>();
            foreach (var item in fleetVehicleDriverList)
            {
                FleetVehicleDriverDTO dto = new FleetVehicleDriverDTO();
                dto.DriverID = item.EmpID;
                dto.ID = item.ID;
                dto.DriverName = item.EmpName;
                dto.VehicleCode = item.VehCode;
                
                dtolist.Add(dto);
            }
            return dtolist;
        }
    

        public void UpdateFleetVehicleDriver(FleetVehicleDriverDTO model)
        {
            try
            {
                FleetDriverVehicleAssignment fvd = db.FleetDriverVehicleAssignments.First(x => x.ID == model.ID);
                fvd.DriverID = model.DriverID;
                fvd.VehicleID = model.VehicleID;
                fvd.LastUpdateDate = DateTime.Now;
                fvd.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FleetVehicleDriverDTO UpdateFleetVehicleDriverWithID(int ID)
        {
            try
            {
                FleetDriverVehicleAssignment fvd = db.FleetDriverVehicleAssignments.First(x => x.ID == ID);
                FleetVehicleDriverDTO dto = new FleetVehicleDriverDTO();
                dto.ID = fvd.ID;
                dto.DriverID = fvd.DriverID;
                dto.VehicleID = fvd.VehicleID;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFleetVehicleDriver(int ID)
        {
            try
            {
                FleetDriverVehicleAssignment fvd = db.FleetDriverVehicleAssignments.First(x => x.ID == ID);
                fvd.isDeleted = true;
                fvd.DeletedDate = DateTime.Now;
                fvd.LastUpdateDate = DateTime.Now;
                fvd.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
