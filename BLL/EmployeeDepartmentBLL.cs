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
    public class EmployeeDepartmentBLL
    {
        EmployeeDepartmentDAO dao = new EmployeeDepartmentDAO();
        public bool AddEmployeeDepartment(EmployeeDepartmentDTO model)
        {
            EmpDepManSupPosition edp = new EmpDepManSupPosition();
            edp.DepartmentID = model.DepartmentID;
            edp.EmployeeID = model.EmployeeID;
            //edp.EmployeeID = model.EmployeeID;
            edp.ManagerRoleID = model.ManagerRoleID;
            edp.PositionID = model.PositionID;
            edp.SupervisorRoleID = model.SupervisorRoleID;
            edp.AddDate = DateTime.Now;
            edp.LastUpdateDate = DateTime.Now;
            edp.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeDepartment(edp);

            LogDAO.AddLog(General.ProcessType.EmpDepManSupPositionAdd, General.TableName.EmpDepManSupPosition, ID);
            return true;
        }

        public static EmployeeDTO GetEmployeeDetail(int id)
        {
            return EmployeeDAO.GetEmployeeDetail(id);
        }

        public static IEnumerable<SelectListItem> GetPositionListForDropdown()
        {
            return (List<SelectListItem>)PositionDAO.GetPositionListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetManagerListForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetManagerListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetSupervisorListForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetSupervisorListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetDepartmentListForDropdown()
        {
            return (List<SelectListItem>)DepartmentDAO.GetDepartmentListForDropdown();
        }

        public bool UpdateEmployeeDepartment(EmployeeDepartmentDTO model)
        {
            dao.UpdateEmployeeDepartment(model);
            LogDAO.AddLog(General.ProcessType.EmpDepManSupPositionUpdate, General.TableName.EmpDepManSupPosition, model.ID);
            return true;
        }

        public void DeleteEmployeeDepartment(int ID)
        {
            dao.DeleteEmployeeDepartment(ID);
            LogDAO.AddLog(General.ProcessType.EmpDepManSupPositionAdd, General.TableName.EmpDepManSupPosition, ID);
        }

        public EmployeeDepartmentDTO UpdateEmployeeDepartmentWithID(int ID)
        {
            return dao.UpdateEmployeeDepartmentWithID(ID);
        }

        public List<EmployeeDepartmentDTO> GetEmployeeDepartments()
        {
            return dao.GetEmployeeDepartments();
        }
    }
}
