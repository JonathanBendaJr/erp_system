using DTO;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class EmployeeDAO : PostContext
    {
        public List<EmployeeDTO> GetEmployees()
        {
            var employeeList = (from emp in db.Employees.Where(x => x.isDeleted == false)
                                join co in db.Counties on emp.CountyAddressID equals co.ID
                                join cty in db.Counties on emp.CountyOfOriginID equals cty.ID
                                join gd in db.Genders on emp.GenderID equals gd.ID
                                join ps in db.Positions on emp.PositionID equals ps.ID
                                join st in db.Status on emp.StatusID equals st.ID
                                join mst in db.MaritalStatus on emp.MaritalStatusID equals mst.ID
                                select new
                                {
                                    ID = emp.ID,
                                    FName = emp.FName,
                                    LName = emp.LName,
                                    Email = emp.Email,
                                    Phone1 = emp.Phone1,
                                    Phone2 = emp.Phone2,
                                    Address = emp.Address,
                                    City = emp.City,
                                    DateOfBirth = emp.DateOfBirth,
                                    PlaceOfBirth = emp.PlaceOfBirth,
                                    ImagePath = emp.ImagePath,
                                    Age = emp.Age,
                                    AddDate = emp.AddDate,
                                    AddressCounty = co.CountyName,
                                    BirthCounty = cty.CountyName,
                                    Gender = gd.Gender1,
                                    PositionName =  ps.PositionName,
                                    EmpStatus = st.Status1,
                                    Marital = mst.MaritalStatus
                                }).OrderByDescending(x => x.AddDate).ToList();
            //List<Employee> list = db.Employees.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            List<EmployeeDTO> dtolist = new List<EmployeeDTO>();
            foreach (var item in employeeList)
            {
                EmployeeDTO dto = new EmployeeDTO();
                dto.ID = item.ID;
                dto.FName = item.FName;
                dto.LName = item.LName;
                dto.Email = item.Email;
                dto.Phone1 = item.Phone1;
                dto.Phone2 = item.Phone2;
                dto.Address = item.Address;
                dto.City = item.City;
                dto.CountyAddressName = item.AddressCounty;
                dto.ImagePath = item.ImagePath;
                dto.CountyOfOriginName = item.BirthCounty;
                dto.PlaceOfBirth = item.PlaceOfBirth;
                dto.DateOfBirth = item.DateOfBirth;
                dto.Age = item.Age;
                dto.GenderName = item.Gender;
                dto.StatusName = item.EmpStatus;
                dto.PositionName = item.PositionName;
                dto.MaritalStatusName = item.Marital;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static EmployeeDTO GetEmployeeDetail(int id)
        {
            Employee emp = db.Employees.First(x => x.ID == id);
            EmployeeDTO dto = new EmployeeDTO();
            //var countyItem = new SelectList(db.Counties, "Id", "Name", emp.CountyAddressID);
            dto.ID = emp.ID;
            dto.FName = emp.FName;
            dto.LName = emp.LName;
            dto.Email = emp.Email;
            return dto;
        }

        public static EmployeeDTO GetEmployeeWithID(int employeeID)
        {
            Employee emp = db.Employees.First(x => x.ID == employeeID);
            EmployeeDTO dto = new EmployeeDTO();
            //var countyItem = new SelectList(db.Counties, "Id", "Name", emp.CountyAddressID);
            dto.ID = emp.ID;
            dto.FName = emp.FName;
            dto.LName = emp.LName;
            dto.Email = emp.Email;
            dto.Phone1 = emp.Phone1;
            dto.Phone2 = emp.Phone2;
            dto.Address = emp.Address;
            dto.City = emp.City;
            dto.CountyAddressID = emp.CountyAddressID;
            dto.CountyOfOriginID = emp.CountyOfOriginID;
            dto.PlaceOfBirth = emp.PlaceOfBirth;
            dto.DateOfBirth = emp.DateOfBirth;
            dto.Age = emp.Age;
            dto.GenderID = emp.GenderID;
            dto.StatusID = emp.StatusID;
            dto.PositionID = emp.PositionID;
            dto.MaritalStatusID = emp.MaritalStatusID;
            dto.ImagePath = emp.ImagePath;
            return dto;
        }

        public EmployeeDTO GetEmployeeFullName(int empID)
        {
            Employee emp = db.Employees.First(x => x.ID == empID);
            EmployeeDTO dto = new EmployeeDTO();
            dto.ID = emp.ID;
            dto.FName = emp.FName;
            dto.LName = emp.LName;
            return dto;
        }

        public static IEnumerable<SelectListItem> GetEmployeesForDropdown()
        {
            IEnumerable<SelectListItem> allEmployees = db.Employees.Where(x => x.isDeleted == false).OrderBy(x => x.LName).Select(x => new SelectListItem()
            {
                Text = x.FName + " " + x.LName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return allEmployees;

            /*IEnumerable<SelectListItem> allEmployees = (from emp in db.Employees
                                                        where emp.isDeleted == false
                                                        orderby emp.LName
                                                        select new SelectListItem
                                                        {
                                                            Value = emp.ID.ToString(),
                                                            Text = emp.LName + " " + emp.FName
                                                        }).ToList();

            return allEmployees;*/
        }


        public static IEnumerable<SelectListItem> GetEmployeeListForDropdown()
        {
            IEnumerable<SelectListItem> employeeList = (from emp in db.Employees
                                                          where emp.isDeleted == false && emp.Position.isSupervisory == true
                                                          orderby emp.LName
                                                          select new SelectListItem
                                                          {
                                                              Value = emp.ID.ToString(),
                                                              Text = emp.LName + " " + emp.FName
                                                          }).ToList();

            return employeeList;
        }

        public static IEnumerable<SelectListItem> GetSupervisorListForDropdown()
        {
            IEnumerable<SelectListItem> supervisorList = (from emp in db.Employees
                                                       where emp.isDeleted == false && emp.Position.isSupervisory == true
                                                       orderby emp.LName
                                                       select new SelectListItem
                                                       {
                                                           Value = SqlFunctions.StringConvert((double)emp.ID),
                                                           Text = emp.LName + " " + emp.FName
                                                       }).ToList();

            return supervisorList;

        }

        public static IEnumerable<SelectListItem> GetManagerListForDropdown()
        {
            //var employeeID = 
            IEnumerable<SelectListItem> managerList = (from empl in db.Employees
                                                       where empl.isDeleted == false && empl.Position.isManagerial == true || empl.Position.isTopManagement
                                                       orderby empl.LName
                                                       select new SelectListItem
                                                       {
                                                           Value = SqlFunctions.StringConvert((double)empl.ID),
                                                           Text = empl.LName + " " + empl.FName 
                                                       }).ToList();

            return managerList;
        }

        public EmployeeDTO UpdateEmployeeWithID(int ID)
        {
            Employee emp = db.Employees.First(x => x.ID == ID);
            EmployeeDTO dto = new EmployeeDTO();
            //var countyItem = new SelectList(db.Counties, "Id", "Name", emp.CountyAddressID);
            dto.ID = emp.ID;
            dto.FName = emp.FName;
            dto.LName = emp.LName;
            dto.Email = emp.Email;
            dto.Phone1 = emp.Phone1;
            dto.Phone2 = emp.Phone2;
            dto.Address = emp.Address;
            dto.City = emp.City;
            dto.CountyAddressID = emp.CountyAddressID;
            dto.CountyOfOriginID = emp.CountyOfOriginID;
            dto.PlaceOfBirth = emp.PlaceOfBirth;
            dto.DateOfBirth = emp.DateOfBirth;
            dto.Age = emp.Age;
            dto.GenderID = emp.GenderID;
            dto.StatusID = emp.StatusID;
            dto.PositionID = emp.PositionID;
            dto.MaritalStatusID = emp.MaritalStatusID;
            dto.ImagePath = emp.ImagePath;
            return dto;
        }

        public int AddEmployee(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return emp.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateEmployee(EmployeeDTO model)
        {
            try
            {
                Employee emp = db.Employees.First(x => x.ID == model.ID);
                string oldImagePath = emp.ImagePath;
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
                if (model.ImagePath != null)
                    emp.ImagePath = model.ImagePath;
                emp.LastUpdateDate = DateTime.Now;
                emp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return oldImagePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployee(int ID)
        {
            try
            {
                Employee emp = db.Employees.First(x => x.ID == ID);
                emp.isDeleted = true;
                emp.DeletedDate = DateTime.Now;
                emp.LastUpdateDate = DateTime.Now;
                emp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
