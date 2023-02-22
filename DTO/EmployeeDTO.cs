using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CountyAddressID { get; set; }
        public string CountyAddressName { get; set; }
        public IEnumerable<SelectListItem> Counties { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase EmployeeImage { get; set; }
        public int CountyOfOriginID { get; set; }
        public string CountyOfOriginName { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }
        public int MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }
        public IEnumerable<SelectListItem> MaritalStatuses { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public IEnumerable<SelectListItem> PositionList { get; set; }

    }
}
