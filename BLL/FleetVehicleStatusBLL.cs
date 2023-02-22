using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FleetVehicleStatusBLL
    {
        FleetVehicleStatusDAO dao = new FleetVehicleStatusDAO();
        public bool AddFleetVehicleStatus(FleetVehicleStatusDTO model)
        {
            FleetVehicleStatu fvs = new FleetVehicleStatu();
            fvs.Status = model.VehicleStatus;
            fvs.Description = model.Description;
            fvs.AddDate = DateTime.Now;
            fvs.LastUpdateDate = DateTime.Now;
            fvs.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleStatus(fvs);

            LogDAO.AddLog(General.ProcessType.FleetVehicleStatusAdd, General.TableName.FleetVehicleStatus, ID);
            return true;
        }

        public List<FleetVehicleStatusDTO> GetFleetVehicleStatuss()
        {
            return dao.GetFleetVehicleStatuss();
        }

        public FleetVehicleStatusDTO UpdateFleetVehicleStatusWithID(int ID)
        {
            return dao.UpdateFleetVehicleStatusWithID(ID);
        }

        public bool UpdateFleetVehicleStatus(FleetVehicleStatusDTO model)
        {
            dao.UpdateFleetVehicleStatus(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleStatusUpdate, General.TableName.FleetVehicleStatus, model.ID);
            return true;
        }

        public void DeleteFleetVehicleStatus(int ID)
        {
            dao.DeleteFleetVehicleStatus(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleStatusDelete, General.TableName.FleetVehicleStatus, ID);
        }
    }
}
