using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Areas.Employee.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryBLL bll = new ProductCategoryBLL();
        // GET: Employee/ProductCategory
        public ActionResult AddProductCategory()
        {
            ProductCategoryDTO dto = new ProductCategoryDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddProductCategory(ProductCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddProductCategory(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new ProductCategoryDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public ActionResult ProductCategoryList()
        {
            List<ProductCategoryDTO> model = bll.GetProductCategories();
            return View(model);
        }

        public ActionResult UpdateProductCategory(int ID)
        {
            ProductCategoryDTO dto = bll.UpdateProductCategoryWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateProductCategory(ProductCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateProductCategory(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public JsonResult DeleteProductCategory(int ID)
        {
            bll.DeleteProductCategory(ID);
            return Json("");
        }
    }
}