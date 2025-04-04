﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineOrders.Models.DTO;
using OnlineOrders.Models.Domain;
using OnlineOrders.Data;
using OnlineOrders.Repository;

namespace OnlineOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly OnlineOrdersDbContext dbContext;
        private readonly IProductRepository repository;

        public ProductController(IMapper mapper, OnlineOrdersDbContext dbContext, IProductRepository repository)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsDomain = await repository.GetAllAsync();
            var productsDto = mapper.Map<List<ProductDto>>(productsDomain);
            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id::guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var regionDomain = await dbContext.Products.FindAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            var productDto = mapper.Map<ProductDto>(regionDomain);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] AddProductDto addProductDto)
        {
            //map dto to domain model
            var productDomain = mapper.Map<Product>(addProductDto);

            //use domain model to create
            await dbContext.Products.AddAsync(productDomain);
            await dbContext.SaveChangesAsync();

            //map domain to dto
            var productDto = mapper.Map<ProductDto>(productDomain);

            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }
        [HttpPut]
        [Route("{id::guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var productDomain = await dbContext.Products.FindAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }

            productDomain.Name = updateProductDto.Name;
            productDomain.Price = updateProductDto.Price;
            productDomain.Description = updateProductDto.Description;

            await dbContext.SaveChangesAsync();

            //map domain model to dto
            var productDto = mapper.Map<ProductDto>(productDomain);

            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] Guid id)
        {
            var productDomain = await dbContext.Products.FindAsync(id);
            if (productDomain == null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(productDomain);
            await dbContext.SaveChangesAsync();

            var productDto = mapper.Map<ProductDto>(productDomain);
            return Ok(productDto);
        }

    }
}
