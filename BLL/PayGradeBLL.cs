using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class PayGradeBLL
    {
        PayGradeDAO dao = new PayGradeDAO();
        public bool AddPayGrade(PayGradeDTO model)
        {
            PayGrade pg = new PayGrade();
            pg.PayGrade1 = model.PayGrade;
            pg.PositionID = model.PositionID;
            pg.AddDate = DateTime.Now;
            pg.LastUpdateDate = DateTime.Now;
            pg.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddPayGrade(pg);

            LogDAO.AddLog(General.ProcessType.PayGradeAdd, General.TableName.PayGrade, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetPositionListForDropdown()
        {
            return (List<SelectListItem>)PositionDAO.GetPositionListForDropdown();
        }

        public List<PayGradeDTO> GetPayGrades()
        {
            return dao.GetPayGrades();
        }

        public PayGradeDTO UpdatePayGradeWithID(int ID)
        {
            return dao.UpdatePayGradeWithID(ID);
        }

        public bool UpdatePayGrade(PayGradeDTO model)
        {
            dao.UpdatePayGrade(model);
            LogDAO.AddLog(General.ProcessType.PayGradeUpdate, General.TableName.PayGrade, model.ID);
            return true;
        }

        public void DeletePayGrade(int ID)
        {
            dao.DeletePayGrade(ID);
            LogDAO.AddLog(General.ProcessType.PayGradeDelete, General.TableName.PayGrade, ID);
        }
    }
}
