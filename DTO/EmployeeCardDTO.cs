using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeCardDTO
    {
        public EmployeeDTO Employee { get; set; }
        public EmployeeSalaryDTO EmployeeSalary { get; set; }
        public EmployeeDepartmentDTO EmployeeDepartment { get; set; }
        public List<EmployeeDependantDTO> EmployeeDependants { get; set; }
        public List<EmployeeEducationDTO> EmployeeEducation { get; set; }
        public List<EmployeeWorkDTO> EmployeeWork { get; set; }
    }
}
