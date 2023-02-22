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
    public class LevelOfUrgencyDAO : PostContext
    {
        public int AddLevelOfUrgency(LevelOfUrgency lou)
        {
            try
            {
                db.LevelOfUrgencies.Add(lou);
                db.SaveChanges();
                return lou.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LevelOfUrgencyDTO> GetLevelOfUrgencies()
        {
            List<LevelOfUrgency> list = db.LevelOfUrgencies.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<LevelOfUrgencyDTO> dtolist = new List<LevelOfUrgencyDTO>();
            foreach (var item in list)
            {
                LevelOfUrgencyDTO dto = new LevelOfUrgencyDTO();
                dto.LevelOfUrgency = item.LevelOfUrgency1;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public LevelOfUrgencyDTO UpdateLevelOfUrgencyWithID(int ID)
        {
            try
            {
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == ID);
                LevelOfUrgencyDTO dto = new LevelOfUrgencyDTO();
                dto.ID = lou.ID;
                dto.LevelOfUrgency = lou.LevelOfUrgency1;
                dto.Description = lou.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetUrgenciesForDropdown()
        {
            IEnumerable<SelectListItem> urgenyList = db.LevelOfUrgencies.Where(x => x.isDeleted == false).OrderBy(x => x.LevelOfUrgency1).Select(x => new SelectListItem()
            {
                Text = x.LevelOfUrgency1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return urgenyList;
        }

        public void UpdateLevelOfUrgency(LevelOfUrgencyDTO model)
        {
            try
            {
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == model.ID);
                lou.LevelOfUrgency1 = model.LevelOfUrgency;
                lou.Description = model.Description;
                lou.LastUpdateDate = DateTime.Now;
                lou.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteLevelOfUrgency(int ID)
        {
            try
            {
                LevelOfUrgency lou = db.LevelOfUrgencies.First(x => x.ID == ID);
                lou.isDeleted = true;
                lou.DeletedDate = DateTime.Now;
                lou.LastUpdateDate = DateTime.Now;
                lou.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
