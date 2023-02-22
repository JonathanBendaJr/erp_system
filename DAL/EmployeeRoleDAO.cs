using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRoleDAO : PostContext
    {
        public int AddEmployeeRole(EmpRole er)
        {
            try
            {
                db.EmpRoles.Add(er);
                db.SaveChanges();
                return er.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeRoleDTO> GetEmployeeRoles()
        {
            List<EmpRole> list = db.EmpRoles.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<EmployeeRoleDTO> dtolist = new List<EmployeeRoleDTO>();
            foreach (var item in list)
            {
                EmployeeRoleDTO dto = new EmployeeRoleDTO();
                dto.Role = item.Role;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public EmployeeRoleDTO UpdateEmployeeRoleWithID(int ID)
        {
            try
            {
                EmpRole er = db.EmpRoles.First(x => x.ID == ID);
                EmployeeRoleDTO dto = new EmployeeRoleDTO();
                dto.ID = er.ID;
                dto.Role = er.Role;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployeeRole(EmployeeRoleDTO model)
        {
            try
            {
                EmpRole er = db.EmpRoles.First(x => x.ID == model.ID);
                er.Role = model.Role;
                er.LastUpdateDate = DateTime.Now;
                er.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployeeRole(int ID)
        {
            try
            {
                EmpRole er = db.EmpRoles.First(x => x.ID == ID);
                er.isDeleted = true;
                er.DeletedDate = DateTime.Now;
                er.LastUpdateDate = DateTime.Now;
                er.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
