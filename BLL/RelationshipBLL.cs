using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RelationshipBLL
    {
        RelationshipDAO dao = new RelationshipDAO();
        public bool AddRelationship(RelationshipDTO model)
        {
            Relationship rela = new Relationship();
            rela.Relationship1 = model.Relationship;
            rela.AddDate = DateTime.Now;
            rela.LastUpdateDate = DateTime.Now;
            rela.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddRelationship(rela);

            LogDAO.AddLog(General.ProcessType.RelationshipAdd, General.TableName.Relationship, ID);
            return true;
        }

        public List<RelationshipDTO> GetRelationships()
        {
            return dao.GetRelationships();
        }

        public RelationshipDTO UpdateRelationshipWithID(int ID)
        {
            return dao.UpdateRelationshipWithID(ID);
        }

        public bool UpdateRelationship(RelationshipDTO model)
        {
            dao.UpdateRelationship(model);
            LogDAO.AddLog(General.ProcessType.RelationshipUpdate, General.TableName.Relationship, model.ID);
            return true;
        }

        public void DeleteRelationship(int ID)
        {
            dao.DeleteRelationship(ID);
            LogDAO.AddLog(General.ProcessType.RelationshipDelete, General.TableName.Relationship, ID);
        }
    }
}
