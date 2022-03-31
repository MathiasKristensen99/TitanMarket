using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitanMarket.Core.IServices;
using TitanMarket.Core.Models;
using TitanMarket.WebApi.Dtos;

namespace TitanMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ProductsDto> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts().Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                }).ToList();

                return Ok(new ProductsDto
                {
                    List = products
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("search/{name}")]
        public ActionResult<ProductsDto> GetProductsFromSearch(string name)
        {
            try
            {
                var products = _productService.GetProductsBySearch(name).Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                }).ToList();

                return Ok(new ProductsDto
                {
                    List = products
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProductDto> Create([FromBody] ProductDto productDto)
        {
            var product = _productService.CreateProduct(new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            });

            return Created($"https//:localhost/api/[controller]", product);
        }

        [HttpPatch("{productId}")]
        public ActionResult<ProductDto> UpdateProduct(int productId, [FromBody] ProductDto productDto)
        {
            var product = _productService.UpdateProduct(productId, new Product
            {
                Id = productId,
                Name = productDto.Name,
                Price = productDto.Price
            });

            var newProductDto = new ProductDto
            {
                Id = productId,
                Name = productDto.Name,
                Price = productDto.Price
            };
            return Ok(newProductDto);
        }

        [HttpDelete("{productId}")]
        public void DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
        }
    }
}