﻿
using static Inventory.ArqLimpia.BL.DTOs.Store;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IStoreBL
    {
        Task<CreateStoreOutputDTOs> CreateStore(CreateStoreInputDTOs sStore);
        Task<List<FindOneStoreOutputDTOs>> Find(FindStoreOuputDTOs sStore);
        Task<FindOneStoreOutputDTOs> FindOne(FindByIdDTOs sStore);
    }
}