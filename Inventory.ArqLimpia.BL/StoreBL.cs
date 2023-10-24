using Inventary.ArqLimpia.DAL;
using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.Store;

namespace Inventory.ArqLimpia.BL
{
    public class StoreBL : IStoreBL
    {
        readonly IStore _storeDAL;

        public StoreBL(IStore storeDAL)
        {
            _storeDAL = storeDAL;
        }
        public async Task<CreateStoreOutputDTOs> CreateStore(CreateStoreInputDTOs sStore)
        {
            var newStore = new StoreEN()
            {
                Name = sStore.Name,
                Description = sStore.Description,
                Email = sStore.Email,
                PostalCode = sStore.PostalCode,
                Department = sStore.Department,
                City = sStore.City,
                Address = sStore.Address,
            };

            var existingStore = await _storeDAL.FindByName(newStore.Name);
            if (existingStore != null)
            {
                throw new ArgumentException("Ya existe una tienda con este nombre.");
            }

            await _storeDAL.Create(newStore);

            var storeOutput = new CreateStoreOutputDTOs()
            {
                Id = newStore._id,
                Name = newStore.Name,
                Description = newStore.Description,
                Email = newStore.Email,
                PostalCode = newStore.PostalCode,
                Department = newStore.Department,
                City = newStore.City,
                Address = newStore.Address
            };

            return storeOutput;
        }

        public async Task<List<Store.FindOneStoreOutputDTOs>> Find(Store.FindStoreOuputDTOs sStore)
        {
            var store = await _storeDAL.Find(new StoreEN
            {
                _id = sStore.Id,
                Name = sStore.Name,
                Description = sStore.Description,
                Email = sStore.Email,
                PostalCode = sStore.PostalCode,
                Department = sStore.Department,
                City = sStore.City,
                Address = sStore.Address

            });

            var resultList = new List<FindOneStoreOutputDTOs>();
            store.ForEach(store => resultList.Add(new FindOneStoreOutputDTOs
            {
                Id = store._id,
                Name = store.Name,
                Description = store.Description,
                Email = store.Email,
                PostalCode = store.PostalCode,
                Department = store.Department,
                City = store.City,
                Address = store.Address
            }));

            return resultList;
        }

    public async Task<Store.FindOneStoreOutputDTOs> FindOne(Store.FindByIdDTOs sStore)
        {
            var store = await _storeDAL.FindOne(sStore.Id);
            if (store != null)
            {
                var stores = new FindOneStoreOutputDTOs
                {
                    Id = store._id,
                    Name = store.Name,
                    Description = store.Description,
                    Email = store.Email,
                    PostalCode = store.PostalCode,
                    Department = store.Department,
                    City = store.City,
                    Address = store.Address
                };
                return stores;
            }

            throw new Exception($"Company con ID {sStore.Id} no encontrado");
        }
    }
}
