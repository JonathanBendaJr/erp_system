using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class UserStatic
    {
        public static int UserID { get; set; } = 2;
        public static int EmployeeID { get; set; } = 5;
        public static int DepartmentID { get; set; } = 3;
        public static bool isAdmin { get; set; }
        public static string FName { get; set; }
        public static string LName { get; set; }
        public static string Email { get; set; }
        public static bool isActive { get; set; }
        public static bool isSeniorManagement { get; set; }
        public static bool isITOfficerSupervisor { get; set; }
        public static bool isITOfficer { get; set; }
        public static bool isHRManager { get; set; }
        public static bool isHRSupervisor { get; set; }
        public static bool isHROfficerPayroll { get; set; }
        public static bool isHROfficerGeneral { get; set; }
        public static bool isProcurementManager { get; set; }
        public static bool isProcurementSupervisor { get; set; }
        public static bool isProcurementOfficer { get; set; }
        public static bool isFleetManager { get; set; }
        public static bool isFleetSupervisor { get; set; }
        public static bool isFleetOfficer { get; set; }
        public static bool isDriver { get; set; }
        public static bool isMaintenanceManager { get; set; }
        public static bool isMaintenanceSupervisor { get; set; }
        public static bool isMaintenanceOfficer { get; set; }
        public static bool isGeneralEmployeeManager { get; set; }
        public static bool isGeneralEmployeeSupervisor { get; set; }
        public static bool isGeneralEmployee { get; set; }
        public static bool isHRDept { get; set; }
        public static bool isITDept { get; set; }
        public static bool isProcumentDept { get; set; }
        public static bool isFleetDept { get; set; }
        public static bool isMaintenanceDept { get; set; }
        public static bool isGeneralDept { get; set; }
        public static bool isSeniorManagementDept { get; set; }


    }
}
