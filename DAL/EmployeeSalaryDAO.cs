using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeSalaryDAO : PostContext
    {
        public void DeleteEmployeeSalary(int ID)
        {
            try
            {
                EmpSalaryBenefit sal = db.EmpSalaryBenefits.First(x => x.ID == ID);
                sal.isDeleted = true;
                sal.DeletedDate = DateTime.Now;
                sal.LastUpdateDate = DateTime.Now;
                sal.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployeeSalary(EmployeeSalaryDTO model)
        {
            try
            {
                EmpSalaryBenefit sal = db.EmpSalaryBenefits.First(x => x.ID == model.ID);
                sal.BasicSalary = Convert.ToDecimal(model.BasicSalary);
                sal.Allowance1 = Convert.ToDecimal(model.Allowance1);
                sal.Allowance2 = Convert.ToDecimal(model.Allowance2);
                sal.GrossSalary = sal.BasicSalary + sal.Allowance1 + sal.Allowance2;
                sal.PayGradeID = model.PayGradeID;
                sal.LastUpdateDate = DateTime.Now;
                sal.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeSalaryDTO UpdateEmployeeSalaryWithID(int ID)
        {
            try
            {
                EmpSalaryBenefit sal = db.EmpSalaryBenefits.First(x => x.ID == ID);
                EmployeeSalaryDTO dto = new EmployeeSalaryDTO();
                dto.ID = sal.ID;
                dto.EmployeeID = sal.EmployeeID;
                dto.BasicSalary = Convert.ToDouble(sal.BasicSalary);
                dto.Allowance1 = Convert.ToDouble(sal.Allowance1);
                dto.Allowance2 = Convert.ToDouble(sal.Allowance2);
                dto.GrossSalary = Convert.ToDouble(sal.GrossSalary);
                dto.GrossSalary = Convert.ToDouble(sal.GrossSalary);
                dto.PayGradeID = sal.PayGradeID;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeSalaryDTO> GetUpdateEmployeeSalaries()
        {
            var empEducationList = (from edu in db.EmpSalaryBenefits.Where(x => x.isDeleted == false)
                                    join pg in db.PayGrades on edu.PayGradeID equals pg.ID
                                    select new
                                    {
                                        ID = edu.ID,
                                        EmpID = edu.EmployeeID,
                                        BasicSalary = edu.BasicSalary,
                                        Allowance1 = edu.Allowance1,
                                        Allowance2 = edu.Allowance2,
                                        GrossSalary = edu.GrossSalary,
                                        AddDate = edu.AddDate,
                                        PayGrade = pg.PayGrade1,
                                    }).OrderByDescending(x => x.AddDate).ToList();
            List<EmployeeSalaryDTO> dtolist = new List<EmployeeSalaryDTO>();
            foreach (var item in empEducationList)
            {
                EmployeeSalaryDTO dto = new EmployeeSalaryDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.BasicSalary = Convert.ToDouble(item.BasicSalary);
                dto.Allowance1 = Convert.ToDouble(item.Allowance1);
                dto.Allowance2 = Convert.ToDouble(item.Allowance2);
                dto.GrossSalary = Convert.ToDouble(item.GrossSalary);
                dto.PayGradeName = item.PayGrade;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public int AddEmployeeSalary(EmpSalaryBenefit sal)
        {
            try
            {
                db.EmpSalaryBenefits.Add(sal);
                db.SaveChanges();
                return sal.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
