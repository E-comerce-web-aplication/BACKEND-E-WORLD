using Microsoft.AspNetCore.Mvc;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHistoryController : ControllerBase
    {
        private readonly IProductHistoryBL _productHistoryBL;

        public ProductHistoryController(IProductHistoryBL productHistoryBL)
        {
            _productHistoryBL = productHistoryBL;
        }


        [HttpGet("findall")]
        public async Task<ActionResult<List<ProductHistoryDTOs.FindAllOutputDTOs>>> FindAll(string companyId)
        {
            try
            {
                var searchInput = new ProductHistoryDTOs.FindAllOutputDTOs { CompanyId = companyId };
                var result = await _productHistoryBL.FindAll(searchInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
    
}
