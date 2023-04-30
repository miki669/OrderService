using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using OrderService.Context;
using OrderService.Dto;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PrimaryDataBaseContext _context;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;

        public ProductController(PrimaryDataBaseContext context, ILogger<ProductController> logger,
            IProductServices productServices)
        {
            _context = context;
            _logger = logger;
            _productServices = productServices;
        }
        // GET: api/Product/5
        [HttpGet("{id:guid}")]
        public async Task<ResnoseProductDto> Get(Guid id)
        {
            return await _productServices.GetProductAsync(id);
        }

        // POST: api/Product
        [HttpPost]
        public Task<ResnoseProductDto> Post([FromBody] RequestProductDto productdto)
        {
            return _productServices.CreateProductAsync(productdto);
        }

        // PUT: api/Product/5
        [HttpPut("{id:guid}")]
        public async Task<ResnoseProductDto> Put(Guid id, [FromBody] RequestProductDto productDto)
        {
            return await _productServices.UpdateProductAsync(id, productDto);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}