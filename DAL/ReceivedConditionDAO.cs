using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReceivedConditionDAO : PostContext
    {
        public int AddReceivedCondition(ReceivedCondition rc)
        {
            try
            {
                db.ReceivedConditions.Add(rc);
                db.SaveChanges();
                return rc.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReceivedConditionDTO> GetReceivedConditions()
        {
            List<ReceivedCondition> list = db.ReceivedConditions.OrderBy(x => x.ReceiveCondition).ToList();
            List<ReceivedConditionDTO> dtolist = new List<ReceivedConditionDTO>();
            foreach (var item in list)
            {
                ReceivedConditionDTO dto = new ReceivedConditionDTO();
                dto.ReceivedCondition = item.ReceiveCondition;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public ReceivedConditionDTO UpdateReceivedConditionWithID(int ID)
        {
            try
            {
                ReceivedCondition rc = db.ReceivedConditions.First(x => x.ID == ID);
                ReceivedConditionDTO dto = new ReceivedConditionDTO();
                dto.ID = rc.ID;
                dto.ReceivedCondition = rc.ReceiveCondition;
                dto.Description = rc.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateReceivedCondition(ReceivedConditionDTO model)
        {
            try
            {
                ReceivedCondition rc = db.ReceivedConditions.First(x => x.ID == model.ID);
                rc.ReceiveCondition = model.ReceivedCondition;
                rc.Description = model.Description;
                rc.LastUpdateDate = DateTime.Now;
                rc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteReceivedCondition(int ID)
        {
            try
            {
                ReceivedCondition pc = db.ReceivedConditions.First(x => x.ID == ID);
                /*pc.isDeleted = true;
                 pc.DeletedDate = DateTime.Now;*/
                pc.LastUpdateDate = DateTime.Now;
                pc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
