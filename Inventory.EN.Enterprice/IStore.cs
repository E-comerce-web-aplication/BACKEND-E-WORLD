using inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IStore
    {
        Task Create(StoreEN sStore);
        Task<StoreEN> FindOne(string Id);
        Task<List<StoreEN>> Find(StoreEN store);
        Task<StoreEN> FindByName(string Name);
    }
}
