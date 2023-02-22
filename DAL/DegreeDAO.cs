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
    public class DegreeDAO : PostContext
    {
        public int AddDegree(DegreeCredential dc)
        {
            try
            {
                db.DegreeCredentials.Add(dc);
                db.SaveChanges();
                return dc.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DegreeDTO> GetDegrees()
        {
            List<DegreeCredential> list = db.DegreeCredentials.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<DegreeDTO> dtolist = new List<DegreeDTO>();
            foreach (var item in list)
            {
                DegreeDTO dto = new DegreeDTO();
                dto.DegreeName = item.DegreeName;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetDegreeTypeListForDropdown()
        {
            IEnumerable<SelectListItem> degreeTypeList = db.DegreeCredentials.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.DegreeName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return degreeTypeList;
        }

        public DegreeDTO UpdateDegreeWithID(int ID)
        {
            try
            {
                DegreeCredential dc = db.DegreeCredentials.First(x => x.ID == ID);
                DegreeDTO dto = new DegreeDTO();
                dto.ID = dc.ID;
                dto.DegreeName = dc.DegreeName;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateDegree(DegreeDTO model)
        {
            try
            {
                DegreeCredential dc = db.DegreeCredentials.First(x => x.ID == model.ID);
                dc.DegreeName = model.DegreeName;
                dc.LasUpdateDate = DateTime.Now;
                dc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteDegree(int ID)
        {
            try
            {
                DegreeCredential dc = db.DegreeCredentials.First(x => x.ID == ID);
                dc.isDeleted = true;
                dc.DeletedDate = DateTime.Now;
                dc.LasUpdateDate = DateTime.Now;
                dc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
