using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RequestActionBLL
    {
        RequestActionDAO dao = new RequestActionDAO();
        public bool AddRequestAction(RequestActionDTO model)
        {
            RequestAction leave = new RequestAction();
            leave.Action = model.Action;
            leave.Description = model.Description;
            leave.AddDate = DateTime.Now;
            leave.LastUpdateDate = DateTime.Now;
            leave.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddRequestAction(leave);

            LogDAO.AddLog(General.ProcessType.RequestActionAdd, General.TableName.RequestAction, ID);
            return true;
        }

        public List<RequestActionDTO> GetRequestActions()
        {
            return dao.GetRequestActions();
        }

        public RequestActionDTO UpdateRequestActionWithID(int ID)
        {
            return dao.UpdateRequestActionWithID(ID);
        }

        public bool UpdateRequestAction(RequestActionDTO model)
        {
            dao.UpdateRequestAction(model);
            LogDAO.AddLog(General.ProcessType.RequestActionUpdate, General.TableName.RequestAction, model.ID);
            return true;
        }

        public void DeleteRequestAction(int ID)
        {
            dao.DeleteRequestAction(ID);
            LogDAO.AddLog(General.ProcessType.RequestActionDelete, General.TableName.RequestAction, ID);
        }
    }
}
