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
    public class EmployeeEducationBLL
    {
        EmployeeEducationDAO dao = new EmployeeEducationDAO();
        public void DeleteEmployeeEducation(int ID)
        {
            dao.DeleteEmployeeEducation(ID);
            LogDAO.AddLog(General.ProcessType.EmployeeEducationDelete, General.TableName.EmployeeEducation, ID);
        }

        public string UpdateEmployeeEducation(EmployeeEducationDTO model)
        {
            string oldImagePath = dao.UpdateEmployeeEducation(model);
            LogDAO.AddLog(General.ProcessType.EmployeeEducationUpdate, General.TableName.EmployeeEducation, model.ID);
            return oldImagePath;
        }

        public static IEnumerable<SelectListItem> GetDegreeTypeListForDropdown()
        {
            return (List<SelectListItem>)DegreeDAO.GetDegreeTypeListForDropdown();
        }

        public EmployeeEducationDTO UpdateEmployeeDepartmentWithID(int ID)
        {
            return dao.UpdateEmployeeDepartmentWithID(ID);
        }

        public List<EmployeeEducationDTO> GetEmployeeEducations()
        {
            return dao.GetEmployeeEducations();
        }

        public void AddEmployeeEducation(EmployeeEducationDTO model)
        {
            EmpEducation edu = new EmpEducation();
            edu.EmployeeID = model.EmployeeID;
            edu.SchoolName = model.SchoolName;
            edu.SchoolAddress = model.SchoolAddress;
            edu.SchoolCountry = model.SchoolCountry;
            edu.DegreeTitle = model.DegreeTitle;
            edu.DocumentPath = model.DocumentPath;
            edu.StartDate = model.StartDate;
            edu.EndDate = model.EndDate;
            edu.HasCompleted = model.hasCompleted;
            edu.DegreeTypeID = model.DegreeTypeID;
            edu.AddDate = DateTime.Now;
            edu.LastUpdateDate = DateTime.Now;
            edu.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeEducation(edu);

            LogDAO.AddLog(General.ProcessType.EmployeeEducationAdd, General.TableName.EmployeeEducation, ID);
        }

        public static IEnumerable<SelectListItem> GetEmployeeListForDropdown()
        {
            return (List<SelectListItem>)EmployeeDAO.GetEmployeeListForDropdown();
        }

        public List<EmployeeEducationDTO> GetEmployeeEducationList(int empID)
        {
            return dao.GetEmployeeEducationList(empID);
        }
    }
}
