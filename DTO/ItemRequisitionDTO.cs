using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class ItemRequisitionDTO
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Item { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public IEnumerable<SelectListItem> Units { get; set; }
        public int UrgencyID { get; set; }
        public string UrgencyType { get; set; }
        public IEnumerable<SelectListItem> Urgencies { get; set; }


        public int ManagerApprovalID { get; set; }
        public string ManagerApprovalStatusName{ get; set; }
        public IEnumerable<SelectListItem> ManagerApprovalStatuses { get; set; }
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public DateTime ManagerApprovalDate { get; set; }
        public string ManagerApprovalMessage { get; set; }


        public int ProcurementManagerApprovalID { get; set; }
        public string ProcurementManagerApprovalStatusName { get; set; }
        public IEnumerable<SelectListItem> ProcrementManagerApprovalStatuses { get; set; }
        public int ProcurementManagerID { get; set; }
        public string ProcurementManagerName { get; set; }
        public DateTime ProcurementManagerApprovalDate { get; set; }
        public string ProcurementManagerApprovalMessage { get; set; }


        public bool ProcurementOfficerDeliver { get; set; }
        public int ProcurementOfficerID { get; set; }
        public string ProcurementOfficerName { get; set; }
        public DateTime ProcurementOfficerDeliveryDate { get; set; }
        public double DeliverQUantity { get; set; }


        public DateTime EmployeeReceivedDate { get; set; }
        public bool EmployeeReceived { get; set; }

    }
}
