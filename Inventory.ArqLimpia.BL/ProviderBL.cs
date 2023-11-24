using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;

namespace Inventory.ArqLimpia.BL
{
    public class ProviderBL : IProviderBL
    {
        private readonly IProvider _providerDAL;

        public ProviderBL(IProvider providerDAL)
        {
            _providerDAL = providerDAL;
        }

        public async Task<CreateProviderOutputDTOs> CreateProvider(CreateProviderInputDTOs pProvider)
        {
            var newProvider = new ProviderEN()
            {
                ProviderName = pProvider.ProviderName,
                Description = pProvider.Description,
                Contact = pProvider.Contact,
                Email = pProvider.Email,
                Address = pProvider.Address,
                City = pProvider.City,
                PostalCode = pProvider.PostalCode
            };

            var existingProvider = await _providerDAL.FindByName(newProvider.ProviderName);
            if (existingProvider != null)
            {
                throw new ArgumentException("Ya existe un proveedor con este nombre.");
            }

            await _providerDAL.Create(newProvider);

            var providerOutput = new CreateProviderOutputDTOs()
            {
                IdProvider = newProvider._id,
                ProviderName = newProvider.ProviderName,
                Description = newProvider.Description,
                Contact = newProvider.Contact,
                Email = newProvider.Email,
                Address = newProvider.Address,
                City = newProvider.City,
                PostalCode = newProvider.PostalCode
            };

            return providerOutput;

        }

        public async Task<DeleteProviderOutputDTOs> Delete(DeleteProviderInputDTOs pProvider)
        {
            var isProvider = await _providerDAL.FindOne(pProvider.IdProvider);
            if (isProvider != null)
            {
                await _providerDAL.Delete(isProvider._id);
                var status = new DeleteProviderOutputDTOs()
                {
                    IsDeleted = true
                };

                return status;
            }

            throw new Exception($"Proveedor con ID {pProvider.IdProvider} no encontrado");

        }

        public async Task<List<FindOneProviderOutputDTOs>> Find(FindProviderOutputDTOs pProvider)
        {
            var providers = await _providerDAL.Find(new ProviderEN
            {
                _id = pProvider.IdProvider,
                ProviderName = pProvider.ProviderName,
                Description = pProvider.Description,
                Contact = pProvider.Contact,
                Email = pProvider.Email,
                Address = pProvider.Address,
                City = pProvider.City,
                PostalCode = pProvider.PostalCode
            });

            var resultList = new List<FindOneProviderOutputDTOs>();
            providers.ForEach(provider => resultList.Add(new FindOneProviderOutputDTOs
            {
                IdProvider = provider._id,
                ProviderName = provider.ProviderName,
                Description = provider.Description,
                Contact = provider.Contact,
                Email = provider.Email,
                Address = provider.Address,
                City = provider.City,
                PostalCode = provider.PostalCode
            }));

            return resultList;

        }

        public async Task<FindOneProviderOutputDTOs> FindOne(FindByIdProviderDTOs pProvider)
        {
            var provider = await _providerDAL.FindOne(pProvider.IdProvider);
            if (provider != null)
            {
                var providerDTO = new FindOneProviderOutputDTOs
                {
                    IdProvider = provider._id,
                    ProviderName = provider.ProviderName,
                    Description = provider.Description,
                    Contact = provider.Contact,
                    Email = provider.Email,
                    Address = provider.Address,
                    City = provider.City,
                    PostalCode = provider.PostalCode
                };
                return providerDTO;
            }

            throw new Exception($"Proveedor con ID {pProvider.IdProvider} no encontrado");

        }

        public async Task<UpdateProviderOutputDTOs> Update(UpdateProviderInputDTOs pProvider)
        {
            var providerToUpdate = await _providerDAL.FindOne(pProvider.IdProvider);

            if (providerToUpdate != null)
            {
                providerToUpdate.ProviderName = pProvider.ProviderName;
                providerToUpdate.Description = pProvider.Description;
                providerToUpdate.Contact = pProvider.Contact;
                providerToUpdate.Email = pProvider.Email;
                providerToUpdate.Address = pProvider.Address;
                providerToUpdate.City = pProvider.City;
                providerToUpdate.PostalCode = pProvider.PostalCode;

                await _providerDAL.Update(providerToUpdate);

                var provider = new UpdateProviderOutputDTOs()
                {
                    IdProvider = providerToUpdate._id,
                    ProviderName = providerToUpdate.ProviderName,
                    Description = providerToUpdate.Description,
                    Contact = providerToUpdate.Contact,
                    Email = providerToUpdate.Email,
                    Address = providerToUpdate.Address,
                    City = providerToUpdate.City,
                    PostalCode = providerToUpdate.PostalCode
                };

                return provider;
            }

            throw new Exception($"Proveedor con ID {pProvider.IdProvider} no encontrado");

        }
    }
}
