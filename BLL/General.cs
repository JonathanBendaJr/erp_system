using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class General
    {
        public static class ProcessType
        {
            public static int Login = 1;
            public static int Logout = 2;
            public static int ChangePassword = 3;
            public static int PasswordReset = 4;
            public static int AddressAdd = 5;
            public static int AddressUpdate = 6;
            public static int AddressDelete = 7;
            public static int DegreeAdd = 8;
            public static int DegreeUpdate = 9;
            public static int DegreeDelete = 10;
            public static int DepartmentAdd = 11;
            public static int DepartmentUpdate = 12;
            public static int DepartmentDelete = 13;
            public static int EmployeeDependantAdd = 14;
            public static int EmployeeDependantUpdate = 15;
            public static int EmployeeDependantDelete = 16;
            public static int EmployeeEducationAdd = 17;
            public static int EmployeeEducationUpdate = 18;
            public static int EmployeeEducationDelete = 19;
            public static int EmployeeAdd = 20;
            public static int EmployeeUpdate = 21;
            public static int EmployeeDelete = 22;
            public static int EmployeeSalaryAdd = 23;
            public static int EmployeeSalaryUpdate = 24;
            public static int EmployeeSalaryDelete = 25;
            public static int FavLogoTitleAdd = 26;
            public static int FavLogoTitleUpdate = 27;
            public static int FavLogoTitleDelete = 28;
            public static int GenderAdd = 29;
            public static int GenderUpdate = 30;
            public static int GenderDelete = 31;
            public static int LeaveActionAdd = 32;
            public static int LeaveActionUpdate = 33;
            public static int LeaveActionDelete = 34;
            public static int LeaveRequestAdded = 35;
            public static int LeaveRequestUpdate = 36;
            public static int LeaveRequestDelete = 37;
            public static int LeaveTypeAdd = 38;
            public static int LeaveTypeUpdate = 39;
            public static int LeaveTypeDelete = 40;
            public static int LevelOfUrgencyAdd = 41;
            public static int LevelOfUrgencyUpdate = 42;
            public static int LevelOfUrgencyDelete = 43;
            public static int MaritalStatusAdd = 44;
            public static int MaritalStatusUpdate = 45;
            public static int MaritalStatusDelete = 46;
            public static int PayGradeAdd = 47;
            public static int PayGradeUpdate = 48;
            public static int PayGradeDelete = 49;
            public static int PositionAdd = 50;
            public static int PositionUpdate = 51;
            public static int PositionDelete = 52;
            public static int RelationshipAdd = 53;
            public static int RelationshipUpdate = 54;
            public static int RelationshipDelete = 55;
            public static int StatusAdd = 56;
            public static int StatusUpdate = 57;
            public static int StatusDelete = 58;
            public static int UserAdd = 59;
            public static int UserUpdate = 60;
            public static int UserDelete = 61;
            public static int TaskAdd = 62;
            public static int TaskUpdate = 63;
            public static int TaskDelete = 64;
            public static int TaskActionAdd = 65;
            public static int TaskActionUpdate = 66;
            public static int TaskActionDelete = 67;
            public static int TaskReportAdd = 68;
            public static int TaskReportUpdate = 69;
            public static int TaskReportDelete = 70;
            public static int WorkExperienceAdd = 71;
            public static int WorkExperienceUpdate = 72;
            public static int WorkExperienceDelete = 73;
            public static int CountyAdd = 74;
            public static int CountyUpdate = 75;
            public static int CountyDelete = 76;
            public static int EmpDepManSupPositionAdd = 77;
            public static int EmpDepManSupPositionUpdate = 78;
            public static int EmpDepManSupPositionDelete = 79;
            public static int EmployeeRoleAdd = 80;
            public static int EmployeeRoleUpdate = 81;
            public static int EmployeeRoleDelete = 82;
            public static int TaskRatingAdd = 83;
            public static int TaskRatingUpdate = 84;
            public static int TaskRatingDelete = 85;
            public static int FleetVehicleOwnershipAdd = 86;
            public static int FleetVehicleOwnershipUpdate = 87;
            public static int FleetVehicleOwnershipDelete = 88;
            public static int FleetVehicleStatusAdd = 89;
            public static int FleetVehicleStatusUpdate = 90;
            public static int FleetVehicleStatusDelete = 91;
            public static int FleetVehicleTypeAdd = 92;
            public static int FleetVehicleTypeUpdate = 93;
            public static int FleetVehicleTypeDelete = 94;
            public static int UnitOfMeasurementAdd = 95;
            public static int UnitOfMeasurementUpdate = 96;
            public static int UnitOfMeasurementDelete = 97;
            public static int ProductCategoryAdd = 98;
            public static int ProductCategoryUpdate = 99;
            public static int ProductCategoryDelete = 100;
            public static int RequestStatusAdd = 101;
            public static int RequestStatusUpdate = 102;
            public static int RequestStatusDelete = 103;
            public static int ResolutionTypeAdd = 104;
            public static int ResolutionTypeUpdate = 105;
            public static int ResolutionTypeDelete = 106;
            public static int ReceivedConditionAdd = 107;
            public static int ReceivedConditionUpdate = 108;
            public static int ReceivedConditionDelete = 109;

            public static int ItemRequisitionAdd = 110;
            public static int ItemRequisitionUpdate = 111;
            public static int ItemRequisitionDelete = 112;
            public static int ItemRequisitionManagerProcessRequest = 113;
            public static int ItemRequisitionProcurementManagerProcessRequest = 114;
            public static int ItemRequisitionProcurementOfficerDeliveryItem = 115;
            public static int ItemRequisitionDeliveryReceived = 116;

        }

        public static class TableName
        {
            public static string Login = "Login";
            public static string Address = "Address";
            public static string Degree = "Degree Credentials";
            public static string Department = "Department";
            public static string EmployeeDependant = "Employee Dependant";
            public static string EmployeeEducation = "Employee Education";
            public static string Employee = "Employee";
            public static string User = "User";
            public static string EmployeeSalary = "Employee Salary and Benefits";
            public static string FavIconLogo = "Favicon, Logo, and Title";
            public static string Gender = "Gender";
            public static string LeaveAction = "Leave Action";
            public static string LeaveRequest = "Leave Request";
            public static string LeaveType = "Leave Type";
            public static string LevelOfUrgency = "Level Of Urgency";
            public static string MaritalStatus = "Marital Status";
            public static string PayGrade = "Pay Grade";
            public static string Position = "Position";
            public static string Relationship = "Employee Relationship";
            public static string Status = "Status";
            public static string Task = "Task";
            public static string TaskAction = "TaskAction";
            public static string TaskReport = "Task Report";
            public static string WorkExperience = "Employee Work Experience";
            public static string County = "County";
            public static string EmpDepManSupPosition = "Employee Department, Manager, SUpervisor, and Position";
            public static string EmpRole = "Employee Role";
            public static string TaskRatings = "Task Rating";
            public static string FleetVehicleOwnership = "Fleet Vehicle Ownership";
            public static string FleetVehicleStatus = "Fleet Vehicle Status";
            public static string FleetVehicleType = "Fleet Vehicle Type";
            public static string UnitOfMeasurement = "Unit Of Measurement";
            public static string ProductCategory = "Product Category";
            public static string RequestStatus = "Request Status";
            public static string ResolutionType = "Resolution Type"; 
            public static string ReceivedCondition = "Received Condition";
            public static string ItemRequisition = "Item Requisition";

        }

        public static class Messages
        {
            public static int AddSuccess = 1;
            public static int EmptyArea = 2;
            public static int UpdateSuccess = 3;
            public static int ImageMissing = 4;
            public static int ExtensionError = 5;
            public static int GeneralError = 6;
            public static int MissingDocument = 7;
            public static int UserExist = 8;
            public static int PasswordIncorrect = 9;
            public static int UsernameIncorrect = 10;
            public static int LoginError = 11;

        }

        public static class Emails
        {
            public static string UserCreationSubject = "";
            public static string UserCreationMessage = "";
        }
    }
}
