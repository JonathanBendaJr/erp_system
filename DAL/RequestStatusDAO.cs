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
    public class RequestStatusDAO : PostContext
    {
        public int AddRequestStatus(RequestStatu rs)
        {
            try
            {
                db.RequestStatus.Add(rs);
                db.SaveChanges();
                return rs.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRequestStatus(int ID)
        {
            try
            {
                RequestStatu pc = db.RequestStatus.First(x => x.ID == ID);
               /* pc.isDeleted = true;
                pc.DeletedDate = DateTime.Now;*/
                pc.LastUpdateDate = DateTime.Now;
                pc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RequestStatusDTO> GetRequestStatuses()
        {
            List<RequestStatu> list = db.RequestStatus.OrderBy(x => x.RequestStatus).ToList();
            List<RequestStatusDTO> dtolist = new List<RequestStatusDTO>();
            foreach (var item in list)
            {
                RequestStatusDTO dto = new RequestStatusDTO();
                dto.RequestStatus = item.RequestStatus;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        

        public void UpdateRequestStatus(RequestStatusDTO model)
        {
            try
            {
                RequestStatu rs = db.RequestStatus.First(x => x.ID == model.ID);
                rs.RequestStatus = model.RequestStatus;
                rs.Description = model.Description;
                rs.LastUpdateDate = DateTime.Now;
                rs.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RequestStatusDTO UpdateRequestStatusWithID(int ID)
        {
            try
            {
                RequestStatu rs = db.RequestStatus.First(x => x.ID == ID);
                RequestStatusDTO dto = new RequestStatusDTO();
                dto.ID = rs.ID;
                dto.RequestStatus = rs.RequestStatus;
                dto.Description = rs.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetRequestStatusesForDropDown()
        {
            IEnumerable<SelectListItem> requestStatusList = db.RequestStatus.OrderBy(x => x.RequestStatus).Select(x => new SelectListItem()
            {
                Text = x.RequestStatus,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return requestStatusList;
        }
    }
}
