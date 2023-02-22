using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FleetVehicleOwnershipBLL
    {
        FleetVehicleOwnershipDAO dao = new FleetVehicleOwnershipDAO();
        public bool AddFleetVehicleOwnership(FleetVehicleOwnershipDTO model)
        {
            FleetVehicleOwnership fvo = new FleetVehicleOwnership();
            fvo.VehicleOwnership = model.VehicleOwnership;
            fvo.Description = model.Description;
            fvo.AddDate = DateTime.Now;
            fvo.LastUpdateDate = DateTime.Now;
            fvo.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleOwnership(fvo);

            LogDAO.AddLog(General.ProcessType.FleetVehicleOwnershipAdd, General.TableName.FleetVehicleOwnership, ID);
            return true;
        }

        public List<FleetVehicleOwnershipDTO> GetFleetVehicleOwnerships()
        {
            return dao.GetFleetVehicleOwnerships();
        }

        public FleetVehicleOwnershipDTO UpdateFleetVehicleOwnershipWithID(int ID)
        {
            return dao.UpdateFleetVehicleOwnershipWithID(ID);
        }

        public bool UpdateFleetVehicleOwnership(FleetVehicleOwnershipDTO model)
        {
            dao.UpdateFleetVehicleOwnership(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleOwnershipUpdate, General.TableName.FleetVehicleOwnership, model.ID);
            return true;
        }

        public void DeleteFleetVehicleOwnership(int ID)
        {
            dao.DeleteFleetVehicleOwnership(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleOwnershipDelete, General.TableName.FleetVehicleOwnership, ID);
        }
    }
}
