using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeRoleBLL
    {
        EmployeeRoleDAO dao = new EmployeeRoleDAO();
        public bool AddEmployeeRole(EmployeeRoleDTO model)
        {
            EmpRole er = new  EmpRole();
            er.Role = model.Role;
            er.AddDate = DateTime.Now;
            er.LastUpdateDate = DateTime.Now;
            er.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeRole(er);

            LogDAO.AddLog(General.ProcessType.EmployeeRoleAdd, General.TableName.EmpRole, ID);
            return true;
        }

        public List<EmployeeRoleDTO> GetEmployeeRoles()
        {
            return dao.GetEmployeeRoles();
        }

        public EmployeeRoleDTO UpdateEmployeeRoleWithID(int ID)
        {
            return dao.UpdateEmployeeRoleWithID(ID);
        }

        public bool UpdateEmployeeRole(EmployeeRoleDTO model)
        {
            dao.UpdateEmployeeRole(model);
            LogDAO.AddLog(General.ProcessType.EmployeeRoleUpdate, General.TableName.EmpRole, model.ID);
            return true;
        }

        public void DeleteEmployeeRole(int ID)
        {
            dao.DeleteEmployeeRole(ID);
            LogDAO.AddLog(General.ProcessType.EmployeeRoleDelete, General.TableName.EmpRole, ID);
        }
    }
}
