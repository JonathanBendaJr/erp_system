using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeEducationDTO: IEnumerable
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public List<EmployeeEducationDTO> EmpEducations { get; set; }
        public string EmployeeFullName { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolCountry { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
        public string DegreeTitle { get; set; }
        public string DocumentPath { get; set; }
        public HttpPostedFileBase DocumentFile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool hasCompleted { get; set; }
        public int DegreeTypeID { get; set; }
        public string DegreeTypeName { get; set; }
        public IEnumerable<SelectListItem> DegreeTypeList { get; set; }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
