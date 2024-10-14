using Shop.DTO;
using Shop.Interfaces;
using Shop.Model;
using Shop.Repositories;

namespace Shop.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(ProductDTO entity)
        {
            var category =  await ((CategoryRepository)_categoryRepository).FindByCategoryTitlleAsync(entity.CategoryTitle);


            Product product = new Product
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                Stock = entity.Stock,
                CategoryId = category.CategoryId,
            };
            await _productRepository.CreateAsync(product);


        }

        public async Task DeleteAsync(int id)
        {
           await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string search)
        {
            return await _productRepository.GetAllAsync(search);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProductDTO entity)
        {
            var category = await ((CategoryRepository)_categoryRepository).FindByCategoryTitlleAsync(entity.CategoryTitle);
            Product product = new Product
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                Stock = entity.Stock,
                CategoryId = category.CategoryId,
            };
            await _productRepository.UpdateAsync(product);
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
                 await ((ProductRepository)_productRepository).ChangePriceAsync(product);
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
                await ((ProductRepository)_productRepository).ChangeQuantityProductAsync(product);
            }

        }
    }
}
