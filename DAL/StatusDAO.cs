using DTO;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class StatusDAO : PostContext
    {
        public int AddStatus(Status st)
        {
            try
            {
                db.Status.Add(st);
                db.SaveChanges();
                return st.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<StatusDTO> GetStatuses()
        {
            List<Status> list = db.Status.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<StatusDTO> dtolist = new List<StatusDTO>();
            foreach (var item in list)
            {
                StatusDTO dto = new StatusDTO();
                dto.Status = item.Status1;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetStatusesForDropdown()
        {
            IEnumerable<SelectListItem> statusList = db.Status.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.Status1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return statusList;
        }

        public StatusDTO UpdateStatusWithID(int ID)
        {
            try
            {
                Status st = db.Status.First(x => x.ID == ID);
                StatusDTO dto = new StatusDTO();
                dto.ID = st.ID;
                dto.Status = st.Status1;
                dto.Description = st.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateStatus(StatusDTO model)
        {
            try
            {
                Status st = db.Status.First(x => x.ID == model.ID);
                st.Status1 = model.Status;
                st.Description = model.Description;
                st.LastUpdateDate = DateTime.Now;
                st.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteStatus(int ID)
        {
            try
            {
                Status st = db.Status.First(x => x.ID == ID);
                st.isDeleted = true;
                st.DeletedDate = DateTime.Now;
                st.LastUpdateDate = DateTime.Now;
                st.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
