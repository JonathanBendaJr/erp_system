using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductCategoryBLL
    {
        ProductCategoryDAO dao = new ProductCategoryDAO();
        public bool AddProductCategory(ProductCategoryDTO model)
        {
            ProductCategory pc = new ProductCategory();
            pc.ProductCategory1 = model.ProductCategory;
            pc.Description = model.Description;
            pc.AddDate = DateTime.Now;
            pc.LastUpdateDate = DateTime.Now;
            pc.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddProductCategory(pc);

            LogDAO.AddLog(General.ProcessType.ProductCategoryAdd, General.TableName.ProductCategory, ID);
            return true;
        }

        public List<ProductCategoryDTO> GetProductCategories()
        {
            return dao.GetProductCategories();
        }

        public ProductCategoryDTO UpdateProductCategoryWithID(int ID)
        {
            return dao.UpdateProductCategoryWithID(ID);
        }

        public bool UpdateProductCategory(ProductCategoryDTO model)
        {
            dao.UpdateProductCategory(model);
            LogDAO.AddLog(General.ProcessType.ProductCategoryUpdate, General.TableName.ProductCategory, model.ID);
            return true;
        }

        public void DeleteProductCategory(int ID)
        {
            dao.DeleteProductCategory(ID);
            LogDAO.AddLog(General.ProcessType.ProductCategoryDelete, General.TableName.ProductCategory, ID);
        }
    }
}
