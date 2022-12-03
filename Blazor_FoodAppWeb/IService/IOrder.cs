using Blazor_FoodAppWeb.Data;

namespace Blazor_FoodAppWeb.IService
{
    public interface IOrder
    {
        void SaveOrUpdate(Order order);
        Order GetOrder(string orderId);
        List<Order> GetOrders();
        string Delete(string orderId);
    }
}
