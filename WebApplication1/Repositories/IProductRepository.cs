using WebApplication1.Models.Data;
using WebApplication1.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task AddAsync(Product entity);
    }
}