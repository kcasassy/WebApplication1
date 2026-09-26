using WebApplication1.Models.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.Dto;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
namespace WebApplication1.Repositories

{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var entry = await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
                return false;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Product
                                 .AsNoTracking()
                                 .ToListAsync();

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Product.FindAsync(product.Id);
            if (existingProduct == null)
                return null;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}