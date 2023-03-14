using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FleetVehicleRegistrationDAO: PostContext
    {
        public int AddFleetVehicleRegistration(FleetVehicleRegistrationStatu frvs)
        {
            try
            {
                db.FleetVehicleRegistrationStatus.Add(frvs);
                db.SaveChanges();
                return frvs.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FleetVehicleRegistrationDTO> GetFleetVehicleRegistrations()
        {
            List<FleetVehicleRegistrationStatu> list = db.FleetVehicleRegistrationStatus.OrderByDescending(x => x.RegistrationStatus).ToList();
            List<FleetVehicleRegistrationDTO> dtolist = new List<FleetVehicleRegistrationDTO>();
            foreach (var item in list)
            {
                FleetVehicleRegistrationDTO dto = new FleetVehicleRegistrationDTO();
                dto.RegistrationStatus = item.RegistrationStatus;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public FleetVehicleRegistrationDTO UpdateFleetVehicleRegistrationWithID(int ID)
        {
            try
            {
                FleetVehicleRegistrationStatu frvs = db.FleetVehicleRegistrationStatus.First(x => x.ID == ID);
                FleetVehicleRegistrationDTO dto = new FleetVehicleRegistrationDTO();
                dto.ID = frvs.ID;
                dto.RegistrationStatus = frvs.RegistrationStatus;
                dto.Description = frvs.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleRegistration(FleetVehicleRegistrationDTO model)
        {
            try
            {
                FleetVehicleRegistrationStatu frvs = db.FleetVehicleRegistrationStatus.First(x => x.ID == model.ID);
                frvs.RegistrationStatus = model.RegistrationStatus;
                frvs.Description = model.Description;
                frvs.LastUpdateDate = DateTime.Now;
                frvs.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
