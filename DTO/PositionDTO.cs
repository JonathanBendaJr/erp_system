using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PositionDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please fill in the position name.")]
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string PositionGrade { get; set; }
        public bool isSupervisory { get; set; }
        public bool isManagerial { get; set; }
        public bool isTopManagement { get; set; }
    }
}
