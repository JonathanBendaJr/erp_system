using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LeaveTypeBLL
    {
        LeaveTypeDAO dao = new LeaveTypeDAO();
        public bool AddLeaveType(LeaveTypeDTO model)
        {
            LeaveType lt = new LeaveType();
            lt.LeaveType1 = model.LeaveType;
            lt.Description = model.Description;
            lt.AddDate = DateTime.Now;
            lt.LastUpdateDate = DateTime.Now;
            lt.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddLeaveType(lt);

            LogDAO.AddLog(General.ProcessType.LeaveTypeAdd, General.TableName.LeaveType, ID);
            return true;
        }

        public List<LeaveTypeDTO> GetLeaveTypes()
        {
            return dao.GetLeaveTypes();
        }

        public LeaveTypeDTO UpdateLeaveTypeWithID(int ID)
        {
            return dao.UpdateLeaveTypeWithID(ID);
        }

        public bool UpdateLeaveType(LeaveTypeDTO model)
        {
            dao.UpdateLeaveType(model);
            LogDAO.AddLog(General.ProcessType.LeaveTypeUpdate, General.TableName.LeaveType, model.ID);
            return true;
        }

        public void DeleteLeaveType(int ID)
        {
            dao.DeleteLeaveType(ID);
            LogDAO.AddLog(General.ProcessType.LeaveTypeDelete, General.TableName.LeaveType, ID);
        }
    }
}
