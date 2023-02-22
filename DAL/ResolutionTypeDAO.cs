using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ResolutionTypeDAO : PostContext
    {
        public int AddResolutionType(ResolutionType rt)
        {
            try
            {
                db.ResolutionTypes.Add(rt);
                db.SaveChanges();
                return rt.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteResolutionType(int ID)
        {
            try
            {
                ResolutionType pc = db.ResolutionTypes.First(x => x.ID == ID);
                /*pc.isDeleted = true;
                 pc.DeletedDate = DateTime.Now;*/
                pc.LastUpdateDate = DateTime.Now;
                pc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResolutionTypeDTO UpdateResolutionTypeWithID(int ID)
        {
            try
            {
                ResolutionType rt = db.ResolutionTypes.First(x => x.ID == ID);
                ResolutionTypeDTO dto = new ResolutionTypeDTO();
                dto.ID = rt.ID;
                dto.ResolutionType = rt.ResolutionType1;
                dto.Description = rt.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateResolutionType(ResolutionTypeDTO model)
        {
            try
            {
                ResolutionType rt = db.ResolutionTypes.First(x => x.ID == model.ID);
                rt.ResolutionType1 = model.ResolutionType;
                rt.Description = model.Description;
                rt.LastUpdateDate = DateTime.Now;
                rt.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResolutionTypeDTO> GetResolutionTypes()
        {
            List<ResolutionType> list = db.ResolutionTypes.OrderBy(x => x.ResolutionType1).ToList();
            List<ResolutionTypeDTO> dtolist = new List<ResolutionTypeDTO>();
            foreach (var item in list)
            {
                ResolutionTypeDTO dto = new ResolutionTypeDTO();
                dto.ResolutionType = item.ResolutionType1;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }
    }
}
