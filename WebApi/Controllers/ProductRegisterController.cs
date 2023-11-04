using Inventory.ArqLimpia.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/product-register/find-all")]
    [ApiController]
    public class ProductRegisterController : ControllerBase
    {
        private readonly IProductRegisterBL _productRegisterBL;

        public ProductRegisterController(IProductRegisterBL productRegisterBL)
        {
            _productRegisterBL = productRegisterBL;
        }
        [HttpGet]
        [Route("find-all")]
        public async Task<IActionResult> FindAll(string CompanyId = null, string UserName = null)
        {
            try
            {
                if (string.IsNullOrEmpty(CompanyId) && string.IsNullOrEmpty(UserName))
                {
                    return BadRequest("Debes proporcionar al menos un valor (companyId o userName) para buscar.");
                }

                var productRegisters = await _productRegisterBL.FindAll(CompanyId, UserName);

                if (productRegisters.Count > 0)
                {
                    return Ok(productRegisters);
                }

                return NotFound("No se encontraron registros con los criterios de búsqueda proporcionados.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}