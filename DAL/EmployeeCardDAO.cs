using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeCardDAO : PostContext
    {
        public EmployeeSalaryDTO GetSalaryWithEmployeeID(int EmployeeID)
        {
            var salaryList = (from sal in db.EmpSalaryBenefits.Where(x => x.isDeleted == false && x.EmployeeID == EmployeeID)
                                    join pg in db.PayGrades on sal.PayGradeID equals pg.ID
                                    select new
                                    {
                                        ID = sal.ID,
                                        EmpID = sal.EmployeeID,
                                        BasicSalary = sal.BasicSalary,
                                        Allowance1 = sal.Allowance1,
                                        Allowance2 = sal.Allowance2,
                                        PayGrade = pg.PayGrade1,
                                    });
            EmployeeSalaryDTO dto = new EmployeeSalaryDTO();
            foreach (var item in salaryList)
            {
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.BasicSalary = Convert.ToDouble(item.BasicSalary);
                dto.Allowance2 = Convert.ToDouble(item.Allowance2);
                dto.Allowance1 = Convert.ToDouble(item.Allowance1);
            }
            return dto;
        }

        public List<EmployeeEducationDTO> GetEducationsWithEmployeeID(int EmployeeID)
        {
            var employeeEducationList = (from edu in db.EmpEducations.Where(x => x.isDeleted == false && x.EmployeeID == EmployeeID)
                                         join dg in db.DegreeCredentials on edu.DegreeTypeID equals dg.ID
                                         select new
                                         {
                                             ID = edu.ID,
                                             EmpID = edu.EmployeeID,
                                             DegreeTitle = edu.DegreeTitle,
                                             StartDate = edu.StartDate,
                                             EndDate = edu.EndDate,
                                             SchoolName = edu.SchoolName,
                                             SchoolAddress = edu.SchoolAddress,
                                             SchoolCountry = edu.SchoolCountry,
                                             HasCompleted = edu.HasCompleted,
                                             DocumentPath = edu.DocumentPath,
                                             DegreeType = dg.DegreeName,
                                             AddDate = edu.AddDate
                                         }).OrderByDescending(x => x.AddDate).ToList();
            //List<Employee> list = db.Employees.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            List<EmployeeEducationDTO> dtolist = new List<EmployeeEducationDTO>();
            foreach (var item in employeeEducationList)
            {
                EmployeeEducationDTO dto = new EmployeeEducationDTO();
                dto.ID = item.ID;
                dto.EmployeeID = item.EmpID;
                dto.DegreeTitle = item.DegreeTitle;
                dto.DegreeTypeName = item.DegreeType;
                dto.SchoolAddress = item.SchoolAddress;
                dto.SchoolName = item.SchoolName;
                dto.SchoolCountry = item.SchoolCountry;
                dto.hasCompleted = item.HasCompleted;
                dto.DocumentPath = item.DocumentPath;
                dto.StartDate = item.StartDate;
                dto.EndDate = item.EndDate;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public List<EmployeeWorkDTO> GetWorkWithEmployeeID(int EmployeeID)
        {
            List<WorkExperience> list = db.WorkExperiences.Where(x => x.isDeleted == false && x.EmployeeID == EmployeeID).OrderByDescending(x => x.AddDate).ToList();
            List<EmployeeWorkDTO> dtolist = new List<EmployeeWorkDTO>();
            foreach (var item in list)
            {
                EmployeeWorkDTO dto = new EmployeeWorkDTO();
                dto.PositionTitle = item.PositionTitle;
                dto.Responsibilities = item.Responsibilities;
                dto.StartDate = item.StartDate;
                dto.EndDate = item.EndDate;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }
        public List<EmployeeDependantDTO> GetDependantsWithEmployeeID(int EmployeeID)
        {
            var list = (from ed in db.EmpDependants.Where(x => x.isDeleted == false && x.EmployeeID == EmployeeID)
                                    join rl in db.Relationships on ed.RelationshipID equals rl.ID
                                    select new
                                    {
                                        ID = ed.ID,
                                        EmpID = ed.EmployeeID,
                                        FullName = ed.FullName,
                                        DateOfBirth = ed.DateOfBirth,
                                        Age = ed.Age,
                                        AddDate = ed.AddDate,
                                        Relationship = rl.Relationship1,
                                    }).OrderByDescending(x => x.AddDate).ToList();
            //List<EmpDependant> list = db.EmpDependants.Where(x => x.isDeleted == false && x.EmployeeID == id).ToList();
            List<EmployeeDependantDTO> dtolist = new List<EmployeeDependantDTO>();
            foreach (var item in list)
            {
                EmployeeDependantDTO dto = new EmployeeDependantDTO();
                dto.ID = item.ID;
                dto.EmployeeID = item.EmpID;
                dto.FullName = item.FullName;
                dto.DateOfBirth = item.DateOfBirth;
                dto.RelationshipName = item.Relationship;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public EmployeeDepartmentDTO GetDepartmentWithEmployeeID(int EmployeeID)
        {
            var employeeDepartmentList = (from edp in db.EmpDepManSupPositions.Where(x => x.isDeleted == false && x.EmployeeID == EmployeeID)
                                          join ps in db.Positions on edp.PositionID equals ps.ID
                                          join sp in db.Employees on edp.SupervisorRoleID equals sp.ID
                                          join mg in db.Employees on edp.ManagerRoleID equals mg.ID
                                          join dp in db.Departments on edp.DepartmentID equals dp.ID
                                          select new
                                          {
                                              ID = edp.ID,
                                              EmpID = edp.EmployeeID,
                                              ManagerRole = mg.FName + " "+ mg.LName,
                                              SupervisorRole = sp.FName + " " + sp.LName,
                                              Department = dp.DepartmentName,
                                              PositionName = ps.PositionName,
                                              AddDate = edp.AddDate
                                          }).OrderByDescending(x => x.AddDate);
            EmployeeDepartmentDTO dto = new EmployeeDepartmentDTO();
            foreach (var item in employeeDepartmentList)
            {
      
                dto.ID = item.ID;
                dto.EmployeeID = item.EmpID;
                dto.PositionName = item.PositionName;
                dto.ManagerRoleTitle = item.ManagerRole;
                dto.SupervisorRoleTitle = item.SupervisorRole;
                dto.DepartmentName = item.Department;
            }
            return dto;
        }

        public EmployeeDTO GetEmployeeWithEmployeeID(int ID)
        {

            var employeeList = (from emp in db.Employees.Where(x => x.isDeleted == false && x.ID == ID)
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
                                    PositionName = ps.PositionName,
                                    EmpStatus = st.Status1,
                                    Marital = mst.MaritalStatus
                                }).OrderByDescending(x => x.AddDate);
            //List<Employee> list = db.Employees.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            EmployeeDTO dto = new EmployeeDTO();
            foreach (var item in employeeList)
            {
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
            }
            return dto;
        }
    }
}
