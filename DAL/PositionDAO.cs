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
    public class PositionDAO : PostContext
    {
        public int AddPosition(Position po)
        {
            try
            {
                db.Positions.Add(po);
                db.SaveChanges();
                return po.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PositionDTO> GetPositions()
        {
            List<Position> list = db.Positions.Where(x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<PositionDTO> dtolist = new List<PositionDTO>();
            foreach (var item in list)
            {
                PositionDTO dto = new PositionDTO();
                dto.PositionName = item.PositionName;
                dto.Description = item.Description;
                dto.PositionGrade = item.PositionGrade;
                dto.isSupervisory = item.isSupervisory;
                dto.isManagerial = item.isManagerial;
                dto.isTopManagement = item.isTopManagement;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetPositionListForDropdown()
        {
            IEnumerable<SelectListItem> positionList = db.Positions.Where(x => x.isDeleted == false).OrderBy(x => x.PositionName).Select(x => new SelectListItem()
            {
                Text = x.PositionName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return positionList;
        }

        public PositionDTO GetUserPosition(int employeeID)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<SelectListItem> GetSupervisorListForDropdown()
        {
            IEnumerable<SelectListItem> supervisorRoleList = db.Positions.Where(x => x.isDeleted == false).OrderBy(x => x.PositionName).Select(x => new SelectListItem()
            {
                Text = x.PositionName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return supervisorRoleList;
        }

        public static IEnumerable<SelectListItem> GetManagerListForDropdown()
        {
            IEnumerable<SelectListItem> managerRoleList = db.Positions.Where(x => x.isDeleted == false).OrderBy(x => x.PositionName).Select(x => new SelectListItem()
            {
                Text = x.PositionName,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return managerRoleList;
        }

        public PositionDTO UpdatePositionWithID(int ID)
        {
            try
            {
                Position po = db.Positions.First(x => x.ID == ID);
                PositionDTO dto = new PositionDTO();
                dto.ID = po.ID;
                dto.PositionName = po.PositionName;
                dto.Description = po.Description;
                dto.PositionGrade = po.PositionGrade;
                dto.isSupervisory = po.isSupervisory;
                dto.isManagerial = po.isManagerial;
                dto.isTopManagement = po.isTopManagement;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePosition(PositionDTO model)
        {
            try
            {
                Position po = db.Positions.First(x => x.ID == model.ID);
                po.PositionName = model.PositionName;
                po.PositionGrade = model.PositionGrade;
                po.Description = model.Description;
                po.isSupervisory = model.isSupervisory;
                po.isManagerial = model.isManagerial;
                po.isTopManagement = model.isTopManagement;
                po.LastUpdateDate = DateTime.Now;
                po.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePosition(int ID)
        {
            try
            {
                Position po = db.Positions.First(x => x.ID == ID);
                po.isDeleted = true;
                po.DeletedDate = DateTime.Now;
                po.LastUpdateDate = DateTime.Now;
                po.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
