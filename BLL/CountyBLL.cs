using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CountyBLL
    {
        CountyDAO dao = new CountyDAO();
        public bool AddCounty(CountyDTO model)
        {
            County co = new County();
            co.CountyName = model.CountyName;
            co.AddDate = DateTime.Now;
            co.LastUpdateDate = DateTime.Now;
            co.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddCounty(co);

            LogDAO.AddLog(General.ProcessType.CountyAdd, General.TableName.County, ID);
            return true;
        }

        public List<CountyDTO> GetCounties()
        {
            return dao.GetCounties();
        }

        public CountyDTO UpdateCountyWithID(int ID)
        {
            return dao.UpdateCountyWithID(ID);
        }

        public bool UpdateCounty(CountyDTO model)
        {
            dao.UpdateCounty(model);
            LogDAO.AddLog(General.ProcessType.CountyUpdate, General.TableName.County, model.ID);
            return true;
        }

        public void DeleteCounty(int ID)
        {
            dao.DeleteCounty(ID);
            LogDAO.AddLog(General.ProcessType.CountyDelete, General.TableName.County, ID);
        }
    }
}
