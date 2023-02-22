using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LeaveActionDAO : PostContext
    {
        public int AddLeaveAction(LeaveAction leave)
        {
            try
            {
                db.LeaveActions.Add(leave);
                db.SaveChanges();
                return leave.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LeaveActionDTO> GetLeaveActions()
        {
            List<LeaveAction> list = db.LeaveActions.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<LeaveActionDTO> dtolist = new List<LeaveActionDTO>();
            foreach (var item in list)
            {
                LeaveActionDTO dto = new LeaveActionDTO();
                dto.Action = item.Action;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }    
        public LeaveActionDTO UpdateLeaveActionWithID(int ID)
        {
            try
            {
                LeaveAction leave = db.LeaveActions.First(x => x.ID == ID);
                LeaveActionDTO dto = new LeaveActionDTO();
                dto.ID = leave.ID;
                dto.Action = leave.Action;
                dto.Description = leave.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateLeaveAction(LeaveActionDTO model)
        {
            try
            {
                LeaveAction leave = db.LeaveActions.First(x => x.ID == model.ID);
                leave.Action = model.Action;
                leave.Description = model.Description;
                leave.LastUpdateDate = DateTime.Now;
                leave.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeaveAction(int ID)
        {
            try
            {
                LeaveAction leave = db.LeaveActions.First(x => x.ID == ID);
                leave.isDeleted = true;
                leave.DeletedDate = DateTime.Now;
                leave.LastUpdateDate = DateTime.Now;
                leave.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
