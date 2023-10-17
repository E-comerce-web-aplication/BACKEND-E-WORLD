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
        Task<List<FindOneCompanyOutputDTOs>> Find(FindCompanyOutputDTOs cCompany);
        Task<FindOneCompanyOutputDTOs> FindOne(FindByIdDTO cCompany);
    }
}
