using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class UserController : Controller
    {
        UserBLL bll = new UserBLL();
        // GET: Employee/User
        public ActionResult AddUser()
        {
            UserDTO model = new UserDTO();
            model.EmployeeFullName = UserBLL.GetEmployeesForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                if(bll.IsUsernameOrEmailExist(model.Username, model.Email))
                {
                    ViewBag.ProcessState = General.Messages.UserExist;
                }
                else
                {
                    if (bll.AddUser(model))
                    {
                        ViewBag.ProcessState = General.Messages.AddSuccess;
                        EmployeeDTO empmodel = EmployeeBLL.GetEmployeeWithID(model.EmployeeID);
                        var emailSender = new EmailSender();
                        string Subject = "Welcome to the FDA Employee ERP System.";
                        string MessageBody = "Dear " + empmodel.FName+ " " + empmodel.LName + ",\n\nPlease be inform that your account has been created in the Employee ERP system. \n\nYour login credentials are: \n\nUsername: "+model.Username+"\n\nPassword: abcd@1234\n\nPlease change your password upon first login to avoid future embarrasment. \n\n Thank you, and welcome to the team.\n\nThe Admin Team.";
                        emailSender.SendEmail(model.Email, Subject, MessageBody);
                        ModelState.Clear();
                        model = new UserDTO();
                    }
                    else
                        ViewBag.ProcessState = General.Messages.GeneralError;
                }       
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.EmployeeFullName = UserBLL.GetEmployeesForDropdown();
            return View(model);
        }

        public ActionResult UserList()
        {
            List<UserDTO> model = bll.GetUsers();
            return View(model);
        }

        public ActionResult UpdateUser(int ID)
        {
            UserDTO model = bll.UpdateUserWithID(ID);
            EmployeeDTO empmodel = EmployeeBLL.GetEmployeeWithID(model.EmployeeID);
            model.EmployeesName = empmodel.FName + " " + empmodel.LName;
            model.EmployeeFullName = UserBLL.GetEmployeesForDropdown();

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateUser(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    var emailSender = new EmailSender();
                    string Subject = "User Details/Information has been Updated";
                    string MessageBody = "Dear " + model.EmployeesName +",\n\nPlease be inform that your user account details or information has been updated in the Employee ERP system. \n\nKindly login to verify. \n\nYour Username: " + model.Username + "\n\nKnidly note that if your password is changed you will received another email for password reset.\n\nOtherwise, please use same password to login. \n\n Thank you for your service.\n\nThe Admin Team.";
                    emailSender.SendEmail(model.Email, Subject, MessageBody);
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;
            model.EmployeeFullName = UserBLL.GetEmployeesForDropdown();
            return View(model);
        }

        public ActionResult ViewUser(int ID)
        {
            UserDTO model = new UserDTO();
            model = bll.ViewUserWithID(ID);
            return View(model);
        }

        public JsonResult DeleteUser(int ID)
        {
            bll.DeleteUser(ID);
            return Json("");
        }

        public ActionResult PasswordReset(int ID)
        {
            UserDTO model = bll.PassworResetWithID(ID);
            EmployeeDTO empmodel = EmployeeBLL.GetEmployeeWithID(model.EmployeeID);
            model.EmployeesName = empmodel.FName + " " + empmodel.LName;
            //model.EmployeeFullName = UserBLL.GetEmployeesForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult PasswordReset(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.PassworReset(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    var emailSender = new EmailSender();
                    string Subject = "Password Reset";
                    string MessageBody = "Dear " + model.EmployeesName + ",\n\nPlease be inform that your password has been reset to the default credentials in the Employee ERP system. \n\nKindly login and change the details. \n\nUsername: " + model.Username + "\n\n Password: abcd@1234 \n\nThank you for your service.\n\nThe Admin Team.";
                    emailSender.SendEmail(model.Email, Subject, MessageBody);
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;
            return View(model);
        }

    }
}