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
    public class FleetVehicleStatusDAO : PostContext
    {
        public int AddFleetVehicleStatus(FleetVehicleStatu fvs)
        {
            try
            {
                db.FleetVehicleStatus.Add(fvs);
                db.SaveChanges();
                return fvs.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FleetVehicleStatusDTO> GetFleetVehicleStatuss()
        {
            List<FleetVehicleStatu> list = db.FleetVehicleStatus.OrderByDescending(x => x.Status).ToList();
            List<FleetVehicleStatusDTO> dtolist = new List<FleetVehicleStatusDTO>();
            foreach (var item in list)
            {
                FleetVehicleStatusDTO dto = new FleetVehicleStatusDTO();
                dto.VehicleStatus = item.Status;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public static IEnumerable<SelectListItem> GetVehicleStatusForDropdown()
        {
            IEnumerable<SelectListItem> vehicleStatusList = db.FleetVehicleStatus.OrderBy(x => x.Status).Select(x => new SelectListItem()
            {
                Text = x.Status,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return vehicleStatusList;
        }

        public FleetVehicleStatusDTO UpdateFleetVehicleStatusWithID(int ID)
        {
            try
            {
                FleetVehicleStatu fvs = db.FleetVehicleStatus.First(x => x.ID == ID);
                FleetVehicleStatusDTO dto = new FleetVehicleStatusDTO();
                dto.ID = fvs.ID;
                dto.VehicleStatus = fvs.Status;
                dto.Description = fvs.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicleStatus(FleetVehicleStatusDTO model)
        {
            try
            {
                FleetVehicleStatu fvs = db.FleetVehicleStatus.First(x => x.ID == model.ID);
                fvs.Status = model.VehicleStatus;
                fvs.Description = model.Description;
                fvs.LastUpdateDate = DateTime.Now;
                fvs.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteFleetVehicleStatus(int ID)
        {
            try
            {
                FleetVehicleStatu fvs = db.FleetVehicleStatus.First(x => x.ID == ID);
                /*gd.isDeleted = true;
                gd.DeletedDate = DateTime.Now;*/
                fvs.LastUpdateDate = DateTime.Now;
                fvs.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
