using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Inventory.ArqLimpia.BL.DTOs.InventoryDTOs;

namespace WebApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryBL _inventoryBL;

        public InventoryController(IInventoryBL inventoryBL)
        {
            _inventoryBL = inventoryBL;
        }

        [HttpGet("companies/{companyId}")]
        public async Task<ActionResult<List<InventoryCompanyDto>>> GetCompanies(int companyId)
        {
            try
            {
                var result = await _inventoryBL.FindAllCompanies(companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log de la excepción o manejo según tus necesidades
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("stores/{storeId}")]
        public async Task<ActionResult<List<InventoryStoreDto>>> GetStores(int storeId)
        {
            try
            {
                var result = await _inventoryBL.FindAllStores(storeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log de la excepción o manejo según tus necesidades
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
