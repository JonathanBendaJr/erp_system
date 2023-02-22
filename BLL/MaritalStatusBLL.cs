using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaritalStatusBLL
    {
        MaritalStatusDAO dao = new MaritalStatusDAO();
        public bool AddMaritalStatus(MaritalStatusDTO model)
        {
            MaritalStatu ms = new MaritalStatu();
            ms.MaritalStatus = model.MaritalStatus;
            ms.Abbreviation = model.Abbreviation;
            ms.Description = model.Description;
            ms.AddDate = DateTime.Now;
            ms.LastUpdateDate = DateTime.Now;
            ms.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddMaritalStatus(ms);

            LogDAO.AddLog(General.ProcessType.MaritalStatusAdd, General.TableName.MaritalStatus, ID);
            return true;
        }

        public List<MaritalStatusDTO> GetMaritalStatuses()
        {
            return dao.GetMaritalStatuses();
        }

        public MaritalStatusDTO UpdateMaritalStatusWithID(int ID)
        {
            return dao.UpdateMaritalStatusWithID(ID);
        }

        public bool UpdateMaritalStatus(MaritalStatusDTO model)
        {
            dao.UpdateMaritalStatus(model);
            LogDAO.AddLog(General.ProcessType.MaritalStatusUpdate, General.TableName.MaritalStatus, model.ID);
            return true;
        }

        public void DeleteMaritalStatus(int ID)
        {
            dao.DeleteMaritalStatus(ID);
            LogDAO.AddLog(General.ProcessType.MaritalStatusDelete, General.TableName.MaritalStatus, ID);
        }
    }
}
