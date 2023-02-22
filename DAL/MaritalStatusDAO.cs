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
    public class MaritalStatusDAO : PostContext
    {
        public int AddMaritalStatus(MaritalStatu ms)
        {
            try
            {
                db.MaritalStatus.Add(ms);
                db.SaveChanges();
                return ms.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MaritalStatusDTO> GetMaritalStatuses()
        {
            List<MaritalStatu> list = db.MaritalStatus.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<MaritalStatusDTO> dtolist = new List<MaritalStatusDTO>();
            foreach (var item in list)
            {
                MaritalStatusDTO dto = new MaritalStatusDTO();
                dto.MaritalStatus = item.MaritalStatus;
                dto.Abbreviation = item.Abbreviation;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetMaritalStatusesForDropdown()
        {
            IEnumerable<SelectListItem> maritalStatusList = db.MaritalStatus.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.MaritalStatus,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return maritalStatusList;
        }

        public MaritalStatusDTO UpdateMaritalStatusWithID(int ID)
        {
            try
            {
                MaritalStatu ms = db.MaritalStatus.First(x => x.ID == ID);
                MaritalStatusDTO dto = new MaritalStatusDTO();
                dto.ID = ms.ID;
                dto.MaritalStatus = ms.MaritalStatus;
                dto.Abbreviation = ms.Abbreviation;
                dto.Description = ms.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateMaritalStatus(MaritalStatusDTO model)
        {
            try
            {
                MaritalStatu ms = db.MaritalStatus.First(x => x.ID == model.ID);
                ms.MaritalStatus = model.MaritalStatus;
                ms.Abbreviation = model.Abbreviation;
                ms.Description = model.Description;
                ms.LastUpdateDate = DateTime.Now;
                ms.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteMaritalStatus(int ID)
        {
            try
            {
                MaritalStatu ms = db.MaritalStatus.First(x => x.ID == ID);
                ms.isDeleted = true;
                ms.DeletedDate = DateTime.Now;
                ms.LastUpdateDate = DateTime.Now;
                ms.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
