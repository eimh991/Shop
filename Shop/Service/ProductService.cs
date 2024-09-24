using Shop.DTO;
using Shop.Interfaces;
using Shop.Model;
using Shop.Repositories;

namespace Shop.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository){
            
            _repository = repository;
        }
        public async Task CreateAsync(ProductDTO entity)
        {
            Product product = new Product
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                Stock = entity.Stock,
                CategoryId = entity.CategoryId,
            };
            await _repository.CreateAsync(product);


        }

        public async Task Delete(int id)
        {
           await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string search)
        {
            return await _repository.GetAllAsync(search);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProductDTO entity)
        {
            Product product = new Product
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                Stock = entity.Stock,
                CategoryId = entity.CategoryId,
            };
            await _repository.UpdateAsync(product);
        }

        public async Task ChangePriceAsync(ProductDTO entity)
        {
            if(entity.Price > 0m)
            {
                Product product = new Product
                {
                    ProductId = entity.ProductId,
                    Price = entity.Price,
                };
                 await ((ProductRepository)_repository).ChangePriceAsync(product);
            }
            
        }

        public async Task ChangeQuantityProductAsync(ProductDTO entity)
        {
            if (entity.Stock > 0m)
            {
                Product product = new Product
                {
                    ProductId = entity.ProductId,
                    Stock = entity.Stock,
                };
                await ((ProductRepository)_repository).ChangeQuantityProductAsync(product);
            }

        }
    }
}
