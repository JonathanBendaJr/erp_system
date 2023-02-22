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
    public class RequestStatusBLL
    {
        RequestStatusDAO dao = new RequestStatusDAO();
        public void DeleteRequestStatus(int ID)
        {
            dao.DeleteRequestStatus(ID);
            LogDAO.AddLog(General.ProcessType.RequestStatusDelete, General.TableName.RequestStatus, ID);
        }

        public bool UpdateRequestStatus(RequestStatusDTO model)
        {
            dao.UpdateRequestStatus(model);
            LogDAO.AddLog(General.ProcessType.RequestStatusUpdate, General.TableName.RequestStatus, model.ID);
            return true;
        }

        public RequestStatusDTO UpdateRequestStatusWithID(int ID)
        {
            return dao.UpdateRequestStatusWithID(ID);
        }

        public List<RequestStatusDTO> GetRequestStatuses()
        {
            return dao.GetRequestStatuses();
        }
        public bool AddRequestStatus(RequestStatusDTO model)
        {
            RequestStatu rs = new RequestStatu();
            rs.RequestStatus = model.RequestStatus;
            rs.Description = model.Description;
            rs.AddDate = DateTime.Now;
            rs.LastUpdateDate = DateTime.Now;
            rs.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddRequestStatus(rs);

            LogDAO.AddLog(General.ProcessType.RequestStatusAdd, General.TableName.RequestStatus, ID);
            return true;
        }

        
    }
}
