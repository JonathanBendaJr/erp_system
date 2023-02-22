using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeCardBLL ecbll = new EmployeeCardBLL();
        EmployeeWorkBLL workbll = new EmployeeWorkBLL();
        EmployeeSalaryBLL salbll = new EmployeeSalaryBLL(); 
        EmployeeEducationBLL edubll = new EmployeeEducationBLL();
        EmployeeDepartmentBLL edptbll = new EmployeeDepartmentBLL();
        EmployeeDependantBLL edbll = new EmployeeDependantBLL();
        EmployeeBLL bll = new EmployeeBLL();
        // GET: Employee/Employee
        public ActionResult AddEmployee()
        {
            EmployeeDTO model = new EmployeeDTO();
            model.Counties = EmployeeBLL.GetCountiesForDropdown();
            model.Genders = EmployeeBLL.GetGendersForDropdown();
            model.PositionList = EmployeeBLL.GetPositionListForDropdown();
            model.Statuses = EmployeeBLL.GetStatusesForDropdown();
            model.MaritalStatuses = EmployeeBLL.GetMaritalStatusesForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO model)
        {
            if (model.EmployeeImage == null)
            {
                ViewBag.ProcessState = General.Messages.ImageMissing;
            }
            else if (ModelState.IsValid)
            {
                string filename = "";
                HttpPostedFileBase postedfile = model.EmployeeImage;
                Bitmap UserImage = new Bitmap(postedfile.InputStream);
                Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                string ext = Path.GetExtension(postedfile.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    string uniqueNumber = Guid.NewGuid().ToString();
                    filename = uniqueNumber +"_"+ postedfile.FileName;
                    resizeImage.Save(Server.MapPath("~/Areas/Employee/Content/Employees/EmpImages/" + filename));
                    model.ImagePath = filename;

                    bll.AddEmployee(model);
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.ExtensionError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.Counties = EmployeeBLL.GetCountiesForDropdown();
            model.Genders = EmployeeBLL.GetGendersForDropdown();
            model.Statuses = EmployeeBLL.GetStatusesForDropdown();
            model.PositionList = EmployeeBLL.GetPositionListForDropdown();
            model.MaritalStatuses = EmployeeBLL.GetMaritalStatusesForDropdown();
            return View(model);
        }

        public ActionResult EmployeeList()
        {
            List<EmployeeDTO> model = bll.GetEmployees();
            return View(model);
        }

        public ActionResult ViewEmployeeCard(int ID)
        {
            EmployeeCardDTO model = new EmployeeCardDTO();
            model = ecbll.ViewEmployeeCardWithID(ID);
            return View(model);
        }
        public ActionResult UpdateEmployee(int ID)
        {
            EmployeeDTO model = bll.UpdateEmployeeWithID(ID);         
            model.Counties = EmployeeBLL.GetCountiesForDropdown();
            model.Genders = EmployeeBLL.GetGendersForDropdown();
            model.PositionList = EmployeeBLL.GetPositionListForDropdown();
            model.Statuses = EmployeeBLL.GetStatusesForDropdown();
            model.MaritalStatuses = EmployeeBLL.GetMaritalStatusesForDropdown();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if (model.EmployeeImage != null)
                {
                    string filename = "";
                    HttpPostedFileBase postedfile = model.EmployeeImage;
                    Bitmap UserImage = new Bitmap(postedfile.InputStream);
                    Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                    string ext = Path.GetExtension(postedfile.FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        string uniqueNumber = Guid.NewGuid().ToString();
                        filename = uniqueNumber + "_" + postedfile.FileName;
                        resizeImage.Save(Server.MapPath("~/Areas/Employee/Content/Employees/EmpImages/" + filename));
                        model.ImagePath = filename;
                    }
                }
                string oldImagePath = bll.UpdateEmployee(model);
                if (model.EmployeeImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Employee/Content/Employees/EmpImages/" + oldImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Employee/Content/Employees/EmpImages/" + oldImagePath));
                    }
                }
                ViewBag.ProcessState = General.Messages.UpdateSuccess;
            }
            model.Counties = EmployeeBLL.GetCountiesForDropdown();
            model.Genders = EmployeeBLL.GetGendersForDropdown();
            model.PositionList = EmployeeBLL.GetPositionListForDropdown();
            model.Statuses = EmployeeBLL.GetStatusesForDropdown();
            model.MaritalStatuses = EmployeeBLL.GetMaritalStatusesForDropdown();
            return View(model);
        }

        public JsonResult DeleteEmployee(int ID)
        {
            bll.DeleteEmployee(ID);
            return Json("");
        }


    }
}