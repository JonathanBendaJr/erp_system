using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DegreeBLL
    {
        DegreeDAO dao = new DegreeDAO();
        public bool AddDegree(DegreeDTO model)
        {
            DegreeCredential dc = new DegreeCredential();
            dc.DegreeName = model.DegreeName;
            dc.AddDate = DateTime.Now;
            dc.LasUpdateDate = DateTime.Now;
            dc.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddDegree(dc);

            LogDAO.AddLog(General.ProcessType.DegreeAdd, General.TableName.Degree, ID);
            return true;
        }

        public List<DegreeDTO> GetDregrees()
        {
            return dao.GetDegrees();
        }

        public DegreeDTO UpdateDegreeWithID(int ID)
        {
            return dao.UpdateDegreeWithID(ID);
        }

        public bool UpdateDegree(DegreeDTO model)
        {
            dao.UpdateDegree(model);
            LogDAO.AddLog(General.ProcessType.DegreeUpdate, General.TableName.Degree, model.ID);
            return true;
        }

        public void DeleteDegree(int ID)
        {
            dao.DeleteDegree(ID);
            LogDAO.AddLog(General.ProcessType.DegreeDelete, General.TableName.Degree, ID);
        }
    }
}
