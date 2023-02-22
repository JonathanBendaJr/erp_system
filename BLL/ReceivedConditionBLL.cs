using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReceivedConditionBLL
    {
        ReceivedConditionDAO dao = new ReceivedConditionDAO();
        public bool AddReceivedCondition(ReceivedConditionDTO model)
        {
            ReceivedCondition rc = new ReceivedCondition();
            rc.ReceiveCondition = model.ReceivedCondition;
            rc.Description = model.Description;
            rc.AddDate = DateTime.Now;
            rc.LastUpdateDate = DateTime.Now;
            rc.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddReceivedCondition(rc);

            LogDAO.AddLog(General.ProcessType.ReceivedConditionAdd, General.TableName.ReceivedCondition, ID);
            return true;
        }

        public List<ReceivedConditionDTO> GetReceivedConditions()
        {
            return dao.GetReceivedConditions();
        }

        public ReceivedConditionDTO UpdateReceivedConditionWithID(int ID)
        {
            return dao.UpdateReceivedConditionWithID(ID);
        }

        public bool UpdateReceivedCondition(ReceivedConditionDTO model)
        {
            dao.UpdateReceivedCondition(model);
            LogDAO.AddLog(General.ProcessType.ReceivedConditionUpdate, General.TableName.ReceivedCondition, model.ID);
            return true;
        }

        public void DeleteReceivedCondition(int ID)
        {
            dao.DeleteReceivedCondition(ID);
            LogDAO.AddLog(General.ProcessType.ReceivedConditionDelete, General.TableName.ReceivedCondition, ID);
        }
    }
}
