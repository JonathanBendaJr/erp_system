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
    public class UserBLL
    {
        UserDAO userdao = new UserDAO();
        public UserDTO GetUserWithUserNameAnPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            dto = userdao.GetUserWithUserNameAndPassword(model);
            return dto;
        }
       
        public static IEnumerable<SelectListItem> GetEmployeesForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetEmployeesForDropdown();
        }

        public bool AddUser(UserDTO model)
        {
            T_User user = new T_User();
            user.EmployeeID = model.EmployeeID;
            user.UserName = model.Username;
            user.Password = EncryptDecrypt.Encrypt("abcd@1234");
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.isActive = model.isActive;
            user.isAdmin = model.isAdmin;
            user.isSeniorManagement = model.isSeniorManagement;
            user.isITOfficerSupervisor = model.isITOfficerSupervisor;
            user.isITOfficer = model.isITOfficer;
            user.isHRManager = model.isHRManager;
            user.isHRSupervisor = model.isHRSupervisor;
            user.isHROfficerPayroll = model.isHROfficerPayroll;
            user.isHROfficerGeneral = model.isHROfficerGeneral;
            user.isProcurementManager = model.isProcurementManager;
            user.isProcurementSupervisor = model.isProcurementSupervisor;
            user.isProcurementOfficer = model.isProcurementOfficer;
            user.isFleetManager = model.isFleetManager;
            user.isFleetSupervisor = model.isFleetSupervisor;
            user.isFleetOfficer = model.isFleetOfficer;
            user.isDriver = model.isDriver;
            user.isMaintenanceManager = model.isMaintenanceManager;
            user.isMaintenanceSupervisor = model.isMaintenanceSupervisor;
            user.isMaintenanceOfficer = model.isMaintenanceOfficer;
            user.isGeneralEmployeeManager = model.isGeneralEmployeeManager;
            user.isGeneralEmployeeSupervisor = model.isGeneralEmployeeSupervisor;
            user.isGeneralEmployee = model.isGeneralEmployee;
            user.isHRDept = model.isHRDept;
            user.isITDept = model.isITDept;
            user.isProcumentDept = model.isProcumentDept;
            user.isFleetDept = model.isFleetDept;
            user.isMaintenanceDept = model.isMaintenanceDept;
            user.isGeneralDept = model.isGeneralDept;
            user.isSeniorManagementDept = model.isSeniorManagementDept;
            user.AddDate = DateTime.Now;
            user.LastUpdateDate = DateTime.Now;
            user.LastUpdateUserID = UserStatic.UserID;
            int ID = userdao.AddUser(user);
            LogDAO.AddLog(General.ProcessType.UserAdd, General.TableName.User, ID);
            return true;
        }

        public int UserDepartmentID(int employeeID)
        {
            int DeptID= EmployeeDepartmentDAO.GetDepartmentByEmployeeID(employeeID);
            return DeptID;
        }

        public UserDTO UpdateUserWithID(int ID)
        {
            return userdao.UpdateUserWithID(ID);
        }

        public bool UpdateUser(UserDTO model)
        {
            userdao.UpdateUser(model);
            LogDAO.AddLog(General.ProcessType.UserUpdate, General.TableName.User, model.ID);
            return true;
        }

        public List<UserDTO> GetUsers()
        {
            return userdao.GetUsers();
        }

        public bool IsUsernameOrEmailExist(string username, string email)
        {
            return userdao.IsUsernameOrEmailExist(username, email);
        }

        public UserDTO ViewUserWithID(int ID)
        {
            return userdao.ViewUserWithID(ID);
        }

        public void DeleteUser(int ID)
        {
            userdao.DeleteUser(ID);
            LogDAO.AddLog(General.ProcessType.UserDelete, General.TableName.User, ID);
        }

        public UserDTO PassworResetWithID(int ID)
        {
            return userdao.PassworResetWithID(ID);
        }

        public bool PassworReset(UserDTO model)
        {
            model.Password = EncryptDecrypt.Encrypt("abcd@1234");
            userdao.PassworReset(model);
            LogDAO.AddLog(General.ProcessType.PasswordReset, General.TableName.User, model.ID);
            return true;
        }

        
    }
}
