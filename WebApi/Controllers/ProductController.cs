using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
  
    [ApiController]
    [Route("api/Products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int companyId )
        {
            try
            {
                var products = await _productBL.Find( companyId );
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _productBL.FindOne(new FindByIdDTOs { Id = id });

                if (product == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductsInputDTOs product)
        {
            try
            {
                _productBL.CreateProduct(product);

                var response = new Response{
                    Ok = "ok",
                    error = ""
                };

                return  Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateProductsInputDTOs product)
        {
            try
            {
                product.IdProduct = id;
                var updatedProduct = await _productBL.Update(product);

                if (updatedProduct == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado");
                }

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var deleteResult = await _productBL.Delete(new DeleteProductsInputDTOs { IdProduct = id });

                if (!deleteResult.IsDeleted)
                {
                    return NotFound($"Producto con ID {id} no encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        public class Response {
            public string Ok { get; set; }
            public string error { get; set; }
            
        }
    }
}
