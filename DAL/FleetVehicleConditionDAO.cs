using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleConditionDAO: PostContext
    {
        public int AddFleetVehicleCondition(FleetVehicleReceivedCondition fvc)
        {
            try
            {
                db.FleetVehicleReceivedConditions.Add(fvc);
                db.SaveChanges();
                return fvc.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleConditionDTO> GetFleetVehicleConditions()
        {
            List<FleetVehicleReceivedCondition> list = db.FleetVehicleReceivedConditions.OrderByDescending(x => x.VehicleCondition).ToList();
            List<FleetVehicleConditionDTO> dtolist = new List<FleetVehicleConditionDTO>();
            foreach (var item in list)
            {
                FleetVehicleConditionDTO dto = new FleetVehicleConditionDTO();
                dto.VehicleCondition = item.VehicleCondition;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleConditionDTO UpdateFleetVehicleConditionWithID(int ID)
        {
            try
            {
                FleetVehicleReceivedCondition fvc = db.FleetVehicleReceivedConditions.First(x => x.ID == ID);
                FleetVehicleConditionDTO dto = new FleetVehicleConditionDTO();
                dto.ID = fvc.ID;
                dto.VehicleCondition = fvc.VehicleCondition;
                dto.Description = fvc.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleCondition(FleetVehicleConditionDTO model)
        {
            try
            {
                FleetVehicleReceivedCondition fvc = db.FleetVehicleReceivedConditions.First(x => x.ID == model.ID);
                fvc.VehicleCondition = model.VehicleCondition;
                fvc.Description = model.Description;
                fvc.LastUpdateDate = DateTime.Now;
                fvc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFleetVehicleCondition(int ID)
        {
            try
            {
                FleetVehicleReceivedCondition fvc = db.FleetVehicleReceivedConditions.First(x => x.ID == ID);
                /*fvc.isDeleted = true;
                fvc.DeletedDate = DateTime.Now;*/
                fvc.LastUpdateDate = DateTime.Now;
                fvc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
