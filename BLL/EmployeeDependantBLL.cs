using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class EmployeeDependantBLL
    {
        EmployeeDependantDAO dao = new EmployeeDependantDAO();
        public static IEnumerable<SelectListItem> GetRelationshipListForDropdown()
        {
            return (List<SelectListItem>)RelationshipDAO.GetRelationshipListForDropdown();
        }

        public void DeleteEmployeeDependant(int ID)
        {
            dao.DeleteEmployeeDependant(ID);
            LogDAO.AddLog(General.ProcessType.EmployeeDependantDelete, General.TableName.EmployeeDependant, ID);
        }

        public bool UpdateEmployeeDependant(EmployeeDependantDTO model)
        {
            dao.UpdateEmployeeDependant(model);
            LogDAO.AddLog(General.ProcessType.EmployeeDependantUpdate, General.TableName.EmployeeDependant, model.ID);
            return true;
        }

        public EmployeeDependantDTO UpdateEmployeeDependantWithID(int ID)
        {
            return dao.UpdateEmployeeDependantWithID(ID);
        }

        public List<EmployeeDependantDTO> GetEmployeeDependants()
        {
            return dao.GetEmployeeDependants();
        }

        public bool AddEmployeeDependant(EmployeeDependantDTO model)
        {
            EmpDependant ed = new EmpDependant();
            ed.EmployeeID = model.EmployeeID;
            ed.FullName = model.FullName;
            ed.RelationshipID = model.RelationshipID;
            ed.DateOfBirth = model.DateOfBirth;
            ed.Age = model.Age;
            ed.AddDate = DateTime.Now;
            ed.LastUpdateDate = DateTime.Now;
            ed.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddEmployeeDependant(ed);

            LogDAO.AddLog(General.ProcessType.EmployeeDependantAdd, General.TableName.EmployeeDependant, ID);
            return true;
        }
    }
}
