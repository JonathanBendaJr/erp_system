using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class PayGradeDTO
    {
        public int ID { get; set; }
        public int PositionID { get; set; }
        [Required(ErrorMessage = "Please fill in the Pay Grade.")]
        public string PayGrade { get; set; }
        public string PositionName { get; set; }
        public IEnumerable<SelectListItem> PositionList { get; set; }
    }
}
