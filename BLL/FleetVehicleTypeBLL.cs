using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FleetVehicleTypeBLL
    {
        FleetVehicleTypeDAO dao = new FleetVehicleTypeDAO();
        public bool AddFleetVehicleType(FleetVehicleTypeDTO model)
        {
            FleetVehicleType fvt = new FleetVehicleType();
            fvt.VehicleType = model.VehicleType;
            fvt.AddDate = DateTime.Now;
            fvt.LastUpdateDate = DateTime.Now;
            fvt.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddFleetVehicleType(fvt);

            LogDAO.AddLog(General.ProcessType.FleetVehicleTypeAdd, General.TableName.FleetVehicleType, ID);
            return true;
        }

        public List<FleetVehicleTypeDTO> GetFleetVehicleTypes()
        {
            return dao.GetFleetVehicleTypes();
        }

        public FleetVehicleTypeDTO UpdateFleetVehicleTypeWithID(int ID)
        {
            return dao.UpdateFleetVehicleTypeWithID(ID);
        }

        public bool UpdateFleetVehicleType(FleetVehicleTypeDTO model)
        {
            dao.UpdateFleetVehicleType(model);
            LogDAO.AddLog(General.ProcessType.FleetVehicleTypeUpdate, General.TableName.FleetVehicleType, model.ID);
            return true;
        }

        public void DeleteFleetVehicleType(int ID)
        {
            dao.DeleteFleetVehicleType(ID);
            LogDAO.AddLog(General.ProcessType.FleetVehicleTypeDelete, General.TableName.FleetVehicleType, ID);
        }
    }
}
