using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeEducationDAO : PostContext
    {
        public List<EmployeeEducationDTO> GetEmployeeEducations()
        {
            var employeeEducationList = (from edu in db.EmpEducations.Where(x => x.isDeleted == false)
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

        public EmployeeEducationDTO UpdateEmployeeDepartmentWithID(int ID)
        {
            EmpEducation edu = db.EmpEducations.First(x => x.ID == ID);
            EmployeeEducationDTO dto = new EmployeeEducationDTO();
            //var countyItem = new SelectList(db.Counties, "Id", "Name", emp.CountyAddressID);
            dto.ID = edu.ID;
            dto.hasCompleted = edu.HasCompleted;
            dto.SchoolAddress = edu.SchoolAddress;
            dto.SchoolName = edu.SchoolName;
            dto.SchoolCountry = edu.SchoolCountry;
            dto.DegreeTitle = edu.DegreeTitle;
            dto.DegreeTypeID = edu.DegreeTypeID;
            dto.StartDate = edu.StartDate;
            dto.EndDate = edu.EndDate;
            dto.EmployeeID = edu.EmployeeID;
            dto.DocumentPath = edu.DocumentPath;
            return dto;
        }

        public List<EmployeeEducationDTO> GetEmployeeEducationList(int empID)
        {
            var employeeEducationList = (from edu in db.EmpEducations.Where(x => x.isDeleted == false && x.EmployeeID == empID)
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

        public string UpdateEmployeeEducation(EmployeeEducationDTO model)
        {
            try
            {
                EmpEducation edu = db.EmpEducations.First(x => x.ID == model.ID);
                string oldImagePath = edu.DocumentPath;
                edu.SchoolName = model.SchoolName;
                edu.SchoolCountry = model.SchoolCountry;
                edu.SchoolAddress = model.SchoolAddress;
                edu.DegreeTitle = model.DegreeTitle;
                edu.DegreeTypeID = model.DegreeTypeID;
                edu.StartDate = model.StartDate;
                edu.EndDate = model.EndDate;
                edu.HasCompleted = model.hasCompleted;
                edu.EmployeeID = model.EmployeeID;
                if (model.DocumentPath != null)
                    edu.DocumentPath = model.DocumentPath;
                edu.LastUpdateDate = DateTime.Now;
                edu.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return oldImagePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AddEmployeeEducation(EmpEducation edu)
        {
            try
            {
                db.EmpEducations.Add(edu);
                db.SaveChanges();
                return edu.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployeeEducation(int ID)
        {
            try
            {
                EmpEducation edu = db.EmpEducations.First(x => x.ID == ID);
                edu.isDeleted = true;
                edu.DeletedDate = DateTime.Now;
                edu.LastUpdateDate = DateTime.Now;
                edu.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
