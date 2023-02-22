using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeCardBLL
    {
        EmployeeCardDAO dao = new EmployeeCardDAO();
        public EmployeeCardDTO ViewEmployeeCardWithID(int ID)
        {
            EmployeeCardDTO dto = new EmployeeCardDTO();
            dto.Employee = dao.GetEmployeeWithEmployeeID(ID);
            dto.EmployeeDepartment = dao.GetDepartmentWithEmployeeID(ID);
            dto.EmployeeSalary = dao.GetSalaryWithEmployeeID(ID);
            dto.EmployeeDependants = dao.GetDependantsWithEmployeeID(ID);
            dto.EmployeeEducation = dao.GetEducationsWithEmployeeID(ID);
            dto.EmployeeWork = dao.GetWorkWithEmployeeID(ID);
            
            return dto;
        }
    }
}
