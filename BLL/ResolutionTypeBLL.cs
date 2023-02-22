using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResolutionTypeBLL
    {
        ResolutionTypeDAO dao = new ResolutionTypeDAO();
        public void DeleteResolutionType(int ID)
        {
            dao.DeleteResolutionType(ID);
            LogDAO.AddLog(General.ProcessType.ResolutionTypeDelete, General.TableName.ResolutionType, ID);
        }

        public bool UpdateResolutionType(ResolutionTypeDTO model)
        {
            dao.UpdateResolutionType(model);
            LogDAO.AddLog(General.ProcessType.ResolutionTypeUpdate, General.TableName.ResolutionType, model.ID);
            return true;
        }

        public ResolutionTypeDTO UpdateResolutionTypeWithID(int ID)
        {
            return dao.UpdateResolutionTypeWithID(ID);
        }

        public List<ResolutionTypeDTO> GetResolutionTypes()
        {
            return dao.GetResolutionTypes();
        }

        public bool AddResolutionType(ResolutionTypeDTO model)
        {
            ResolutionType rt = new ResolutionType();
            rt.ResolutionType1 = model.ResolutionType;
            rt.Description = model.Description;
            rt.AddDate = DateTime.Now;
            rt.LastUpdateDate = DateTime.Now;
            rt.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddResolutionType(rt);

            LogDAO.AddLog(General.ProcessType.ResolutionTypeAdd, General.TableName.ResolutionType, ID);
            return true;
        }
    }
}
