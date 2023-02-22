using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleTypeDAO : PostContext
    {
        public void DeleteFleetVehicleType(int ID)
        {
            try
            {
                FleetVehicleType fvt = db.FleetVehicleTypes.First(x => x.ID == ID);
                /*gd.isDeleted = true;
                gd.DeletedDate = DateTime.Now;*/
                fvt.LastUpdateDate = DateTime.Now;
                fvt.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddFleetVehicleType(FleetVehicleType fvt)
        {
            try
            {
                db.FleetVehicleTypes.Add(fvt);
                db.SaveChanges();
                return fvt.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleTypeDTO> GetFleetVehicleTypes()
        {
            List<FleetVehicleType> list = db.FleetVehicleTypes.OrderBy(x => x.VehicleType).ToList();
            List<FleetVehicleTypeDTO> dtolist = new List<FleetVehicleTypeDTO>();
            foreach (var item in list)
            {
                FleetVehicleTypeDTO dto = new FleetVehicleTypeDTO();
                dto.VehicleType = item.VehicleType;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleTypeDTO UpdateFleetVehicleTypeWithID(int ID)
        {
            try
            {
                FleetVehicleType fvt = db.FleetVehicleTypes.First(x => x.ID == ID);
                FleetVehicleTypeDTO dto = new FleetVehicleTypeDTO();
                dto.ID = fvt.ID;
                dto.VehicleType = fvt.VehicleType;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleType(FleetVehicleTypeDTO model)
        {
            try
            {
                FleetVehicleType fvt = db.FleetVehicleTypes.First(x => x.ID == model.ID);
                fvt.VehicleType = model.VehicleType;
                fvt.LastUpdateDate = DateTime.Now;
                fvt.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
