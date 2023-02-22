using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeDepartmentDTO
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public EmployeeDTO employeeDTO { get; set; }
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public IEnumerable<SelectListItem> ManagerRoleList { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public IEnumerable<SelectListItem> PositionList { get; set; }
        public int ManagerRoleID { get; set; }
        public string ManagerRoleTitle { get; set; }
        public IEnumerable<SelectListItem> ManagerList { get; set; }
        public int SupervisorRoleID { get; set; }
        public string SupervisorRoleTitle { get; set; }
        public IEnumerable<SelectListItem> SupervisorList { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
