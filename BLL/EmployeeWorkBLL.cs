using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeWorkBLL
    {
        EmployeeWorkDAO dao = new EmployeeWorkDAO();
        public void DeleteEmployeeWork(int ID)
        {
            dao.DeleteEmployeeWork(ID);
            LogDAO.AddLog(General.ProcessType.WorkExperienceDelete, General.TableName.WorkExperience, ID);
        }

        public bool UpdateEmployeeWork(EmployeeWorkDTO model)
        {
            dao.UpdateEmployeeWork(model);
            LogDAO.AddLog(General.ProcessType.WorkExperienceUpdate, General.TableName.WorkExperience, model.ID);
            return true;
        }

        public EmployeeWorkDTO UpdateEmployeeWorkWithID(int ID)
        {
            return dao.UpdateEmployeeWorkWithID(ID);
        }

        public List<EmployeeWorkDTO> GetEmployeeWorks()
        {
            return dao.GetEmployeeWorks();
        }

        public bool AddEmployeeWork(EmployeeWorkDTO model)
        {
            WorkExperience work = new WorkExperience();
            work.PositionTitle = model.PositionTitle;
            work.Responsibilities = model.Responsibilities;
            work.StartDate = model.StartDate;
            work.EndDate = model.EndDate;
            work.EmployeeID = model.EmployeeID;
            work.AddDate = DateTime.Now;
            work.LastUpdateDate = DateTime.Now;
            work.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeWork(work);

            LogDAO.AddLog(General.ProcessType.WorkExperienceAdd, General.TableName.WorkExperience, ID);
            return true;
        }
    }
}
