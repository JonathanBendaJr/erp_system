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
    public class LevelOfUrgencyBLL
    {
        LevelOfUrgencyDAO dao = new LevelOfUrgencyDAO();
        public bool AddLevelOfUrgency(LevelOfUrgencyDTO model)
        {
            LevelOfUrgency lou = new LevelOfUrgency();
            lou.LevelOfUrgency1 = model.LevelOfUrgency;
            lou.Description = model.Description;
            lou.AddDate = DateTime.Now;
            lou.LastUpdateDate = DateTime.Now;
            lou.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddLevelOfUrgency(lou);

            LogDAO.AddLog(General.ProcessType.LevelOfUrgencyAdd, General.TableName.LevelOfUrgency, ID);
            return true;
        }

        

        public List<LevelOfUrgencyDTO> GetLevelOfUrgencies()
        {
            return dao.GetLevelOfUrgencies();
        }

        public LevelOfUrgencyDTO UpdateLevelOfUrgencyWithID(int ID)
        {
            return dao.UpdateLevelOfUrgencyWithID(ID);
        }

        public bool UpdateLevelOfUrgency(LevelOfUrgencyDTO model)
        {
            dao.UpdateLevelOfUrgency(model);
            LogDAO.AddLog(General.ProcessType.LevelOfUrgencyUpdate, General.TableName.LevelOfUrgency, model.ID);
            return true;
        }

        public void DeleteLevelOfUrgency(int ID)
        {
            dao.DeleteLevelOfUrgency(ID);
            LogDAO.AddLog(General.ProcessType.LevelOfUrgencyDelete, General.TableName.LevelOfUrgency, ID);
        }
    }
}
