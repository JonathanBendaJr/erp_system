using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FleetVehicleRegistrationBLL
    {
        FleetVehicleRegistrationDAO dao = new FleetVehicleRegistrationDAO();
        public bool AddFleetVehicleRegistration(FleetVehicleRegistrationDTO model)
        {
            FleetVehicleRegistrationStatu frvs = new FleetVehicleRegistrationStatu();
            frvs.RegistrationStatus = model.RegistrationStatus;
            frvs.Description = model.Description;
            frvs.AddDate = DateTime.Now;
            frvs.LastUpdateDate = DateTime.Now;
            frvs.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleRegistration(frvs);

            LogDAO.AddLog(General.ProcessType.FleetVehicleRegistrationAdd, General.TableName.FleetVehicleRegistration, ID);
            return true;
        }

        public List<FleetVehicleRegistrationDTO> GetFleetVehicleRegistrations()
        {
            return dao.GetFleetVehicleRegistrations();
        }

        public FleetVehicleRegistrationDTO UpdateFleetVehicleRegistrationWithID(int ID)
        {
            return dao.UpdateFleetVehicleRegistrationWithID(ID);
        }

        public bool UpdateFleetVehicleRegistration(FleetVehicleRegistrationDTO model)
        {
            dao.UpdateFleetVehicleRegistration(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleRegistrationUpdate, General.TableName.FleetVehicleRegistration, model.ID);
            return true;
        }

        public void DeleteFleetVehicleRegistration(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
