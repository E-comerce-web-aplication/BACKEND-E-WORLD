
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly IReturns _returnBL;

        public ReturnController(IReturns returnBL)
        {
            _returnBL = returnBL;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateReturnInputDTO returns)
        {
            try
            {
                var newReturn = await _returnBL.Create(returns);
                return Ok(newReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _returnBL.Find();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        
        }
    }
}
