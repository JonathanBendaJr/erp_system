using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDependantDAO : PostContext
    {
        public int AddEmployeeDependant(EmpDependant ed)
        {
            try
            {
                db.EmpDependants.Add(ed);
                db.SaveChanges();
                return ed.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployeeDependant(int ID)
        {
            try
            {
                EmpDependant ed = db.EmpDependants.First(x => x.ID == ID);
                ed.isDeleted = true;
                ed.DeletedDate = DateTime.Now;
                ed.LastUpdateDate = DateTime.Now;
                ed.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployeeDependant(EmployeeDependantDTO model)
        {
            try
            {
                EmpDependant ed = db.EmpDependants.First(x => x.ID == model.ID);
                ed.FullName = model.FullName;
                ed.Age = model.Age;
                ed.DateOfBirth = model.DateOfBirth;
                ed.RelationshipID = model.RelationshipID;
                ed.LastUpdateDate = DateTime.Now;
                ed.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeDependantDTO UpdateEmployeeDependantWithID(int ID)
        {
            try
            {
                EmpDependant ed = db.EmpDependants.First(x => x.ID == ID);
                EmployeeDependantDTO dto = new EmployeeDependantDTO();
                dto.ID = ed.ID;
                dto.Age = ed.Age;
                dto.FullName = ed.FullName;
                dto.DateOfBirth = ed.DateOfBirth;
                dto.EmployeeID = ed.EmployeeID;
                dto.RelationshipID = ed.RelationshipID;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeDependantDTO> GetEmployeeDependants()
        {
            var empDependantList = (from ed in db.EmpDependants.Where(x => x.isDeleted == false)
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
            List<EmployeeDependantDTO> dtolist = new List<EmployeeDependantDTO>();
            foreach (var item in empDependantList)
            {
                EmployeeDependantDTO dto = new EmployeeDependantDTO();
                dto.EmployeeID = item.EmpID;
                dto.ID = item.ID;
                dto.FullName = item.FullName;
                dto.DateOfBirth = item.DateOfBirth;
                dto.Age = item.Age;
                dto.RelationshipName = item.Relationship;
                dtolist.Add(dto);
            }
            return dtolist;
        }
    }
}
