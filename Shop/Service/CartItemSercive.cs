using Shop.Interfaces;
using Shop.Model;
using Shop.Repositories;

namespace Shop.Service
{
    public class CartItemSercive : ICartItemService
    {
        private readonly IRepositoryWithUser<CartItem> _cartItemRepository;

        public CartItemSercive(IRepositoryWithUser<CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task ClearAllCartItems(int userId)
        {
           await ((CartItemRepository)_cartItemRepository).DeleteAllCartItemsAsync(userId);
        }

        public async Task CreateCartItemAsync(int userId, CartItem cartItem)
        {
            await _cartItemRepository.AddAsync(userId, cartItem);
        }

        public async Task DeleteCartItemAsync(int cartItemId)
        {
            await _cartItemRepository.DeleteAsync(cartItemId);
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItems(int userId)
        {
            return await _cartItemRepository.GetAllAsync(userId);
        }

        public async Task<CartItem> GetCartItemById(int userId, int entityId)
        {
            return await _cartItemRepository.GetByIdAsync(userId, entityId);
        }

        public async Task UpdateCountCartItems(int userId, CartItem cartItem)
        {
            await _cartItemRepository.UpdateAsync(userId, cartItem);
        }

    }
}
