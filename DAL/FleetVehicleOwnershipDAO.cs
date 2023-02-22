using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleOwnershipDAO : PostContext
    {
        public int AddFleetVehicleOwnership(FleetVehicleOwnership fvo)
        {
            try
            {
                db.FleetVehicleOwnerships.Add(fvo);
                db.SaveChanges();
                return fvo.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleOwnershipDTO> GetFleetVehicleOwnerships()
        {
            List<FleetVehicleOwnership> list = db.FleetVehicleOwnerships.Where(x => x.isDeleted == false).OrderBy(x => x.VehicleOwnership).ToList();
            List<FleetVehicleOwnershipDTO> dtolist = new List<FleetVehicleOwnershipDTO>();
            foreach (var item in list)
            {
                FleetVehicleOwnershipDTO dto = new FleetVehicleOwnershipDTO();
                dto.VehicleOwnership = item.VehicleOwnership;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleOwnershipDTO UpdateFleetVehicleOwnershipWithID(int ID)
        {
            try
            {
                FleetVehicleOwnership fvo = db.FleetVehicleOwnerships.First(x => x.ID == ID);
                FleetVehicleOwnershipDTO dto = new FleetVehicleOwnershipDTO();
                dto.ID = fvo.ID;
                dto.VehicleOwnership = fvo.VehicleOwnership;
                dto.Description = fvo.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleOwnership(FleetVehicleOwnershipDTO model)
        {
            try
            {
                FleetVehicleOwnership fvo = db.FleetVehicleOwnerships.First(x => x.ID == model.ID);
                fvo.VehicleOwnership = model.VehicleOwnership;
                fvo.Description = model.Description;
                fvo.LastUpdateDate = DateTime.Now;
                fvo.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteFleetVehicleOwnership(int ID)
        {
            try
            {
                FleetVehicleOwnership fvo = db.FleetVehicleOwnerships.First(x => x.ID == ID);
                fvo.isDeleted = true;
                fvo.DeletedDate = DateTime.Now;
                fvo.LastUpdateDate = DateTime.Now;
                fvo.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
