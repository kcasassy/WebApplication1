using WebApplication1.Models.Domain;
using WebApplication1.Models.Dto;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;      // depends on the abstraction
        public ProductService(IProductRepository repository) => _repository = repository;

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.StockQuantity));
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            return p is null ? null : new ProductDto(p.Id, p.Name, p.Price, p.StockQuantity);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            // business rules live here, not in the controller or the repository
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new ArgumentException("Name is required.");
            if (input.Price < 0)
                throw new ArgumentException("Price cannot be negative.");

            var entity = new Product { Name = input.Name, Price = input.Price, StockQuantity = input.StockQuantity };
            await _repository.AddAsync(entity);
            return new ProductDto(entity.Id, entity.Name, entity.Price, entity.StockQuantity);
        }
    }
}