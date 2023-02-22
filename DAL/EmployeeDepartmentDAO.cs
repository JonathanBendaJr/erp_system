using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDepartmentDAO : PostContext
    {
        public void DeleteEmployeeDepartment(int ID)
        {
            try
            {
                EmpDepManSupPosition edp = db.EmpDepManSupPositions.First(x => x.ID == ID);
                edp.isDeleted = true;
                edp.DeletedDate = DateTime.Now;
                edp.LastUpdateDate = DateTime.Now;
                edp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int GetDepartmentByEmployeeID(int employeeID)
        {
            EmpDepManSupPosition edp = db.EmpDepManSupPositions.First(x => x.EmployeeID == employeeID);
            return edp.DepartmentID;
        }

        internal static int GetDepartmentByEmployeeID(int? employeeID)
        {
            EmpDepManSupPosition edp = db.EmpDepManSupPositions.First(x => x.EmployeeID == employeeID);
            return edp.DepartmentID;
        }

        internal static int UserDepartmentID(int? employeeID)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeeDepartment(EmployeeDepartmentDTO model)
        {
            try
            {
                EmpDepManSupPosition edp = db.EmpDepManSupPositions.First(x => x.ID == model.ID);
                edp.PositionID = model.PositionID;
                edp.DepartmentID = model.DepartmentID;
                edp.ManagerRoleID = model.ManagerRoleID;
                edp.SupervisorRoleID = model.SupervisorRoleID;
                edp.LastUpdateDate = DateTime.Now;
                edp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeDepartmentDTO UpdateEmployeeDepartmentWithID(int ID)
        {
            try
            {
                EmpDepManSupPosition edp = db.EmpDepManSupPositions.First(x => x.ID == ID);
                EmployeeDepartmentDTO dto = new EmployeeDepartmentDTO();
                dto.ID = edp.ID;
                dto.EmployeeID = edp.EmployeeID;
                dto.PositionID = edp.PositionID;
                dto.ManagerRoleID = edp.ManagerRoleID;
                dto.SupervisorRoleID = edp.SupervisorRoleID;
                dto.DepartmentID = edp.DepartmentID;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeDepartmentDTO> GetEmployeeDepartments()
        {
            var employeeDepartmentList = (from edp in db.EmpDepManSupPositions.Where(x => x.isDeleted == false)
                                          join ps in db.Positions on edp.PositionID equals ps.ID
                                          join sp in db.Employees on edp.SupervisorRoleID equals sp.ID
                                          join mg in db.Employees on edp.ManagerRoleID equals mg.ID
                                          join dp in db.Departments on edp.DepartmentID equals dp.ID
                                          select new
                                          {
                                              ID = edp.ID,
                                              EmpID=edp.EmployeeID,
                                              ManagerRole = mg.FName + " "+ mg.LName,
                                              SupervisorRole = sp.FName + " " + sp.LName,
                                              Department = dp.DepartmentName,
                                              PositionName = ps.PositionName,
                                              AddDate = edp.AddDate
                                          }).OrderByDescending(x => x.AddDate).ToList();
            List<EmployeeDepartmentDTO> dtolist = new List<EmployeeDepartmentDTO>();
            foreach (var item in employeeDepartmentList)
            {
                EmployeeDepartmentDTO dto = new EmployeeDepartmentDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.PositionName = item.SupervisorRole;
                dto.SupervisorRoleTitle = item.PositionName;
                dto.ManagerRoleTitle = item.ManagerRole;
                dto.DepartmentName = item.Department;
                dto.PositionName = item.PositionName;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public int AddEmployeeDepartment(EmpDepManSupPosition edp)
        {
            try
            {
                db.EmpDepManSupPositions.Add(edp);
                db.SaveChanges();
                return edp.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
