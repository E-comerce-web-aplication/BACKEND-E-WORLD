
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
        public async Task<IActionResult> Get(string returnId)
        {
            try
            {
                var product = await _returnBL.Find(returnId);

                if (product == null)
                {
                    // Manejar el caso en el que no se encuentra el elemento con el ID especificado
                    return NotFound($"No se encontró el elemento con el ID {returnId}");
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
