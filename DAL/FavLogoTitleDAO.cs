using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FavLogoTitleDAO : PostContext
    {
        public FavLogoTitleDTO GetFavLogoTitle()
        {
            FavLogoTitle fav = db.FavLogoTitles.First();
            FavLogoTitleDTO dto = new FavLogoTitleDTO();
            dto.ID = fav.ID;
            dto.Title = fav.Title;
            dto.Logo = fav.Logo;
            dto.Fav = fav.Fav;
            return dto;
        }

        public FavLogoTitleDTO UpdateFavLogoTitle(FavLogoTitleDTO model)
        {
            try
            {
                FavLogoTitle fav = db.FavLogoTitles.First();
                FavLogoTitleDTO dto = new FavLogoTitleDTO();
                dto.ID = fav.ID;
                dto.Logo = fav.Logo;
                dto.Fav = fav.Fav;
                fav.Title = model.Title;
                if (model.Logo != null)
                    fav.Logo = model.Logo;
                if (model.Fav != null)
                    fav.Fav = model.Fav;
                fav.LastUpdateDate = DateTime.Now;
                fav.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
