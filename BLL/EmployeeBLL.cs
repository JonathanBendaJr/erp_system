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
    public class EmployeeBLL
    {
        EmployeeDAO dao = new EmployeeDAO();
        public static IEnumerable<SelectListItem> GetCountiesForDropdown()
        {
            return (List<SelectListItem>)CountyDAO.GetCountiesForDropdown();
        }

        public static IEnumerable<SelectListItem> GetGendersForDropdown()
        {
            return (List<SelectListItem>)GenderDAO.GetGendersForDropdown();
        }

        public static IEnumerable<SelectListItem> GetStatusesForDropdown()
        {
            return (List<SelectListItem>)StatusDAO.GetStatusesForDropdown();
        }

        public static IEnumerable<SelectListItem> GetPositionListForDropdown()
        {
            return (List<SelectListItem>)PositionDAO.GetPositionListForDropdown();
        }

        public static IEnumerable<SelectListItem> GetMaritalStatusesForDropdown()
        {
            return (List<SelectListItem>)MaritalStatusDAO.GetMaritalStatusesForDropdown();
        }

        public static EmployeeDTO GetEmployeeWithID(int employeeID)
        {
            return EmployeeDAO.GetEmployeeWithID(employeeID);
        }

        public EmployeeDTO UpdateEmployeeWithID(int ID)
        {
            return dao.UpdateEmployeeWithID(ID);
        }

        public void AddEmployee(EmployeeDTO model)
        {
            Employee emp = new Employee();
            emp.FName = model.FName;
            emp.LName = model.LName;
            emp.Email = model.Email;
            emp.Phone1 = model.Phone1; 
            emp.Phone2 = model.Phone2; 
            emp.Address = model.Address;
            emp.City = model.City;
            emp.CountyAddressID = model.CountyAddressID;
            emp.ImagePath = model.ImagePath;
            emp.CountyOfOriginID = model.CountyOfOriginID;
            emp.PlaceOfBirth = model.PlaceOfBirth;
            emp.DateOfBirth = model.DateOfBirth;
            emp.Age = model.Age;
            emp.GenderID = model.GenderID;
            emp.StatusID = model.StatusID;
            emp.PositionID = model.PositionID;
            emp.MaritalStatusID = model.MaritalStatusID;      
            emp.AddDate = DateTime.Now;
            emp.LastUpdateDate = DateTime.Now;
            emp.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployee(emp);

            LogDAO.AddLog(General.ProcessType.EmployeeAdd, General.TableName.Employee, ID);
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return dao.GetEmployees();
        }

        public string UpdateEmployee(EmployeeDTO model)
        {
            string oldImagePath = dao.UpdateEmployee(model);
            LogDAO.AddLog(General.ProcessType.EmployeeUpdate, General.TableName.Employee, model.ID);
            return oldImagePath;
        }

        public void DeleteEmployee(int ID)
        {
            dao.DeleteEmployee(ID);
            LogDAO.AddLog(General.ProcessType.EmployeeDelete, General.TableName.Employee, ID);
        }
    }
}
