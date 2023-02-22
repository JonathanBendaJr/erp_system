using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeWorkDAO : PostContext
    {
        public int AddEmployeeWork(WorkExperience work)
        {
            try
            {
                db.WorkExperiences.Add(work);
                db.SaveChanges();
                return work.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployeeWork(int ID)
        {
            try
            {
                WorkExperience work = db.WorkExperiences.First(x => x.ID == ID);
                work.isDeleted = true;
                work.DeletedDate = DateTime.Now;
                work.LastUpdateDate = DateTime.Now;
                work.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmployeeWorkDTO> GetEmployeeWorks()
        {
            List<WorkExperience> list = db.WorkExperiences.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
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

        public void UpdateEmployeeWork(EmployeeWorkDTO model)
        {
            try
            {
                WorkExperience work = db.WorkExperiences.First(x => x.ID == model.ID);
                work.PositionTitle = model.PositionTitle;
                work.Responsibilities = model.Responsibilities;
                work.StartDate = model.StartDate;
                work.EndDate = model.EndDate;
                work.LastUpdateDate = DateTime.Now;
                work.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeWorkDTO UpdateEmployeeWorkWithID(int ID)
        {
            try
            {
                WorkExperience work = db.WorkExperiences.First(x => x.ID == ID);
                EmployeeWorkDTO dto = new EmployeeWorkDTO();
                dto.ID = work.ID;
                dto.PositionTitle = work.PositionTitle;
                dto.Responsibilities = work.Responsibilities;
                dto.StartDate = work.StartDate;
                dto.EndDate = work.EndDate;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
