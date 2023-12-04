using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;
using Inventory.ArqLimpia.EN.Interfaces;
using Inventory.EN.Enterprice;

namespace Inventory.ArqLimpia.BL
{
    public class ReturnBL : IReturns
    {
        readonly IReturn _returnDAL;

        public ReturnBL(IReturn returnDAL)
        {
            _returnDAL = returnDAL;
        }

        public async Task<CreateReturnOutputDTO> Create(CreateReturnInputDTO pReturn)
        {
            
            await _returnDAL.Create(pReturn);

            var createdReturn = new CreateReturnOutputDTO
            {
                Date = pReturn.Date,
                UserId = pReturn.UserId,
                Reason = pReturn.Reason,
                StoreId = pReturn.StoreId,
                Total = pReturn.Total,
                Status = pReturn.Status
            };

           
            return createdReturn;
        }


        public async Task<FindReturnOutputDTOs> Find(string returnId)
        {
            try
            {
                // Llama al método AuthorizeReturn para obtener la información de la devolución
                var returnItem = await _returnDAL.AuthorizeReturn(returnId);

                // Verificar si la devolución no existe
                if (returnItem == null)
                {
                    return null;
                }

                // Crear el objeto de salida
                var result = new FindReturnOutputDTOs
                {
                    Date = returnItem.Date,
                    UserId = returnItem.UserId,
                    Reason = returnItem.Reason,
                    StoreId = returnItem.StoreId,
                    Total = returnItem.Total,
                    Status = returnItem.Status.ToString()
                };

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}

