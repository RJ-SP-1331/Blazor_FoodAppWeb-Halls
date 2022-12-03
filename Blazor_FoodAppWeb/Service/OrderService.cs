using Blazor_FoodAppWeb.Data;
using Blazor_FoodAppWeb.IService;
using MongoDB.Driver;

namespace Blazor_FoodAppWeb.Service
{
    public class OrderService : IOrder
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Order> _orderTable = null;

        public OrderService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = _mongoClient.GetDatabase("fooddeliverydb");
            _orderTable = _mongoDatabase.GetCollection<Order>("order");
        }
        public string Delete(string orderId)
        {
            _orderTable.DeleteOne(x => x.Id == orderId);
            return "Deleted";
        }

        public Order GetOrder(string orderId)
        {
            return _orderTable.Find(x => x.Id == orderId).FirstOrDefault();
        }
        
        public List<Order> GetOrders()
        {
            return _orderTable.Find(FilterDefinition<Order>.Empty).ToList();
        }
        
        public void SaveOrUpdate(Order order)
        {
            var orderObj = _orderTable.Find(x => x.Id == order.Id).FirstOrDefault();

            if (orderObj == null)
            {
                _orderTable.InsertOne(order);
            }
            else
            {
                _orderTable.ReplaceOne(x => x.Id == order.Id, order);
            }
        }
    }
}
