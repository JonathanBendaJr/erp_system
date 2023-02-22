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
    public class EmployeeEducationController : Controller
    {
        EmployeeEducationBLL edubll = new EmployeeEducationBLL();
        // GET: Employee/EmployeeEducation
        public ActionResult Index()
        {
            return View();
        }

        // Adding Employee Education 
        public ActionResult AddEmployeeEducation(int id)
        {
            EmployeeEducationDTO model = new EmployeeEducationDTO();
            model.DegreeTypeList = EmployeeEducationBLL.GetDegreeTypeListForDropdown();
            // model.EmployeeList = EmployeeEducationBLL.GetEmployeeListForDropdown();
            model.EmployeeID = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployeeEducation(EmployeeEducationDTO model)
        {
            if (model.DocumentFile == null)
            {
                ViewBag.ProcessState = General.Messages.MissingDocument;
            }
            else if (ModelState.IsValid)
            {
                string filename = "";
                HttpPostedFileBase postedfile = model.DocumentFile;
                string ext = Path.GetExtension(postedfile.FileName.ToLower().Trim());
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    Bitmap UserImage = new Bitmap(postedfile.InputStream);
                    Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                    string uniqueNumber = Guid.NewGuid().ToString();
                    filename = uniqueNumber + "_" + model.EmployeeID;
                    resizeImage.Save(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/" + filename));
                    model.DocumentPath = filename;

                    edubll.AddEmployeeEducation(model);
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeEducationDTO();
                }
                else if(ext == ".pdf")
                {
                    string uniqueNumber = Guid.NewGuid().ToString();
                    filename = uniqueNumber + "_" + model.EmployeeID + ext;
                    var path = Path.Combine(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/"), filename);
                    postedfile.SaveAs(path);
                    model.DocumentPath = filename;

                    edubll.AddEmployeeEducation(model);
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new EmployeeEducationDTO();
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
            model.DegreeTypeList = EmployeeEducationBLL.GetDegreeTypeListForDropdown();
            //return RedirectToAction("Index", "EmployeeAdditionalInformation");
            //return Redirect("/EmployeeAdditionalInformation/Index");

            return View(model);
        }
        public ActionResult EmployeeEducationList()
        {
            List<EmployeeEducationDTO> model = edubll.GetEmployeeEducations();
            //return View(model);
            return PartialView("EmployeeEducationList", model);
        }

        public ActionResult GetEducationListByEmpId(int id)
        {
            List<EmployeeEducationDTO> model = edubll.GetEmployeeEducationList(id);
            //var list = .Where(x => x.UserId == userId).ToList();
            return View(model);
        }
        public ActionResult UpdateEmployeeEducation(int ID)
        {
            EmployeeEducationDTO model = edubll.UpdateEmployeeDepartmentWithID(ID);
            model.DegreeTypeList = EmployeeEducationBLL.GetDegreeTypeListForDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmployeeEducation(EmployeeEducationDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if (model.DocumentFile != null)
                {
                    string filename = "";
                    HttpPostedFileBase postedfile = model.DocumentFile;
                    string ext = Path.GetExtension(postedfile.FileName.ToLower().Trim()); ;
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        Bitmap UserImage = new Bitmap(postedfile.InputStream);
                        Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                        string uniqueNumber = Guid.NewGuid().ToString();
                        filename = uniqueNumber + "_" + model.EmployeeID;
                        resizeImage.Save(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/" + filename));
                        model.DocumentPath = filename;
                    }
                    else if(ext == ".pdf")
                    {
                        string uniqueNumber = Guid.NewGuid().ToString();
                        filename = uniqueNumber + "_" + model.EmployeeID + ext;
                        var path = Path.Combine(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/"), filename);
                        postedfile.SaveAs(path);
                        model.DocumentPath = filename;
                    }
                }
                string oldImagePath = edubll.UpdateEmployeeEducation(model);
                if (model.DocumentFile != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/" + oldImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Employee/Content/Employees/EducationFiles/" + oldImagePath));
                    }
                }
                ViewBag.ProcessState = General.Messages.UpdateSuccess;
            }
            model.DegreeTypeList = EmployeeEducationBLL.GetDegreeTypeListForDropdown();
            return View(model);
        }
        public JsonResult DeleteEmployeeEducation(int ID)
        {
            edubll.DeleteEmployeeEducation(ID);
            return Json("");
        }
    }
}