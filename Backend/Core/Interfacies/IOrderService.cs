using Core.Enteties;

namespace Core.Interfacies
{
    public interface IOrderService
    {
        IQueryable<Order> GetOrders();
    }
}