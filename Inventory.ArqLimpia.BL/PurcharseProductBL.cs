using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;


namespace Inventory.ArqLimpia.BL
{
    public class PurcharseProductBL : IPurcharseBL
    {
        readonly IPurchases _purchasesDAL;

        public PurcharseProductBL(IPurchases purchasesDAL)
        {
            _purchasesDAL = purchasesDAL;
        }
       public async Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purchaseTransaction)
        {
            try
            {
                
                string id = await _purchasesDAL.CreatePurchaseTransactionAsync(purchaseTransaction);

                string purchaseId = id;

                return purchaseId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar en la base de datos: {ex.ToString()}");
                throw;
            }
        }

      

        public async Task DeletePurchaseTransactionAsync(string Id)
        {
            try
            {
                await _purchasesDAL.DeletePurchaseTransactionAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la transacción de compra: {ex.Message}");
            }
        }

      
       public async Task<List<PurcharseOutputDTO>> GetTransactionsByCompanyAsync(int companyId)
{
    try
    {
        var purchaseENList = await _purchasesDAL.GetTransactionsByCompanyAsync(companyId);

        var purchaseDTOList = purchaseENList.Select(purchaseEN => new PurcharseOutputDTO
        {
            UserId = purchaseEN.UserId,
            Total = purchaseEN.Total,
            CompanyId = purchaseEN.CompanyId,
            Date = purchaseEN.Date,
            ProviderId = purchaseEN.ProviderId.ToString()

        }).ToList();

        return purchaseDTOList;
    }
    catch (Exception ex)
    {
        throw new Exception($"Error al obtener las transacciones de compra por CompanyId: {ex.Message}");
    }
}

    }
}
