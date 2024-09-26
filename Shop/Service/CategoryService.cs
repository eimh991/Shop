using Shop.Interfaces;
using Shop.Model;

namespace Shop.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(Category entity)
        {
            await _categoryRepository.CreateAsync(entity);
        }

        public async Task Delete(int id)
        {
           await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(string search)
        {
            return await _categoryRepository.GetAllAsync(search);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Category entity)
        {
            return _categoryRepository.UpdateAsync(entity);
        }
    }
}
