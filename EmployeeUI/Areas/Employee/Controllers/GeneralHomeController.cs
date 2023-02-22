using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class GeneralHomeController : Controller
    {
        // GET: Employee/GeneralHome
        public ActionResult Index()
        {
            return View();
        }
    }
}