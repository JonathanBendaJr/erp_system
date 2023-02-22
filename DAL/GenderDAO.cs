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
    public class GenderDAO : PostContext
    {
        public int AddGender(Gender gd)
        {
            try
            {
                db.Genders.Add(gd);
                db.SaveChanges();
                return gd.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<GenderDTO> GetGenders()
        {
            List<Gender> list = db.Genders.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<GenderDTO> dtolist = new List<GenderDTO>();
            foreach (var item in list)
            {
                GenderDTO dto = new GenderDTO();
                dto.Gender = item.Gender1;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetGendersForDropdown()
        {
            IEnumerable<SelectListItem> genderList = db.Genders.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.Gender1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return genderList;
        }

        public void UpdateGender(GenderDTO model)
        {
            try
            {
                Gender gd = db.Genders.First(x => x.ID == model.ID);
                gd.Gender1 = model.Gender;
                gd.LastUpdateDate = DateTime.Now;
                gd.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GenderDTO UpdateGenderWithID(int ID)
        {
            try
            {
                Gender gd = db.Genders.First(x => x.ID == ID);
                GenderDTO dto = new GenderDTO();
                dto.ID = gd.ID;
                dto.Gender = gd.Gender1;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteGender(int ID)
        {
            try
            {
                Gender gd = db.Genders.First(x => x.ID == ID);
                gd.isDeleted = true;
                gd.DeletedDate = DateTime.Now;
                gd.LastUpdateDate = DateTime.Now;
                gd.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
