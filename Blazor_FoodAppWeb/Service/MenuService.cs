using Blazor_FoodAppWeb.Data;
using Blazor_FoodAppWeb.IService;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Blazor_FoodAppWeb.Service
{
    public class MenuService : IMenuService
    {
        Menu _oMenu = new Menu();

        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Menu> _menuTable = null;

        public MenuService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = _mongoClient.GetDatabase("fooddeliverydb");
            _menuTable = _mongoDatabase.GetCollection<Menu>("menu");
        }

        public Menu GetMenu(string menuId)
        {
            return _menuTable.Find(x => x.Id == menuId).FirstOrDefault();
        }

        public List<Menu> GetMenus()
        {
            return _menuTable.Find(FilterDefinition<Menu>.Empty).ToList();
        }
        public string Save(Menu menu)
        {
            var menuObj = _menuTable.Find(x => x.Id == menu.Id).FirstOrDefault();

            if (menuObj == null)
            {
                _menuTable.InsertOne(menu);
            }
            else 
            {
                _menuTable.ReplaceOne(x => x.Id == menu.Id, menu);            
            
            }
            return "Saved";
        }
    }
}
