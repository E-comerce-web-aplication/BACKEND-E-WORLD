using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs; 
using Microsoft.AspNetCore.Mvc;
using static Inventory.ArqLimpia.BL.DTOs.ProductRegisterDTOs;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("find-by-company")]
        public async Task<IActionResult> FindByCompany(string companyId)
        {
            try
            {
                if (string.IsNullOrEmpty(companyId))
                {
                    return BadRequest("Debes proporcionar un companyId para buscar.");
                }

                var result = await _productRegisterBL.FindAllByCompanyId(companyId);

                if (result.Count > 0)
                {
                    var formattedResult = result.Select(register => new ProductRegisterDTOs
                    {
                        Id = register.Id.ToString(),
                        Date = register.Date,
                        User = new UserDto
                        {
                            name = register.User.name,
                            role = register.User.role
                        },
                        Company_name = register.Company_name,
                        Type = (ProductRegisterDTOs.ProductType)register.Type,
                        CompanyId = register.CompanyId
                    }).ToList();

                    return Ok(formattedResult);
                }

                return NotFound("No se encontraron registros con el companyId proporcionado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("find-by-name")]
        public async Task<IActionResult> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Debes proporcionar un nombre para buscar.");
                }

                var result = await _productRegisterBL.FindAllByName(name);

                if (result.Count > 0)
                {
                    var formattedResult = result.Select(register => new ProductRegisterDTOs
                    {
                        Id = register.Id.ToString(),
                        Date = register.Date,
                        User = new UserDto
                        {
                            name = register.User.name,
                            role = register.User.role
                        },
                        Company_name = register.Company_name,
                        Type = (ProductRegisterDTOs.ProductType)register.Type,
                        CompanyId = register.CompanyId
                    }).ToList();

                    return Ok(formattedResult);
                }


                return NotFound("No se encontraron registros con el nombre proporcionado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
