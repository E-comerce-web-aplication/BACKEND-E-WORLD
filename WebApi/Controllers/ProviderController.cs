using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/providers")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderBL _providerBL;

        public ProviderController(IProviderBL providerBL)
        {
            _providerBL = providerBL;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider([FromBody] CreateProviderInputDTOs providerDTO)
        {
            try
            {
                var result = await _providerBL.CreateProvider(providerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(string id)
        {
            try
            {
                var result = await _providerBL.Delete(new DeleteProviderInputDTOs { IdProvider = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProviders()
        {
            try
            {
                var result = await _providerBL.Find(new FindProviderOutputDTOs());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindProviderById(string id)
        {
            try
            {
                var result = await _providerBL.FindOne(new FindByIdProviderDTOs { IdProvider = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(string id, [FromBody] UpdateProviderInputDTOs providerDTO)
        {
            try
            {
                if (id != providerDTO.IdProvider)
                {
                    return BadRequest("ID del proveedor no coincide con el cuerpo de la solicitud.");
                }

                var result = await _providerBL.Update(providerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
