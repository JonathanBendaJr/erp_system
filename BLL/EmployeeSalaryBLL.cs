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
    public class EmployeeSalaryBLL
    {
        EmployeeSalaryDAO dao = new EmployeeSalaryDAO();
        public bool AddEmployeeSalary(EmployeeSalaryDTO model)
        {
            EmpSalaryBenefit sal = new EmpSalaryBenefit();
            sal.EmployeeID = model.EmployeeID;
            sal.BasicSalary = Convert.ToDecimal(model.BasicSalary);
            sal.PayGradeID = model.PayGradeID;
            sal.Allowance1 = Convert.ToDecimal(model.Allowance1);
            sal.Allowance2 = Convert.ToDecimal(model.Allowance2);
            sal.GrossSalary = sal.BasicSalary + sal.Allowance1 + sal.Allowance2;
            sal.AddDate = DateTime.Now;
            sal.LastUpdateDate = DateTime.Now;
            sal.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeSalary(sal);

            LogDAO.AddLog(General.ProcessType.EmployeeDependantAdd, General.TableName.EmployeeDependant, ID);
            return true;
        }

        public void DeleteEmployeeSalary(int ID)
        {
            dao.DeleteEmployeeSalary(ID);
            LogDAO.AddLog(General.ProcessType.EmployeeSalaryDelete, General.TableName.EmployeeSalary, ID);
        }

        public static IEnumerable<SelectListItem> GetPayGradeListForDropdown()
        {
            return (List<SelectListItem>)PayGradeDAO.GetPayGradeListForDropdown();
        }

        public List<EmployeeSalaryDTO> GetUpdateEmployeeSalaries()
        {
            return dao.GetUpdateEmployeeSalaries();
        }

        public EmployeeSalaryDTO UpdateEmployeeSalaryWithID(int ID)
        {
            return dao.UpdateEmployeeSalaryWithID(ID);
        }

        public bool UpdateEmployeeSalary(EmployeeSalaryDTO model)
        {
            dao.UpdateEmployeeSalary(model);
            LogDAO.AddLog(General.ProcessType.EmployeeSalaryUpdate, General.TableName.EmployeeSalary, model.ID);
            return true;
        }
    }
}
