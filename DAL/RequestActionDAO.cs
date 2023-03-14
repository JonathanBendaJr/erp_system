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
    public class RequestActionDAO : PostContext
    {
        public int AddRequestAction(RequestAction leave)
        {
            try
            {
                db.RequestActions.Add(leave);
                db.SaveChanges();
                return leave.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static IEnumerable<SelectListItem> GetApprovalsForDropdown()
        {
            IEnumerable<SelectListItem> approvalList = db.RequestActions.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.Action,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return approvalList;
        }
        public List<RequestActionDTO> GetRequestActions()
        {
            List<RequestAction> list = db.RequestActions.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<RequestActionDTO> dtolist = new List<RequestActionDTO>();
            foreach (var item in list)
            {
                RequestActionDTO dto = new RequestActionDTO();
                dto.Action = item.Action;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }    
        public RequestActionDTO UpdateRequestActionWithID(int ID)
        {
            try
            {
                RequestAction leave = db.RequestActions.First(x => x.ID == ID);
                RequestActionDTO dto = new RequestActionDTO();
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

        public void UpdateRequestAction(RequestActionDTO model)
        {
            try
            {
                RequestAction leave = db.RequestActions.First(x => x.ID == model.ID);
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

        public void DeleteRequestAction(int ID)
        {
            try
            {
                RequestAction leave = db.RequestActions.First(x => x.ID == ID);
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
