using Blazor_FoodAppWeb.Data;
using Blazor_FoodAppWeb.IService;
using MongoDB.Driver;

namespace Blazor_FoodAppWeb.Service
{
    public class CustomerService : ICustomer
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _mongoDatabase = null;
        private IMongoCollection<Customer> _customerTable = null;

        public CustomerService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = _mongoClient.GetDatabase("fooddeliverydb");
            _customerTable = _mongoDatabase.GetCollection<Customer>("customer");
        }
        public string Delete(string customerId)
        {
            _customerTable.DeleteOne(x => x.Id == customerId);
            return "Deleted";
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerTable.Find(x => x.Id == customerId).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return _customerTable.Find(FilterDefinition<Customer>.Empty).ToList();
        }
        
        public void SaveOrUpdate(Customer customer)
        {
            var customerObj = _customerTable.Find(x => x.Id == customer.Id).FirstOrDefault();

            if (customerObj == null)
            {
                _customerTable.InsertOne(customer);
            }
            else
            {
                _customerTable.ReplaceOne(x => x.Id == customer.Id, customer);
            }
        }
    }
}
