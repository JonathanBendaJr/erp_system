//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmpSalaryBenefit
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int PayGradeID { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance1 { get; set; }
        public decimal Allowance2 { get; set; }
        public decimal GrossSalary { get; set; }
        public System.DateTime AddDate { get; set; }
        public bool isDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public int LastUpdateUserID { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual PayGrade PayGrade { get; set; }
        public virtual T_User T_User { get; set; }
    }
}
