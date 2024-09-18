using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Interfaces;
using Shop.Model;

namespace Shop.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Category entity)
        {
            _context.Categories.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
             await _context.Categories
                .Where(c=>c.CategoryId == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c=>c.CategoryId==id);
            return category ?? null;
        }

        public async Task UpdateAsync(Category entity)
        {
            await _context.Categories
                .Where(c => c.CategoryId == entity.CategoryId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c=>c.CategoryName,entity.CategoryName)
                );
        }
    }
}
