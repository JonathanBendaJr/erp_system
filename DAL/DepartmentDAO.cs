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
    public class DepartmentDAO : PostContext
    {
        public int AddDepartment(Department dp)
        {
            try
            {
                db.Departments.Add(dp);
                db.SaveChanges();
                return dp.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        public List<DepartmentDTO> GetDepartments()
        {
            List<Department> list = db.Departments.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<DepartmentDTO> dtolist = new List<DepartmentDTO>();
            foreach (var item in list)
            {
                DepartmentDTO dto = new DepartmentDTO();
                dto.DepartmentName = item.DepartmentName;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

      

        public DepartmentDTO UpdateDepartmentWithID(int ID)
        {
            try
            {
                Department dp = db.Departments.First(x => x.ID == ID);
                DepartmentDTO dto = new DepartmentDTO();
                dto.ID = dp.ID;
                dto.DepartmentName = dp.DepartmentName;
                dto.Description = dp.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateDepartment(DepartmentDTO model)
        {
            try
            {
                Department dp = db.Departments.First(x => x.ID == model.ID);
                dp.DepartmentName = model.DepartmentName;
                dp.Description = model.Description;
                dp.LastUpdateDate = DateTime.Now;
                dp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static IEnumerable<SelectListItem> GetDepartmentListForDropdown()
        {
            IEnumerable<SelectListItem> departmentList = db.Departments.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.DepartmentName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return departmentList;
        }

        public void DeleteDepartment(int ID)
        {
            try
            {
                Department dp = db.Departments.First(x => x.ID == ID);
                dp.isDeleted = true;
                dp.DeletedDate = DateTime.Now;
                dp.LastUpdateDate = DateTime.Now;
                dp.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
