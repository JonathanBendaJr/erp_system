using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentBLL
    {
        DepartmentDAO dao = new DepartmentDAO();
        public bool AddDepartment(DepartmentDTO model)
        {
            Department dp = new Department();
            dp.DepartmentName = model.DepartmentName;
            dp.Description = model.Description;
            dp.AddDate = DateTime.Now;
            dp.LastUpdateDate = DateTime.Now;
            dp.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddDepartment(dp);

            LogDAO.AddLog(General.ProcessType.DepartmentAdd, General.TableName.Department, ID);
            return true;
        }

        public List<DepartmentDTO> GetDepartments()
        {
            return dao.GetDepartments();
        }
        public DepartmentDTO UpdateDepartmentWithID(int ID)
        {
            return dao.UpdateDepartmentWithID(ID);
        }

        public bool UpdateDepartment(DepartmentDTO model)
        {
            dao.UpdateDepartment(model);
            LogDAO.AddLog(General.ProcessType.DepartmentUpdate, General.TableName.Department, model.ID);
            return true;
        }

        public void DeleteDepartment(int ID)
        {
            dao.DeleteDepartment(ID);
            LogDAO.AddLog(General.ProcessType.DepartmentDelete, General.TableName.Department, ID);
        }
    }
}
