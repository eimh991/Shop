using Shop.Model;
using System.Collections.Generic;

namespace Shop.Interfaces
{
    public interface ICartItemService
    {
        Task CreateCartItemAsync(int userId, CartItem cartItem);
        Task DeleteCartItemAsync(int cartItemId);
        Task<IEnumerable<CartItem>> GetAllCartItems(int userId);
        Task<CartItem> GetCartItemById(int userId, int entityId);
        Task UpdateCountCartItems(int userId, CartItem cartItem);

        Task ClearAllCartItems(int userId);
    }
}
