using Blazor_FoodAppWeb.Data;

namespace Blazor_FoodAppWeb.IService
{
    public interface ICustomer
    {
        void SaveOrUpdate(Customer custiomer);
        Customer GetCustomer(string customerId);
        List<Customer> GetCustomers();
        string Delete(string customerId);
    }
}
