using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase
    {
        private readonly ICompanyBL _companyBL;

        public CompanyController(ICompanyBL companyBL)
        {
            _companyBL = companyBL;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var company = await _companyBL.Find(new FindCompanyOutputDTOs());
                return Ok(company);
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
                var company = await _companyBL.FindOne(new FindByIdDTO { Id = id });

                if (company == null)
                {
                    return NotFound($"Compania con ID {id} no encontrado");
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCompanyInputDTO company)
        {
            try
            {
                var newCompany = await _companyBL.CreateCompany(company);
                return CreatedAtAction(nameof(GetById), new { id = newCompany.Id }, newCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
