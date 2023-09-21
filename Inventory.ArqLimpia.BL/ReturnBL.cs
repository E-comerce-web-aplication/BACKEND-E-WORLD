using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class ReturnBL : IReturns
    {

        

        //Metodo para crear un retorno 

        public async Task<createReturnInputDTO >Create(createReturnOutputDTO pReturn)
        {
           throw new NotImplementedException();
        }

        //Metodo Para cancelar un  producto 
        public async Task<ReturnDTOs.cancelReturnInputDTO> Cancel(ReturnDTOs.cancelReturnOutputDTO pReturn)
        {
            throw new NotImplementedException();
        }
        //Metodo para buscar un producto 

        public Task<ReturnDTOs.findReturnInputDTO> Find(ReturnDTOs.findReturnOutputDTO pReturn)
        {
            throw new NotImplementedException();
        }
    }
}
