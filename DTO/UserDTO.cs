using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please select employee.")]
        public int EmployeeID { get; set; }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeesName { get; set; }
        public IEnumerable<SelectListItem> EmployeeFullName { get; set; }
        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string encryptedPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isActive { get; set; }
        public bool isAdmin { get; set; }
        public bool isSeniorManagement { get; set; }
        public bool isITOfficerSupervisor { get; set; }
        public bool isITOfficer { get; set; }
        public bool isHRManager { get; set; }
        public bool isHRSupervisor { get; set; }
        public bool isHROfficerPayroll { get; set; }
        public bool isHROfficerGeneral { get; set; }
        public bool isProcurementManager { get; set; }
        public bool isProcurementSupervisor { get; set; }
        public bool isProcurementOfficer { get; set; }
        public bool isFleetManager { get; set; }
        public bool isFleetSupervisor { get; set; }
        public bool isFleetOfficer { get; set; }
        public bool isDriver { get; set; }
        public bool isMaintenanceManager { get; set; }
        public bool isMaintenanceSupervisor { get; set; }
        public bool isMaintenanceOfficer { get; set; }
        public bool isGeneralEmployeeManager { get; set; }
        public bool isGeneralEmployeeSupervisor { get; set; }
        public bool isGeneralEmployee { get; set; }
        public bool isHRDept { get; set; }
        public bool isITDept { get; set; }
        public bool isProcumentDept { get; set; }
        public bool isFleetDept { get; set; }
        public bool isMaintenanceDept { get; set; }
        public bool isGeneralDept { get; set; }
        public bool isSeniorManagementDept { get; set; }
        public DateTime AddDate { get; set; }
        
    }
}
