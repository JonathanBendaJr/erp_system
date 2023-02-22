using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatusBLL
    {
        StatusDAO dao = new StatusDAO();
        public bool AddStatus(StatusDTO model)
        {
            Status st = new Status();
            st.Status1 = model.Status;
            st.Description = model.Description;
            st.AddDate = DateTime.Now;
            st.LastUpdateDate = DateTime.Now;
            st.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddStatus(st);

            LogDAO.AddLog(General.ProcessType.StatusAdd, General.TableName.Status, ID);
            return true;
        }

        public List<StatusDTO> GetStatuses()
        {
            return dao.GetStatuses();
        }

        public StatusDTO UpdateStatusWithID(int ID)
        {
            return dao.UpdateStatusWithID(ID);
        }

        public bool UpdateStatus(StatusDTO model)
        {
            dao.UpdateStatus(model);
            LogDAO.AddLog(General.ProcessType.StatusUpdate, General.TableName.Status, model.ID);
            return true;
        }

        public void DeleteStatus(int ID)
        {
            dao.DeleteStatus(ID);
            LogDAO.AddLog(General.ProcessType.StatusDelete, General.TableName.Status, ID);
        }
    }
}
