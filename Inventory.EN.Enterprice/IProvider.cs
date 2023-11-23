using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{
   public interface IProvider
    {
        Task Create(ProviderEN pProvider);
        Task Update(ProviderEN pProvider);
        Task Delete(string pProvider);
        Task<ProviderEN> FindOne(string providerId);
        Task<List<ProviderEN>> Find(ProviderEN provider);
        Task<ProviderEN> FindByName(string providerName);
    }
}
