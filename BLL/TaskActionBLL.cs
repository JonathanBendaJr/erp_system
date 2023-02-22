using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaskActionBLL
    {
        TaskActionDAO dao = new TaskActionDAO();
        public bool AddTaskAction(TaskActionDTO model)
        {
            TaskAction task = new TaskAction();
            task.Action = model.Action;
            task.Description = model.Description;
            task.isDeleted = false;
            task.AddDate = DateTime.Now;
            task.LastUpdateDate = DateTime.Now;
            task.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddTaskAction(task);

            LogDAO.AddLog(General.ProcessType.TaskActionAdd, General.TableName.TaskAction, ID);
            return true;
        }

        
        public List<TaskActionDTO> GetTaskActions()
        {
            return dao.GetTaskActions();
        }

        public TaskActionDTO UpdateTaskActionWithID(int ID)
        {
            return dao.UpdateTaskActionWithID(ID);
        }

        public bool UpdateTaskAction(TaskActionDTO model)
        {
            dao.UpdateTaskAction(model);
            LogDAO.AddLog(General.ProcessType.TaskActionUpdate, General.TableName.TaskAction, model.ID);
            return true;
        }

        public void DeleteTaskAction(int ID)
        {
            dao.DeleteTaskAction(ID);
            LogDAO.AddLog(General.ProcessType.TaskActionDelete, General.TableName.TaskAction, ID);
        }
    }
}
