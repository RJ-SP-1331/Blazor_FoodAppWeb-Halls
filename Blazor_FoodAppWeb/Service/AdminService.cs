using Blazor_FoodAppWeb.IService;
using Blazor_FoodAppWeb.Data;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Blazor_FoodAppWeb.Service
{
    public class AdminService : IAdminService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Admin> _adminTable = null;
        public AdminService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = _mongoClient.GetDatabase("fooddeliverydb");
            _adminTable = _mongoDatabase.GetCollection<Admin>("admin");
        }
        

        public string Delete(string adminId)
        {
            _adminTable.DeleteOne(x => x.Id == adminId);
            return "Deleted";
        }

        public Admin GetAdmin(string adminId)
        {
            return _adminTable.Find( x => x.Id == adminId).FirstOrDefault();
        }

        public List<Admin> GetAdmins()
        {
            return _adminTable.Find(FilterDefinition<Admin>.Empty).ToList();
        }

        public void SaveOrUpdate(Admin admin)
        {
            var adminObj = _adminTable.Find(x => x.Id == admin.Id).FirstOrDefault();

            if (adminObj == null)
            {
                _adminTable.InsertOne(admin);
            }
            else 
            {
                _adminTable.ReplaceOne(x => x.Id == admin.Id, admin);
            }
        }
    }
}
