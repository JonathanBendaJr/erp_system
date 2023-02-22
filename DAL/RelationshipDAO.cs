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
    public class RelationshipDAO : PostContext
    {
        public int AddRelationship(Relationship rela)
        {
            try
            {
                db.Relationships.Add(rela);
                db.SaveChanges();
                return rela.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetRelationshipListForDropdown()
        {
            IEnumerable<SelectListItem> relationshipList = db.Relationships.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.Relationship1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return relationshipList;
        }

        public List<RelationshipDTO> GetRelationships()
        {
            List<Relationship> list = db.Relationships.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<RelationshipDTO> dtolist = new List<RelationshipDTO>();
            foreach (var item in list)
            {
                RelationshipDTO dto = new RelationshipDTO();
                dto.Relationship = item.Relationship1;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public RelationshipDTO UpdateRelationshipWithID(int ID)
        {
            try
            {
                Relationship rela = db.Relationships.First(x => x.ID == ID);
                RelationshipDTO dto = new RelationshipDTO();
                dto.ID = rela.ID;
                dto.Relationship = rela.Relationship1;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateRelationship(RelationshipDTO model)
        {
            try
            {
                Relationship rela = db.Relationships.First(x => x.ID == model.ID);
                rela.Relationship1 = model.Relationship;
                rela.LastUpdateDate = DateTime.Now;
                rela.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteRelationship(int ID)
        {
            try
            {
                Relationship rela = db.Relationships.First(x => x.ID == ID);
                rela.isDeleted = true;
                rela.DeletedDate = DateTime.Now;
                rela.LastUpdateDate = DateTime.Now;
                rela.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
