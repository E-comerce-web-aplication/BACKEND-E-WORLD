using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Inventory.ArqLimpia.BL.DTOs.Store;
using FindByIdDTOs = Inventory.ArqLimpia.BL.DTOs.Store.FindByIdDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreBL _storeBL;

        public StoreController(IStoreBL storeBL)
        {
            _storeBL = storeBL;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var store = await _storeBL.Find(new FindStoreOuputDTOs());
                return Ok(store);
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
                var store = await _storeBL.FindOne(new FindByIdDTOs { Id = id });

                if (store == null)
                {
                    return NotFound($"Compania con ID {id} no encontrado");
                }

                return Ok(store);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStoreInputDTOs store)
        {
            try
            {
                var newStore = await _storeBL.CreateStore(store);
                return CreatedAtAction(nameof(GetById), new { id = newStore.Id }, newStore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
