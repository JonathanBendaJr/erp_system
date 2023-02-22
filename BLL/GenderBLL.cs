using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GenderBLL
    {
        GenderDAO dao = new GenderDAO();
        public bool AddGender(GenderDTO model)
        {
            Gender gd = new Gender();
            gd.Gender1 = model.Gender;
            gd.AddDate = DateTime.Now;
            gd.LastUpdateDate = DateTime.Now;
            gd.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddGender(gd);

            LogDAO.AddLog(General.ProcessType.GenderAdd, General.TableName.Gender, ID);
            return true;
        }

        public List<GenderDTO> GetGenders()
        {
            return dao.GetGenders();
        }

        public GenderDTO UpdateGenderWithID(int ID)
        {
            return dao.UpdateGenderWithID(ID);
        }
        public bool UpdateGender(GenderDTO model)
        {
            dao.UpdateGender(model);
            LogDAO.AddLog(General.ProcessType.GenderUpdate, General.TableName.Gender, model.ID);
            return true;
        }

        public void DeleteGender(int ID)
        {
            dao.DeleteGender(ID);
            LogDAO.AddLog(General.ProcessType.GenderDelete, General.TableName.Gender, ID);
        }
    }
}
