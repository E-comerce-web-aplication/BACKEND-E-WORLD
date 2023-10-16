using Inventory.ArqLimpia.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface ICompanyBL
    {
        Task<CreateCompanyOutputDTO> CreateCompany(CreateCompanyInputDTO cCompany);
        Task<UpdateCompanyOutputDTO> UpdateCompany(UpdateCompanyInputDTO pCompany);
        Task<DeleteCompanyOutputDTO> DeleteCompany(DeleteCompanyInputDTO pCompany);
    }
}
