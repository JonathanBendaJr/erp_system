using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaskRatingDAO : PostContext
    {
        public void DeleteTaskRating(int ID)
        {
            try
            {
                TaskRating tr = db.TaskRatings.First(x => x.ID == ID);
                tr.isDeleted = true;
                tr.DeletedDate = DateTime.Now;
                tr.LastUpdateDate = DateTime.Now;
                tr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTaskRating(TaskRatingDTO model)
        {
            try
            {
                TaskRating tr = db.TaskRatings.First(x => x.ID == model.ID);
                tr.Ratings = model.Rating;
                tr.LastUpdateDate = DateTime.Now;
                tr.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TaskRatingDTO> GetTaskRatings()
        {
            List<TaskRating> list = db.TaskRatings.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<TaskRatingDTO> dtolist = new List<TaskRatingDTO>();
            foreach (var item in list)
            {
                TaskRatingDTO dto = new TaskRatingDTO();
                dto.Rating = item.Ratings;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public int AddTaskRating(TaskRating tr)
        {
            try
            {
                db.TaskRatings.Add(tr);
                db.SaveChanges();
                return tr.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TaskRatingDTO UpdateTaskRatingWithID(int ID)
        {
            try
            {
                TaskRating tr = db.TaskRatings.First(x => x.ID == ID);
                TaskRatingDTO dto = new TaskRatingDTO();
                dto.ID = tr.ID;
                dto.Rating = tr.Ratings;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
