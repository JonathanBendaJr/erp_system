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
    public class UnitOfMeasurementDAO : PostContext
    {
        public int AddUnitOfMeasurement(UnitOfMeasurement um)
        {
            try
            {
                db.UnitOfMeasurements.Add(um);
                db.SaveChanges();
                return um.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UnitOfMeasurementDTO> GetUnitOfMeasurements()
        {
            List<UnitOfMeasurement> list = db.UnitOfMeasurements.OrderBy(x => x.MeasuringUnit).ToList();
            List<UnitOfMeasurementDTO> dtolist = new List<UnitOfMeasurementDTO>();
            foreach (var item in list)
            {
                UnitOfMeasurementDTO dto = new UnitOfMeasurementDTO();
                dto.MeasuringUnit = item.MeasuringUnit;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public UnitOfMeasurementDTO UpdateUnitOfMeasurementWithID(int ID)
        {
            try
            {
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == ID);
                UnitOfMeasurementDTO dto = new UnitOfMeasurementDTO();
                dto.ID = um.ID;
                dto.MeasuringUnit = um.MeasuringUnit;
                dto.Description = um.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetUnitsForDropdown()
        {
            IEnumerable<SelectListItem> unitList = db.UnitOfMeasurements.OrderBy(x => x.MeasuringUnit).Select(x => new SelectListItem()
            {
                Text = x.MeasuringUnit,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return unitList;
        }

        public void DeleteUnitOfMeasurement(int ID)
        {
            try
            {
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == ID);
               /* gd.isDeleted = true;
                gd.DeletedDate = DateTime.Now;*/
                um.LastUpdateDate = DateTime.Now;
                um.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateUnitOfMeasurement(UnitOfMeasurementDTO model)
        {
            try
            {
                UnitOfMeasurement um = db.UnitOfMeasurements.First(x => x.ID == model.ID);
                um.MeasuringUnit = model.MeasuringUnit;
                um.Description = model.Description;
                um.LastUpdateDate = DateTime.Now;
                um.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
