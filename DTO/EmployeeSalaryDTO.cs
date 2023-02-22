using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeSalaryDTO
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public double BasicSalary { get; set; }
        public double Allowance1 { get; set; }
        public double Allowance2 { get; set; }
        public double GrossSalary { get; set; }
        public int PayGradeID { get; set; }
        public string PayGradeName { get; set; }
        public IEnumerable<SelectListItem> PayGradeList { get; set; }
    }
}
