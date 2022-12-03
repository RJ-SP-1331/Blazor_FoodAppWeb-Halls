using Blazor_FoodAppWeb.Data;
using Blazor_FoodAppWeb.IService;
using MongoDB.Driver;

namespace Blazor_FoodAppWeb.Service
{
    public class DeliveryManService : IDeliveryMan
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<DeliveryMan> _deliveryManTable = null;

        public DeliveryManService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = _mongoClient.GetDatabase("fooddeliverydb");
            _deliveryManTable = _mongoDatabase.GetCollection<DeliveryMan>("delivery");
        }
        public string Delete(string deliveryMId)
        {
            _deliveryManTable.DeleteOne(x => x.Id == deliveryMId);
            return "Deleted";
        }

        public DeliveryMan GetDeliveryMan(string deliverMId)
        {
            return _deliveryManTable.Find(x => x.Id == deliverMId).FirstOrDefault();
        }

        public List<DeliveryMan> GetDeliveryMen()
        {
            return _deliveryManTable.Find(FilterDefinition<DeliveryMan>.Empty).ToList();
        }

        public void SaveOrUpdate(DeliveryMan deliverM)
        {
            var deliveryObj = _deliveryManTable.Find(x => x.Id == deliverM.Id).FirstOrDefault();

            if(deliveryObj == null) 
            {
                _deliveryManTable.InsertOne(deliverM);
            }
            else 
            {
                _deliveryManTable.ReplaceOne(x => x.Id == deliverM.Id, deliverM);
            }
        }
    }
}
