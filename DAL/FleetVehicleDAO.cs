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
    public class FleetVehicleDAO : PostContext
    {
        public static IEnumerable<SelectListItem> GetTypeListForDropdown()
        {
            IEnumerable<SelectListItem> typeList = db.FleetVehicleTypes.OrderByDescending(x => x.VehicleType).Select(x => new SelectListItem()
            {
                Text = x.VehicleType,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return typeList;
        }

        public static IEnumerable<SelectListItem> GetVehiclesForDropdown()
        {
            IEnumerable<SelectListItem> vehicleList = db.FleetVehicles.Where(x =>x.VehicleStatusID != 3 && x.isDeleted == false).OrderBy(x => x.VehicleCode).Select(x => new SelectListItem()
            {
                Text = x.VehicleCode,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return vehicleList;
        }

        public static IEnumerable<SelectListItem> GetOwnershipStatusListForDropdown()
        {
            IEnumerable<SelectListItem> ownershipStatusList = db.FleetVehicleOwnerships.OrderByDescending(x => x.VehicleOwnership).Select(x => new SelectListItem()
            {
                Text = x.VehicleOwnership,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return ownershipStatusList;
        }

        public static IEnumerable<SelectListItem> GetUnitListForDropdown()
        {
            IEnumerable<SelectListItem> unitList = db.UnitOfMeasurements.OrderByDescending(x => x.MeasuringUnit).Select(x => new SelectListItem()
            {
                Text = x.MeasuringUnit,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return unitList;
        }

        public static IEnumerable<SelectListItem> GetVehicleStatusListForDropdown()
        {
            IEnumerable<SelectListItem> vehicleStatusList = db.FleetVehicleStatus.OrderByDescending(x => x.Status).Select(x => new SelectListItem()
            {
                Text = x.Status,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return vehicleStatusList;
        }

        public static IEnumerable<SelectListItem> GetRegistrationStatusListForDropdown()
        {
            IEnumerable<SelectListItem> registrationStatusList = db.FleetVehicleRegistrationStatus.OrderByDescending(x => x.RegistrationStatus).Select(x => new SelectListItem()
            {
                Text = x.RegistrationStatus,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return registrationStatusList;
        }

        public static IEnumerable<SelectListItem> GetReceivedConditionListForDropdown()
        {
            IEnumerable<SelectListItem> receivedConditionList = db.FleetVehicleReceivedConditions.OrderByDescending(x => x.VehicleCondition).Select(x => new SelectListItem()
            {
                Text = x.VehicleCondition,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return receivedConditionList;
        }

        public FleetVehicleDTO UpdateFleetVehicleWithID(int ID)
        {
            FleetVehicle fv = db.FleetVehicles.First(x => x.ID == ID);
            FleetVehicleDTO dto = new FleetVehicleDTO();
            //var countyItem = new SelectList(db.Counties, "Id", "Name", fv.CountyAddressID);
            dto.ID = fv.ID;
            dto.VehicleCode = fv.VehicleCode;
            dto.Make = fv.Make;
            dto.VIN = fv.VIN;
            dto.Model = fv.Model;
            dto.Mileage = fv.Mileage.ToString(); ;
            dto.Year = fv.Year;
            dto.Color = fv.Color;
            dto.ReceivedDate = fv.RecieveDate;
            dto.PlateNumber = fv.PlateNumber;
            dto.ReceivedConditionID = fv.RecieveConditionID;
            dto.OwnershipStatusID = fv.OwnershipStatusID;
            dto.RegistrationStatusID = fv.RegistrationStatusID;
            dto.VehicleStatusID = fv.VehicleStatusID;
            dto.UnitID = fv.UnitID;
            dto.TypeID = fv.TypeID;
            dto.FuelTankSize = fv.FuelTankSize;
            dto.FuelTankType = fv.FuelTankType;
            return dto;
        }

        public List<FleetVehicleDTO> GetFleetVehicles()
        {
            var fleetVehicleList= (from fv in db.FleetVehicles.Where(x => x.isDeleted == false)
                                       join fvo in db.FleetVehicleOwnerships on fv.OwnershipStatusID equals fvo.ID
                                       join fvc in db.FleetVehicleReceivedConditions on fv.RecieveConditionID equals fvc.ID
                                       join fvrs in db.FleetVehicleRegistrationStatus on fv.RegistrationStatusID equals fvrs.ID
                                       join fvs in db.FleetVehicleStatus on fv.VehicleStatusID equals fvs.ID
                                       join fvt in db.FleetVehicleTypes on fv.TypeID equals fvt.ID
                                       join um in db.UnitOfMeasurements on fv.UnitID equals um.ID
                                       select new
                                       {
                                           ID = fv.ID,
                                           VehicleCode = fv.VehicleCode,
                                           VIN = fv.VIN,
                                           Mileage = fv.Mileage,
                                           Make = fv.Make,
                                           Model = fv.Model,
                                           Year = fv.Year,
                                           Color = fv.Color,
                                           FuelTankSize = fv.FuelTankSize,
                                           FuelTankType = fv.FuelTankType,
                                           ReceivedDate = fv.RecieveDate,
                                           PlateNumber = fv.PlateNumber,
                                           VehicleType = fvt.VehicleType,
                                           VehicleStatus = fvs.Status,
                                           VehicleOnwership = fvo.VehicleOwnership,
                                           Unit = um.MeasuringUnit,
                                           VehicleRegStatus = fvrs.RegistrationStatus,
                                           VehicleCondition = fvc.VehicleCondition,
                                           AddDate = fv.AddDate
                                       }).OrderByDescending(x => x.AddDate);
            List<FleetVehicleDTO> dtolist = new List<FleetVehicleDTO>();
            foreach (var item in fleetVehicleList)
            {
                FleetVehicleDTO dto = new FleetVehicleDTO();
                dto.ID = item.ID;
                dto.Color = item.Color;
                dto.Make = item.Make;
                dto.Model = item.Model;
                dto.Year = item.Year;
                dto.Mileage = item.Mileage.ToString();
                dto.VIN = item.VIN;
                dto.VehicleCode = item.VehicleCode;
                dto.FuelTankSize = item.FuelTankSize;
                dto.FuelTankType = item.FuelTankType;
                dto.ReceivedDate = item.ReceivedDate;
                dto.PlateNumber = item.PlateNumber;
                dto.ReceivedConditionName = item.VehicleCondition;
                dto.VehicleStatusName = item.VehicleStatus;
                dto.RegistrationStatusName = item.VehicleRegStatus;
                dto.UnitName = item.Unit;
                dto.TypeName = item.VehicleType;
                dto.OwnershipStatusName = item.VehicleOnwership;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public void DeleteFleetVehicle(int ID)
        {
            try
            {
                FleetVehicle fv = db.FleetVehicles.First(x => x.ID == ID);
                fv.isDeleted = true;
                fv.DeletedDate = DateTime.Now;
                fv.LastUpdateDate = DateTime.Now;
                fv.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFleetVehicle(FleetVehicleDTO model)
        {
            try
            {
                FleetVehicle fv = db.FleetVehicles.First(x => x.ID == model.ID);
                fv.VehicleCode = model.VehicleCode;
                fv.VIN = model.VIN;
                fv.Model = model.Model;
                fv.Make = model.Make;
                fv.Year = model.Year;
                fv.Color = model.Color;
                fv.TypeID = model.TypeID;
                fv.Mileage = Convert.ToDecimal(model.Mileage);
                fv.UnitID = model.UnitID;
                fv.RecieveDate = model.ReceivedDate;
                fv.RecieveConditionID = model.ReceivedConditionID;
                fv.OwnershipStatusID = model.OwnershipStatusID;
                fv.VehicleStatusID = model.VehicleStatusID;
                fv.FuelTankSize = model.FuelTankSize;
                fv.FuelTankType = model.FuelTankType;
                fv.RegistrationStatusID = model.RegistrationStatusID;
                fv.PlateNumber = model.PlateNumber;
                fv.LastUpdateDate = DateTime.Now;
                fv.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FleetVehicleDTO GetFleetVehicleDetailsByID(int ID)
        {
            var fleetVehicleDetails = (from fv in db.FleetVehicles.Where(x => x.isDeleted == false && x.ID == ID)
                                          join fvo in db.FleetVehicleOwnerships on fv.OwnershipStatusID equals fvo.ID
                                          join fvc in db.FleetVehicleReceivedConditions on fv.RecieveConditionID equals fvc.ID
                                          join fvrs in db.FleetVehicleRegistrationStatus on fv.RegistrationStatusID equals fvrs.ID
                                          join fvs in db.FleetVehicleStatus on fv.VehicleStatusID equals fvs.ID
                                          join fvt in db.FleetVehicleTypes on fv.TypeID equals fvt.ID
                                          join um in db.UnitOfMeasurements on fv.UnitID equals um.ID
                                       select new
                                          {
                                              ID = fv.ID,
                                              VehicleCode = fv.VehicleCode,
                                              VIN = fv.VIN,
                                              Mileage = fv.Mileage,
                                              Make = fv.Make,
                                              Model = fv.Model,
                                              Year = fv.Year,
                                              Color =fv.Color,
                                              FuelTankSize = fv.FuelTankSize,
                                              FuelTankType = fv.FuelTankType,
                                              ReceivedDate = fv.RecieveDate,
                                              PlateNumber = fv.PlateNumber,
                                              VehicleType = fvt.VehicleType,
                                              VehicleStatus = fvs.Status,
                                              VehicleOnwership = fvo.VehicleOwnership,
                                              Unit = um.MeasuringUnit,
                                              VehicleRegStatus = fvrs.RegistrationStatus,
                                              VehicleCondition = fvc.VehicleCondition,
                                              AddDate = fv.AddDate
                                          }).OrderByDescending(x => x.AddDate);
            FleetVehicleDTO dto = new FleetVehicleDTO();
            foreach (var item in fleetVehicleDetails)
            {
                dto.ID = item.ID;
                dto.Color = item.Color;
                dto.Make = item.Make;
                dto.Model = item.Model;
                dto.Year = item.Year;
                dto.Mileage = item.Mileage.ToString();
                dto.VIN = item.VIN;
                dto.VehicleCode = item.VehicleCode;
                dto.FuelTankSize = item.FuelTankSize;
                dto.FuelTankType = item.FuelTankType;
                dto.ReceivedDate = item.ReceivedDate;
                dto.PlateNumber = item.PlateNumber;
                dto.ReceivedConditionName = item.VehicleCondition;
                dto.VehicleStatusName = item.VehicleStatus;
                dto.RegistrationStatusName = item.VehicleRegStatus;
                dto.UnitName = item.Unit;
                dto.TypeName = item.VehicleType;
                dto.OwnershipStatusName = item.VehicleOnwership;
            }
            return dto;
        }

        public int AddFleetVehicle(FleetVehicle fv)
        {
            try
            {
                db.FleetVehicles.Add(fv);
                db.SaveChanges();
                return fv.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
