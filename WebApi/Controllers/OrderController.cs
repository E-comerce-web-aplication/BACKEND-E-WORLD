using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Inventory.ArqLimpia.BL;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/Orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _orderBL;

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderInputDTOs order)
        {
            try
            {
                var newOrder = await _orderBL.Create(order);
                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string orderId)
        {
            try
            {
                var product = await _orderBL.Find(orderId);

                if (product == null)
                {
                    // Manejar el caso en el que no se encuentra el elemento con el ID especificado
                    return NotFound($"No se encontró el elemento con el ID {orderId}");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}