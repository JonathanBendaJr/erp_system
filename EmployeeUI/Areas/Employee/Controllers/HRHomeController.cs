using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class HRHomeController : Controller
    {
        // GET: Employee/HRHome
        public ActionResult Index()
        {
            return View();
        }
    }
}