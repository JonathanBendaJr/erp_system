using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PositionBLL
    {
        PositionDAO dao = new PositionDAO();
        public bool AddPosition(PositionDTO model)
        {
            Position po = new Position();
            po.PositionName = model.PositionName;
            po.Description = model.Description;
            po.PositionGrade = model.PositionGrade;
            po.isSupervisory = model.isSupervisory;
            po.isManagerial = model.isManagerial;
            po.isTopManagement = model.isTopManagement;
            po.AddDate = DateTime.Now;
            po.LastUpdateDate = DateTime.Now;
            po.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddPosition(po);

            LogDAO.AddLog(General.ProcessType.PositionAdd, General.TableName.Position, ID);
            return true;
        }

        public List<PositionDTO> GetPositions()
        {
            return dao.GetPositions();
        }

        public PositionDTO UpdatePositionWithID(int ID)
        {
            return dao.UpdatePositionWithID(ID);
        }

        public bool UpdatePosition(PositionDTO model)
        {
            dao.UpdatePosition(model);
            LogDAO.AddLog(General.ProcessType.PositionUpdate, General.TableName.Position, model.ID);
            return true;
        }

        public void DeletePosition(int ID)
        {
            dao.DeletePosition(ID);
            LogDAO.AddLog(General.ProcessType.PositionDelete, General.TableName.Position, ID);
        }

        public string GetUserPosition(int employeeID)
        {
            PositionDTO  dto = dao.GetUserPosition(employeeID);
            return dto.PositionName;
        }
    }
}
