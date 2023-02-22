using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaskActionDAO : PostContext
    {
        public int AddTaskAction(TaskAction task)
        {
            try
            {
                db.TaskActions.Add(task);
                db.SaveChanges();
                return task.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TaskActionDTO> GetTaskActions()
        {
            List<TaskAction> list = db.TaskActions.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<TaskActionDTO> dtolist = new List<TaskActionDTO>();
            foreach (var item in list)
            {
                TaskActionDTO dto = new TaskActionDTO();
                dto.Action = item.Action;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public TaskActionDTO UpdateTaskActionWithID(int ID)
        {
            try
            {
                TaskAction task = db.TaskActions.First(x => x.ID == ID);
                TaskActionDTO dto = new TaskActionDTO();
                dto.ID = task.ID;
                dto.Action = task.Action;
                dto.Description = task.Description;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTaskAction(int ID)
        {
            try
            {
                TaskAction task = db.TaskActions.First(x => x.ID == ID);
                task.isDeleted = true;
                task.DeletedDate = DateTime.Now;
                task.LastUpdateDate = DateTime.Now;
                task.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateTaskAction(TaskActionDTO model)
        {
            try
            {
                TaskAction task = db.TaskActions.First(x => x.ID == model.ID);
                task.Action = model.Action;
                task.Description = model.Description;
                task.LastUpdateDate = DateTime.Now;
                task.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
