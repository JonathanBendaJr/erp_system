using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class UnitOfMeasurementBLL
    {
        UnitOfMeasurementDAO dao = new UnitOfMeasurementDAO();
        public bool AddUnitOfMeasurement(UnitOfMeasurementDTO model)
        {
            UnitOfMeasurement um = new UnitOfMeasurement();
            um.MeasuringUnit = model.MeasuringUnit;
            um.Description = model.Description;
            um.AddDate = DateTime.Now;
            um.LastUpdateDate = DateTime.Now;
            um.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddUnitOfMeasurement(um);

            LogDAO.AddLog(General.ProcessType.UnitOfMeasurementAdd, General.TableName.UnitOfMeasurement, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetUnitsForDropdown()
        {
            throw new NotImplementedException();
        }

        public List<UnitOfMeasurementDTO> GetUnitOfMeasurements()
        {
            return dao.GetUnitOfMeasurements();
        }

        public UnitOfMeasurementDTO UpdateUnitOfMeasurementWithID(int ID)
        {
            return dao.UpdateUnitOfMeasurementWithID(ID);
        }

        public bool UpdateUnitOfMeasurement(UnitOfMeasurementDTO model)
        {
            dao.UpdateUnitOfMeasurement(model);
            LogDAO.AddLog(General.ProcessType.UnitOfMeasurementUpdate, General.TableName.UnitOfMeasurement, model.ID);
            return true;
        }

        public void DeleteUnitOfMeasurement(int ID)
        {
            dao.DeleteUnitOfMeasurement(ID);
            LogDAO.AddLog(General.ProcessType.UnitOfMeasurementDelete, General.TableName.UnitOfMeasurement, ID);
        }
    }
}
