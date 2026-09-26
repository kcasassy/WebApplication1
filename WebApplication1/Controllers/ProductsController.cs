using WebApplication1.MODELS.Data;
using WebApplication1.MODELS.Domain;
using WebApplication1.MODELS.Dto;
using WebApplication1.Services;
using WebApplication1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Dto;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto product)
        {
            return Ok(await _service.CreateAsync(product));
        }

        [HttpPut("{id}")]
        public Task<IActionResult> PutProduct(int id, ProductDto product)
        {
            throw new NotImplementedException("PUT method is not implemented in the service layer. Implement it in the ProductService class.");
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteProduct(int id)
        {
            throw new NotImplementedException("DELETE method is not implemented in the service layer. Implement it in the ProductService class.");
        }
    }
}