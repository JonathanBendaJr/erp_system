using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class EmployeeDependantDTO
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public IEnumerable<SelectListItem> RelationshipList { get; set; }
    }
}
