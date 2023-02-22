using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LeaveTypeDAO : PostContext
    {
        public LeaveTypeDTO UpdateLeaveTypeWithID(int ID)
        {
            try
            {
                LeaveType lt = db.LeaveTypes.First(x => x.ID == ID);
                LeaveTypeDTO dto = new LeaveTypeDTO();
                dto.ID = lt.ID;
                dto.LeaveType = lt.LeaveType1;
                dto.Description = lt.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AddLeaveType(LeaveType lt)
        {
            try
            {
                db.LeaveTypes.Add(lt);
                db.SaveChanges();
                return lt.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LeaveTypeDTO> GetLeaveTypes()
        {
            List<LeaveType> list = db.LeaveTypes.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<LeaveTypeDTO> dtolist = new List<LeaveTypeDTO>();
            foreach (var item in list)
            {
                LeaveTypeDTO dto = new LeaveTypeDTO();
                dto.LeaveType = item.LeaveType1;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public void UpdateLeaveType(LeaveTypeDTO model)
        {
            try
            {
                LeaveType lt = db.LeaveTypes.First(x => x.ID == model.ID);
                lt.LeaveType1 = model.LeaveType;
                lt.Description = model.Description;
                lt.LastUpdateDate = DateTime.Now;
                lt.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLeaveType(int ID)
        {
            try
            {
                LeaveType lt = db.LeaveTypes.First(x => x.ID == ID);
                lt.isDeleted = true;
                lt.DeletedDate = DateTime.Now;
                lt.LastUpdateDate = DateTime.Now;
                lt.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
