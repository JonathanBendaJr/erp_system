using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaskRatingBLL
    {
        TaskRatingDAO dao = new TaskRatingDAO();
        public bool AddTaskRating(TaskRatingDTO model)
        {
            TaskRating tr = new TaskRating();
            tr.Ratings = model.Rating;
            tr.AddDate = DateTime.Now;
            tr.LastUpdateDate = DateTime.Now;
            tr.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddTaskRating(tr);

            LogDAO.AddLog(General.ProcessType.TaskRatingAdd, General.TableName.TaskRatings, ID);
            return true;
        }

        public TaskRatingDTO UpdateTaskRatingWithID(int ID)
        {
            return dao.UpdateTaskRatingWithID(ID);
        }

        public bool UpdateTaskRating(TaskRatingDTO model)
        {
            dao.UpdateTaskRating(model);
            LogDAO.AddLog(General.ProcessType.TaskRatingUpdate, General.TableName.TaskRatings, model.ID);
            return true;
        }

        public void DeleteTaskRating(int ID)
        {
            dao.DeleteTaskRating(ID);
            LogDAO.AddLog(General.ProcessType.TaskRatingDelete, General.TableName.TaskRatings, ID);
        }

        public List<TaskRatingDTO> GetTaskRatings()
        {
            return dao.GetTaskRatings();
        }
    }
}
