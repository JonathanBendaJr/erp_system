using BLL;
using DTO;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeAdditionalInformationController : Controller
    {
        EmployeeWorkBLL workbll = new EmployeeWorkBLL();
        EmployeeSalaryBLL salbll = new EmployeeSalaryBLL();
        EmployeeEducationBLL edubll = new EmployeeEducationBLL();
        EmployeeDepartmentBLL edptbll = new EmployeeDepartmentBLL();
        EmployeeDependantBLL edbll = new EmployeeDependantBLL();
        // GET: Employee/EmployeeAdditionalInformation
        public ActionResult Index()
        {
            return View();
        }

        // Adding Employee Dependants 
        

        // Adding Employee Department, Manager, Supervisor and Position 
       
        

        // Adding Employee Salary and Benefits 
        

        // Adding Employee Work History
       
    }
}