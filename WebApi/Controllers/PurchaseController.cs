using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.ArqLimpia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurcharseBL _purcharseBL;

        public PurchaseController(IPurcharseBL purcharseBL)
        {
            _purcharseBL = purcharseBL;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseTransaction([FromBody] PurcharseProductsDTOs purchaseTransaction)
        {
            try
            {
                var purchaseId = await _purcharseBL.CreatePurchaseTransactionAsync(purchaseTransaction);
                return Ok(new { PurchaseId = purchaseId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseTransactionById(string id)
        {
            try
            {
                var purchaseTransaction = await _purcharseBL.GetPurchaseTransactionByIdAsync(id);

                if (purchaseTransaction == null)
                {
                    return NotFound();
                }

                return Ok(purchaseTransaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetTransactionsByCompany(int companyId)
        {
            try
            {
                var transactions = await _purcharseBL.GetTransactionsByCompanyAsync(companyId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("provider/{providerId}")]
        public async Task<IActionResult> GetTransactionsByProvider(string providerId)
        {
            try
            {
                var transactions = await _purcharseBL.GetTransactionsByProviderAsync(providerId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTransactionsByUser(int userId)
        {
            try
            {
                var transactions = await _purcharseBL.GetTransactionsByUserAsync(userId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseTransaction(string id)
        {
            try
            {
                await _purcharseBL.DeletePurchaseTransactionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
