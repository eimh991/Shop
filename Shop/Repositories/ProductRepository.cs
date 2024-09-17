using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Interfaces;
using Shop.Model;

namespace Shop.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) {
            _context = context;
        }
        public async Task CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity); //_context.Products.Attach(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task Delete(int id)
        {   /*
            var product = await _context.Products.FirstOrDefaultAsync(p=>p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            */
            await _context.Products
               .Where(p => p.ProductId == id)
               .ExecuteDeleteAsync();
            
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {
                return product;
            }
            return null;


        }

        public  async Task UpdateAsync(Product entity)
        {
            await _context.Products
               .Where(p => p.ProductId == entity.ProductId)
               .ExecuteUpdateAsync(s => s
                   .SetProperty(p => p.Name, entity.Name)
                   .SetProperty(u => u.Description, entity.Description)
                   .SetProperty(u => u.Price, entity.Price)
                   .SetProperty(u => u.Stock, entity.Stock)
               );

        }
    }
}
