using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL
{
    public class CompanyBL : ICompanyBL


    {
        public Task<CreateCompanyOutputDTO> CreateCompany(CreateCompanyInputDTO cCompany)
        {
            throw new NotImplementedException();
        }

        public Task<List<FindOneCompanyOutputDTOs>> Find(FindCompanyOutputDTOs cCompany)
        {
            throw new NotImplementedException();
        }

        public Task<FindOneCompanyOutputDTOs> FindOne(FindByIdDTO cCompany)
        {
            throw new NotImplementedException();
        }
    }
}
