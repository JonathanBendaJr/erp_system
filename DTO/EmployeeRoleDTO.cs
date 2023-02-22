using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeRoleDTO
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public IEnumerable<SelectListItem> PositionList { get; set; }

    }
}
