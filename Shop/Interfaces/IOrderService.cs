using Shop.Model;

namespace Shop.Interfaces
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(int userId, IEnumerable<CartItem> items);
        public Task<Order> GetOrderById(int userId, int entityId);

        public Task<IEnumerable<Order>> GetAllOrders(int userId); 
    }
}
