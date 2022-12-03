using Blazor_FoodAppWeb.IService;
using Blazor_FoodAppWeb.Data;

namespace Blazor_FoodAppWeb.PageClass
{
    public class MenuPC
    {
        IMenuService _menuService = null;
        
        public MenuPC(IMenuService menuService) 
        {
            _menuService = menuService;
        }

        public string SaveInformation(byte[] fileBytes, Menu menu)
        {
            menu.Photo = fileBytes;
            return _menuService.Save(menu);
        }

        public Menu GetMenu(string menuId)
        {
            var menu = _menuService.GetMenu(menuId);
            menu.Photo = this.GetImage(Convert.ToBase64String(menu.Photo));
            menu.ImageUrl = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(menu.Photo));
            return menu;
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;

            if (!string.IsNullOrEmpty(sBase64String)) 
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}
