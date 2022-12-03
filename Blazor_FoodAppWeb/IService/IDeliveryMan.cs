using Blazor_FoodAppWeb.Data;

namespace Blazor_FoodAppWeb.IService
{
    public interface IDeliveryMan
    {
        void SaveOrUpdate(DeliveryMan deliverM);
        DeliveryMan GetDeliveryMan(string deliverMId);
        List<DeliveryMan> GetDeliveryMen();
        string Delete(string deliveryMId);
    }
}
