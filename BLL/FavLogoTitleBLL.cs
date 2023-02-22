using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FavLogoTitleBLL
    {
        FavLogoTitleDAO dao = new FavLogoTitleDAO();
        public FavLogoTitleDTO GetFavLogoTitle()
        {
            return dao.GetFavLogoTitle();
        }

        public FavLogoTitleDTO UpdateFavLogoTitle(FavLogoTitleDTO model)
        {
            FavLogoTitleDTO dto = new FavLogoTitleDTO();
            dto = dao.UpdateFavLogoTitle(model);
            LogDAO.AddLog(General.ProcessType.FavLogoTitleUpdate, General.TableName.FavIconLogo, dto.ID);
            return dto;
        }
    }
}
