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
    public class PayGradeDAO : PostContext
    {
        public int AddPayGrade(PayGrade pg)
        {
            try
            {
                db.PayGrades.Add(pg);
                db.SaveChanges();
                return pg.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PayGradeDTO> GetPayGrades()
        {
            var paygradelist = (from pg in db.PayGrades.Where(x => x.isDeleted == false)
                            join ps in db.Positions on pg.PositionID equals ps.ID
                            select new
                            {
                                ID = pg.ID,
                                PayG = pg.PayGrade1,
                                PositionName = ps.PositionName,
                                AddDate = pg.AddDate
                            }).OrderByDescending(x => x.AddDate).ToList();
            List<PayGradeDTO> dtolist = new List<PayGradeDTO>();
            foreach (var item in paygradelist)
            {
                PayGradeDTO dto = new PayGradeDTO();
                dto.PayGrade = item.PayG;
                dto.ID = item.ID;
                dto.PositionName = item.PositionName;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetPayGradeListForDropdown()
        {
            IEnumerable<SelectListItem> payGradeList = db.PayGrades.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.PayGrade1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return payGradeList;
        }

        public PayGradeDTO UpdatePayGradeWithID(int ID)
        {
            try
            {
                PayGrade pg = db.PayGrades.First(x => x.ID == ID);
                PayGradeDTO dto = new PayGradeDTO();
                dto.ID = pg.ID;
                dto.PositionID = pg.PositionID;
                dto.PayGrade = pg.PayGrade1;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePayGrade(PayGradeDTO model)
        {
            try
            {
                PayGrade pg = db.PayGrades.First(x => x.ID == model.ID);
                pg.PayGrade1 = model.PayGrade;
                pg.PositionID = model.PositionID;
                pg.LastUpdateDate = DateTime.Now;
                pg.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePayGrade(int ID)
        {
            try
            {
                PayGrade pg = db.PayGrades.First(x => x.ID == ID);
                pg.isDeleted = true;
                pg.DeletedDate = DateTime.Now;
                pg.LastUpdateDate = DateTime.Now;
                pg.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
