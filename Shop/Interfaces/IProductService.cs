using Shop.DTO;
using Shop.Model;


namespace Shop.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductDTO entity);
        Task UpdateAsync(ProductDTO entity);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync(string search);
        Task Delete(int id);
        
    }
}
