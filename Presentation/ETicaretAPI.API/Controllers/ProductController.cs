using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = _productReadRepository.GetAll(tracking: false);
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id, tracking: false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Create_Product_VM model)
        {
            await _productWriteRepository.AddAsync(new Product
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Update_Product_VM model)
        {
            var product = await _productReadRepository.GetByIdAsync(model.Id);
            if (product != null)
            {
                product.Price = model.Price;
                product.Stock = model.Stock;
                product.Name = model.Name;
            }

            await _productWriteRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return NoContent();
        }
    }
}