using Blazor_FoodAppWeb.Data;

namespace Blazor_FoodAppWeb.IService
{
    public interface IMenuService
    {
        string Save(Menu menu);//With Image
        List<Menu> GetMenus();
        Menu GetMenu(string menuId);
    }
}
