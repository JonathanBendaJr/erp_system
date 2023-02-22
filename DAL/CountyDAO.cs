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
    public class CountyDAO : PostContext
    {
        public void DeleteCounty(int ID)
        {
            try
            {
                County co = db.Counties.First(x => x.ID == ID);
                co.isDeleted = true;
                co.DeletedDate = DateTime.Now;
                co.LastUpdateDate = DateTime.Now;
                co.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetCountiesForDropdown()
        {
            IEnumerable<SelectListItem> countiesList = db.Counties.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.CountyName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return countiesList;
        }

        public void UpdateCounty(CountyDTO model)
        {
            try
            {
                County co = db.Counties.First(x => x.ID == model.ID);
                co.CountyName = model.CountyName;
                co.LastUpdateDate = DateTime.Now;
                co.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CountyDTO> GetCounties()
        {
            List<County> list = db.Counties.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<CountyDTO> dtolist = new List<CountyDTO>();
            foreach (var item in list)
            {
                CountyDTO dto = new CountyDTO();
                dto.CountyName = item.CountyName;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public int AddCounty(County co)
        {
            try
            {
                db.Counties.Add(co);
                db.SaveChanges();
                return co.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CountyDTO UpdateCountyWithID(int ID)
        {
            try
            {
                County co = db.Counties.First(x => x.ID == ID);
                CountyDTO dto = new CountyDTO();
                dto.ID = co.ID;
                dto.CountyName = co.CountyName;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
