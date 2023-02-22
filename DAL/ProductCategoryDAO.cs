using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductCategoryDAO : PostContext
    {
        public int AddProductCategory(ProductCategory pc)
        {
            try
            {
                db.ProductCategories.Add(pc);
                db.SaveChanges();
                return pc.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductCategoryDTO> GetProductCategories()
        {
            List<ProductCategory> list = db.ProductCategories.Where(x => x.isDeleted == false).OrderBy(x => x.ProductCategory1).ToList();
            List<ProductCategoryDTO> dtolist = new List<ProductCategoryDTO>();
            foreach (var item in list)
            {
                ProductCategoryDTO dto = new ProductCategoryDTO();
                dto.ProductCategory = item.ProductCategory1;
                dto.Description = item.Description;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public ProductCategoryDTO UpdateProductCategoryWithID(int ID)
        {
            try
            {
                ProductCategory pc = db.ProductCategories.First(x => x.ID == ID);
                ProductCategoryDTO dto = new ProductCategoryDTO();
                dto.ID = pc.ID;
                dto.ProductCategory = pc.ProductCategory1;
                dto.Description = pc.Description;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProductCategory(ProductCategoryDTO model)
        {
            try
            {
                ProductCategory pc = db.ProductCategories.First(x => x.ID == model.ID);
                pc.ProductCategory1 = model.ProductCategory;
                pc.Description = model.Description;
                pc.LastUpdateDate = DateTime.Now;
                pc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductCategory(int ID)
        {
            try
            {
                ProductCategory pc = db.ProductCategories.First(x => x.ID == ID);
                pc.isDeleted = true;
                pc.DeletedDate = DateTime.Now;
                pc.LastUpdateDate = DateTime.Now;
                pc.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
