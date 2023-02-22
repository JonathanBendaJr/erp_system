using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LeaveActionBLL
    {
        LeaveActionDAO dao = new LeaveActionDAO();
        public bool AddLeaveAction(LeaveActionDTO model)
        {
            LeaveAction leave = new LeaveAction();
            leave.Action = model.Action;
            leave.Description = model.Description;
            leave.AddDate = DateTime.Now;
            leave.LastUpdateDate = DateTime.Now;
            leave.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddLeaveAction(leave);

            LogDAO.AddLog(General.ProcessType.LeaveActionAdd, General.TableName.LeaveAction, ID);
            return true;
        }

        public List<LeaveActionDTO> GetLeaveActions()
        {
            return dao.GetLeaveActions();
        }

        public LeaveActionDTO UpdateLeaveActionWithID(int ID)
        {
            return dao.UpdateLeaveActionWithID(ID);
        }

        public bool UpdateLeaveAction(LeaveActionDTO model)
        {
            dao.UpdateLeaveAction(model);
            LogDAO.AddLog(General.ProcessType.LeaveActionUpdate, General.TableName.LeaveAction, model.ID);
            return true;
        }

        public void DeleteLeaveAction(int ID)
        {
            dao.DeleteLeaveAction(ID);
            LogDAO.AddLog(General.ProcessType.LeaveActionDelete, General.TableName.LeaveAction, ID);
        }
    }
}
