using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FleetVehicleConditionBLL
    {
        FleetVehicleConditionDAO dao = new FleetVehicleConditionDAO();
        public bool AddFleetVehicleCondition(FleetVehicleConditionDTO model)
        {
            FleetVehicleReceivedCondition fvc = new FleetVehicleReceivedCondition();
            fvc.VehicleCondition = model.VehicleCondition;
            fvc.Description = model.Description;
            fvc.AddDate = DateTime.Now;
            fvc.LastUpdateDate = DateTime.Now;
            fvc.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleCondition(fvc);

            LogDAO.AddLog(General.ProcessType.FleetVehicleConditionAdd, General.TableName.FleetVehicleCondition, ID);
            return true;
        }

        public List<FleetVehicleConditionDTO> GetFleetVehicleConditions()
        {
            return dao.GetFleetVehicleConditions();
        }

        public FleetVehicleConditionDTO UpdateFleetVehicleConditionWithID(int ID)
        {
            return dao.UpdateFleetVehicleConditionWithID(ID);
        }

        public bool UpdateFleetVehicleCondition(FleetVehicleConditionDTO model)
        {
            dao.UpdateFleetVehicleCondition(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleConditionUpdate, General.TableName.FleetVehicleCondition, model.ID);
            return true;
        }

        public void DeleteFleetVehicleCondition(int ID)
        {
            dao.DeleteFleetVehicleCondition(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleConditionDelete, General.TableName.FleetVehicleCondition, ID);
        }
    }
}
