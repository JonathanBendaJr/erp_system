using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class LoginController : Controller
    {
        UserBLL userbll = new UserBLL();
        EmployeeDepartmentBLL empdepbll = new EmployeeDepartmentBLL();
        // GET: Employee/Login
        public ActionResult Index()
        {
            UserDTO dto = new UserDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(UserDTO model)
        {
            if (model.Username != null && model.Password != null)
            {
                model.Username = model.Username;
                model.encryptedPassword = EncryptDecrypt.Encrypt(model.Password);
                UserDTO user = userbll.GetUserWithUserNameAnPassword(model);
               


                    if (user.ID != 0 && user.isActive == true)
                    {
                        //get employee details using employee id in the usertable
                       
                        UserStatic.UserID = user.ID;
                    //EmployeeDepartmentDTO dep = empdepbll.GetEmployeeDepartmentAndPosition(user.EmployeeID);
                        UserStatic.FName = user.EmpFName;
                        UserStatic.LName = user.EmpLName;
                        UserStatic.EmployeeID = user.EmployeeID;
                        UserStatic.DepartmentID = user.DepartmentID;
                        UserStatic.isAdmin = user.isAdmin;
                        UserStatic.isSeniorManagement = user.isSeniorManagement;
                        UserStatic.isITOfficerSupervisor = user.isITOfficerSupervisor;
                        UserStatic.isITOfficer = user.isITOfficer;
                        UserStatic.isHRManager = user.isHRManager;
                        UserStatic.isHRSupervisor = user.isHRSupervisor;
                        UserStatic.isHROfficerPayroll = user.isHROfficerPayroll;
                        UserStatic.isHROfficerGeneral = user.isHROfficerGeneral;
                        UserStatic.isProcurementManager = user.isProcurementManager;
                        UserStatic.isProcurementSupervisor = user.isProcurementSupervisor;
                        UserStatic.isProcurementOfficer = user.isProcurementOfficer;
                        UserStatic.isFleetManager = user.isFleetManager;
                        UserStatic.isFleetSupervisor = user.isFleetSupervisor;
                        UserStatic.isFleetOfficer = user.isFleetOfficer;
                        UserStatic.isDriver = user.isDriver;
                        UserStatic.isMaintenanceManager = user.isMaintenanceManager;
                        UserStatic.isMaintenanceSupervisor = user.isMaintenanceSupervisor;
                        UserStatic.isMaintenanceOfficer = user.isMaintenanceOfficer;
                        UserStatic.isGeneralEmployeeManager = user.isGeneralEmployeeManager;
                        UserStatic.isGeneralEmployeeSupervisor = user.isGeneralEmployeeSupervisor;
                        UserStatic.isGeneralEmployee = user.isGeneralEmployee;
                        UserStatic.isHRDept = user.isHRDept;
                        UserStatic.isITDept = user.isITDept;
                        UserStatic.isProcumentDept = user.isProcumentDept;
                        UserStatic.isFleetDept = user.isFleetDept;
                        UserStatic.isMaintenanceDept = user.isMaintenanceDept;
                        UserStatic.isGeneralDept = user.isGeneralDept;
                        UserStatic.isSeniorManagementDept = user.isSeniorManagementDept;
                        UserStatic.PositionName = user.PositionName;

                    LogBLL.AddLog(General.ProcessType.Login, General.TableName.Login, 12);
                        if (UserStatic.isITDept == true)
                            return RedirectToAction("Index", "AdminHome");
                        else if (UserStatic.isHRDept == true)
                            return RedirectToAction("Index", "HRHome");
                        else if (UserStatic.isFleetDept == true)
                            return RedirectToAction("Index", "FleetHome");
                        else if (UserStatic.isMaintenanceDept == true)
                            return RedirectToAction("Index", "MaintenanceHome");
                        else if (UserStatic.isProcumentDept == true)
                            return RedirectToAction("Index", "ProcurementHome");
                        else if (UserStatic.isGeneralDept == true)
                            return RedirectToAction("Index", "GeneralHome");
                        else if (UserStatic.isSeniorManagementDept == true)
                            return RedirectToAction("Index", "SrManageHome");
                    }
                else
                {
                    ViewBag.ProcessState = General.Messages.PasswordIncorrect;
                    return View(model);
                }
                ViewBag.ProcessState = General.Messages.LoginError;
                return View(model);
            }
            else
            {
                ViewBag.ProcessState = General.Messages.LoginError;
                return View(model);
            }

        }
    }
}