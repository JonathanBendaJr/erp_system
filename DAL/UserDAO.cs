using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : PostContext
    {
        public UserDTO GetUserWithUserNameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            T_User user = db.T_User.FirstOrDefault(x => x.UserName == model.Username && x.Password == model.encryptedPassword);
            if (user != null && user.ID != 0)
            {
                
                Employee emp = db.Employees.First(x => x.ID == user.EmployeeID);
                dto.EmployeeID = emp.ID;
                dto.EmpFName = emp.FName;
                dto.EmpLName = emp.LName;
                dto.ID = user.ID;
                dto.DepartmentID = EmployeeDepartmentDAO.GetDepartmentByEmployeeID(user.EmployeeID);
                dto.Username = user.UserName;
                dto.isActive = user.isActive;
                dto.isAdmin = user.isAdmin;
                dto.isSeniorManagement = user.isSeniorManagement;
                dto.isITOfficerSupervisor = user.isITOfficerSupervisor;
                dto.isITOfficer = user.isITOfficer;
                dto.isHRManager = user.isHRManager;
                dto.isHRSupervisor = user.isHRSupervisor;
                dto.isHROfficerPayroll = user.isHROfficerPayroll;
                dto.isHROfficerGeneral = user.isHROfficerGeneral;
                dto.isProcurementManager = user.isProcurementManager;
                dto.isProcurementSupervisor = user.isProcurementSupervisor;
                dto.isProcurementOfficer = user.isProcurementOfficer;
                dto.isFleetManager = user.isFleetManager;
                dto.isFleetSupervisor = user.isFleetSupervisor;
                dto.isFleetOfficer = user.isFleetOfficer;
                dto.isDriver = user.isDriver;
                dto.isMaintenanceManager = user.isMaintenanceManager;
                dto.isMaintenanceSupervisor = user.isMaintenanceSupervisor;
                dto.isMaintenanceOfficer = user.isMaintenanceOfficer;
                dto.isGeneralEmployeeManager = user.isGeneralEmployeeManager;
                dto.isGeneralEmployeeSupervisor = user.isGeneralEmployeeSupervisor;
                dto.isGeneralEmployee = user.isGeneralEmployee;
                dto.isHRDept = user.isHRDept;
                dto.isITDept = user.isITDept;
                dto.isProcumentDept = user.isProcumentDept;
                dto.isFleetDept = user.isFleetDept;
                dto.isMaintenanceDept = user.isMaintenanceDept;
                dto.isGeneralDept = user.isGeneralDept;
                dto.isSeniorManagementDept = user.isSeniorManagementDept;
            }
            return dto;
        }

        public int AddUser(T_User user)
        {
            try
            {
                db.T_User.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUsernameOrEmailExist(string username, string email)
        {
            return db.T_User.Any(u => u.UserName == username || u.Email == email);
        }

        public List<UserDTO> GetUsers()
        {
            var userList = (from usr in db.T_User.Where(x => x.isDeleted == false)
                                join emp in db.Employees on usr.EmployeeID equals emp.ID
                                select new
                                {
                                    ID = usr.ID,
                                    empID = usr.EmployeeID,
                                    FName = emp.FName,
                                    LName = emp.LName,
                                    Email = usr.Email,
                                    Phone = usr.Phone,
                                    isActive = usr.isActive,
                                    AddDate = usr.AddDate,
                                }).OrderByDescending(x => x.AddDate).ToList();
            //List<Employee> list = db.Employees.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            List<UserDTO> dtolist = new List<UserDTO>();
            foreach (var item in userList)
            {
                UserDTO dto = new UserDTO();
                dto.ID = item.ID;
                dto.EmployeeID = Convert.ToInt32(item.empID);
                dto.EmployeesName = item.FName + " " +item.LName;
                dto.Email = item.Email;
                dto.Phone = item.Phone;
                dto.isActive = item.isActive;
                dto.AddDate = item.AddDate;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public UserDTO PassworResetWithID(int ID)
        {
            try
            {
                T_User usr = db.T_User.First(x => x.ID == ID);
                UserDTO dto = new UserDTO();
                dto.ID = usr.ID;
                dto.EmployeeID = Convert.ToInt32(usr.EmployeeID);
                dto.Username = usr.UserName;
                dto.Email = usr.Email;
                dto.Phone = usr.Phone;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PassworReset(UserDTO model)
        {
            try
            {
                T_User usr = db.T_User.First(x => x.ID == model.ID);
                /*usr.EmployeeID = model.EmployeeID;
                usr.UserName = model.Username;
                usr.Email = model.Email;*/
                usr.Password = model.Password;
                usr.LastUpdateDate = DateTime.Now;
                usr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUser(int ID)
        {
            try
            {
                T_User usr = db.T_User.First(x => x.ID == ID);
                usr.isDeleted = true;
                usr.DeletedDate = DateTime.Now;
                usr.LastUpdateDate = DateTime.Now;
                usr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDTO ViewUserWithID(int ID)
        {
            T_User usr = db.T_User.First(x => x.ID == ID);
            UserDTO dto = new UserDTO();
            dto.ID = usr.ID;
            dto.EmployeeID = Convert.ToInt32(usr.EmployeeID);
            dto.Username = usr.UserName;
            dto.Email = usr.Email;
            dto.Phone = usr.Phone;
            dto.isActive = usr.isActive;
            dto.isAdmin = usr.isAdmin;
            dto.isDriver = usr.isDriver;
            dto.isFleetDept = usr.isFleetDept;
            dto.isFleetManager = usr.isFleetManager;
            dto.isFleetOfficer = usr.isFleetOfficer;
            dto.isFleetSupervisor = usr.isFleetSupervisor;
            dto.isHRDept = usr.isHRDept;
            dto.isHRManager = usr.isHRManager;
            dto.isHROfficerGeneral = usr.isHROfficerGeneral;
            dto.isHROfficerPayroll = usr.isHROfficerPayroll;
            dto.isHRSupervisor = usr.isHRSupervisor;
            dto.isProcumentDept = usr.isProcumentDept;
            dto.isProcurementManager = usr.isProcurementManager;
            dto.isProcurementOfficer = usr.isProcurementOfficer;
            dto.isProcurementSupervisor = usr.isProcurementSupervisor;
            dto.isSeniorManagement = usr.isSeniorManagement;
            dto.isSeniorManagementDept = usr.isSeniorManagementDept;
            dto.isMaintenanceDept = usr.isMaintenanceDept;
            dto.isMaintenanceManager = usr.isMaintenanceManager;
            dto.isMaintenanceOfficer = usr.isMaintenanceOfficer;
            dto.isMaintenanceSupervisor = usr.isMaintenanceSupervisor;
            dto.isITDept = usr.isITDept;
            dto.isITOfficer = usr.isITOfficer;
            dto.isITOfficerSupervisor = usr.isITOfficerSupervisor;
            dto.isGeneralDept = usr.isGeneralDept;
            dto.isGeneralEmployee = usr.isGeneralEmployee;
            dto.isGeneralEmployeeManager = usr.isGeneralEmployeeManager;
            dto.isGeneralEmployeeSupervisor = usr.isGeneralEmployeeSupervisor;
            Employee emp = db.Employees.First(x => x.ID == usr.EmployeeID);
            dto.EmployeesName = emp.FName + " " + emp.LName;
            return dto;
        }

        public UserDTO UpdateUserWithID(int ID)
        {
            try
            {
                T_User usr = db.T_User.First(x => x.ID == ID);
                UserDTO dto = new UserDTO();
                dto.ID = usr.ID;
                dto.EmployeeID = Convert.ToInt32(usr.EmployeeID);
                dto.Username = usr.UserName;
                dto.Email = usr.Email;
                dto.Phone = usr.Phone;
                dto.isActive = usr.isActive;
                dto.isAdmin = usr.isAdmin;
                dto.isDriver = usr.isDriver;
                dto.isFleetDept = usr.isFleetDept;
                dto.isFleetManager = usr.isFleetManager;
                dto.isFleetOfficer = usr.isFleetOfficer;
                dto.isFleetSupervisor = usr.isFleetSupervisor;
                dto.isHRDept = usr.isHRDept;
                dto.isHRManager = usr.isHRManager;
                dto.isHROfficerGeneral = usr.isHROfficerGeneral;
                dto.isHROfficerPayroll = usr.isHROfficerPayroll;
                dto.isHRSupervisor = usr.isHRSupervisor;
                dto.isProcumentDept = usr.isProcumentDept;
                dto.isProcurementManager = usr.isProcurementManager;
                dto.isProcurementOfficer = usr.isProcurementOfficer;
                dto.isProcurementSupervisor = usr.isProcurementSupervisor;
                dto.isSeniorManagement = usr.isSeniorManagement;
                dto.isSeniorManagementDept = usr.isSeniorManagementDept;
                dto.isMaintenanceDept = usr.isMaintenanceDept;
                dto.isMaintenanceManager = usr.isMaintenanceManager;
                dto.isMaintenanceOfficer = usr.isMaintenanceOfficer;
                dto.isMaintenanceSupervisor = usr.isMaintenanceSupervisor;
                dto.isITDept = usr.isITDept;
                dto.isITOfficer = usr.isITOfficer;
                dto.isITOfficerSupervisor = usr.isITOfficerSupervisor;
                dto.isGeneralDept = usr.isGeneralDept;
                dto.isGeneralEmployee = usr.isGeneralEmployee;
                dto.isGeneralEmployeeManager = usr.isGeneralEmployeeManager;
                dto.isGeneralEmployeeSupervisor = usr.isGeneralEmployeeSupervisor;
                
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(UserDTO model)
        {
            try
            {
                T_User usr = db.T_User.First(x => x.ID == model.ID);
                /*usr.EmployeeID = model.EmployeeID;
                usr.UserName = model.Username;
                usr.Email = model.Email;*/
                usr.Phone = model.Phone;
                usr.isActive = model.isActive;
                usr.isAdmin = model.isAdmin;
                usr.isDriver = model.isDriver;
                usr.isFleetDept = model.isFleetDept;
                usr.isFleetManager = model.isFleetManager;
                usr.isFleetOfficer = model.isFleetOfficer;
                usr.isFleetSupervisor = model.isFleetSupervisor;
                usr.isHRDept = model.isHRDept;
                usr.isHRManager = model.isHRManager;
                usr.isHROfficerGeneral = model.isHROfficerGeneral;
                usr.isHROfficerPayroll = model.isHROfficerPayroll;
                usr.isHRSupervisor = model.isHRSupervisor;
                usr.isProcumentDept = model.isProcumentDept;
                usr.isProcurementManager = model.isProcurementManager;
                usr.isProcurementOfficer = model.isProcurementOfficer;
                usr.isProcurementSupervisor = model.isProcurementSupervisor;
                usr.isSeniorManagement = model.isSeniorManagement;
                usr.isSeniorManagementDept = model.isSeniorManagementDept;
                usr.isMaintenanceDept = model.isMaintenanceDept;
                usr.isMaintenanceManager = model.isMaintenanceManager;
                usr.isMaintenanceOfficer = model.isMaintenanceOfficer;
                usr.isMaintenanceSupervisor = model.isMaintenanceSupervisor;
                usr.isITDept = model.isITDept;
                usr.isITOfficer = model.isITOfficer;
                usr.isITOfficerSupervisor = model.isITOfficerSupervisor;
                usr.isGeneralDept = model.isGeneralDept;
                usr.isGeneralEmployee = model.isGeneralEmployee;
                usr.isGeneralEmployeeManager = model.isGeneralEmployeeManager;
                usr.isGeneralEmployeeSupervisor = model.isGeneralEmployeeSupervisor;
                usr.LastUpdateDate = DateTime.Now;
                usr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
