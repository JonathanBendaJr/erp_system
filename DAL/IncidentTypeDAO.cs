using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class IncidentTypeDAO : PostContext
    {
        public static IEnumerable<SelectListItem> GetApprovalsForDropdown()
        {
            IEnumerable<SelectListItem> incidentList = db.IncidentTypes.OrderByDescending(x => x.AddDate).Select(x => new SelectListItem()
            {
                Text = x.IncidentType1,
                Value = SqlFunctions.StringConvert((double)x.ID)
            }).ToList();
            return incidentList;
        }
    }
}
