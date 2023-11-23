using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using static inventory.ArqLimpia.EN.PurchaseProductEN;
using static Inventory.ArqLimpia.BL.DTOs.PurcharseProductsDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class PurcharseProductBL : IPurcharseBL
    {
        readonly IPurchases _purchasesDAL;

        public PurcharseProductBL(IPurchases purchasesDAL)
        {
            _purchasesDAL = purchasesDAL;
        }
        public async Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purchaseTransaction)
        {
            try
            {
                var purchaseEN = new PurchaseProductEN
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    UserId = new PurchaseProductEN.User { UserId = purchaseTransaction.User.UserId },
                    Products = purchaseTransaction.Products.Select(p => new PurchaseProductEN.Product
                    {
                        IdProduct = p.IdProduct,
                        Price = p.Price,
                        Amount = p.Amount
                    }).ToList(),
                    Total = purchaseTransaction.Total,
                    PurchaseDate = purchaseTransaction.PurchaseDate,
                    CompanyId = purchaseTransaction.Company.CompanyId,
                    ProviderId = ObjectId.Parse(purchaseTransaction.ProviderId)
                };

                // Obtener la transacción existente
                var existingTransaction = await _purchasesDAL.GetExistingTransactionAsync(purchaseEN.UserId.UserId, purchaseEN.CompanyId);

                if (existingTransaction != null)
                {
                    // Si ya existe una transacción, realizar las actualizaciones necesarias
                    foreach (var product in purchaseEN.Products)
                    {
                        var existingProduct = existingTransaction.Products.FirstOrDefault(p => p.IdProduct == product.IdProduct);

                        if (existingProduct != null)
                        {
                            // Actualizar cantidad y precio del producto existente
                            existingProduct.Amount += product.Amount;
                            existingProduct.Price = product.Price;
                        }
                        else
                        {
                            // Agregar nuevo producto a la transacción existente
                            existingTransaction.Products.Add(product);
                        }
                    }

                    // Actualizar el monto total de la transacción
                    existingTransaction.Total += purchaseEN.Total;

                    // Actualizar la fecha de compra
                    existingTransaction.PurchaseDate = DateTime.Now;

                    // Actualizar la transacción existente en la base de datos
                    await _purchasesDAL.UpdatePurchaseTransactionAsync(existingTransaction);

                    return existingTransaction.Id;
                }
                else
                {
                    return await _purchasesDAL.CreatePurchaseTransactionAsync(purchaseEN);
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al crear la transacción de compra: {ex.Message}");
            }
        }


        public async Task DeletePurchaseTransactionAsync(string Id)
        {
            try
            {
                // Lógica para eliminar la transacción de compra por Id
                await _purchasesDAL.DeletePurchaseTransactionAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la transacción de compra: {ex.Message}");
            }
        }

        public async Task<PurcharseProductsDTOs> GetPurchaseTransactionByIdAsync(string Id)
        {
            try
            {
                // Obtener la transacción de compra por Id desde la base de datos
                var purchaseEN = await _purchasesDAL.GetPurchaseTransactionByIdAsync(Id);

                // Convertir la entidad a DTO si la transacción existe
                if (purchaseEN != null)
                {
                    var purchaseDTO = new PurcharseProductsDTOs
                    {
                        Id = purchaseEN.Id,
                        User = new UserDTO
                        {
                            UserId = purchaseEN.UserId.UserId
                            // Asignar otras propiedades del usuario si es necesario
                        },
                        Products = purchaseEN.Products.Select(product => new ProductDTO
                        {
                            IdProduct = product.IdProduct,
                            Price = product.Price,
                            Amount = product.Amount
                            // Asignar otras propiedades del producto si es necesario
                        }).ToList(),
                        Total = purchaseEN.Total,
                        PurchaseDate = purchaseEN.PurchaseDate,
                        Company = new CompanyDTO
                        {
                            CompanyId = purchaseEN.CompanyId
                            // Asignar otras propiedades de la compañía si es necesario
                        },
                        ProviderId = purchaseEN.ProviderId.ToString()
                        // Asignar otras propiedades si es necesario
                    };

                    return purchaseDTO;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la transacción de compra por Id: {ex.Message}");
            }
        }


        public async Task<List<PurcharseProductsDTOs>> GetTransactionsByCompanyAsync(int companyId)
        {
            try
            {
                // Obtener las transacciones de compra por companyId desde la base de datos
                var purchaseENList = await _purchasesDAL.GetTransactionsByCompanyAsync(companyId);

                // Convertir la lista de entidades a lista de DTOs
                var purchaseDTOList = purchaseENList.Select(purchaseEN => new PurcharseProductsDTOs
                {
                    // Asignar propiedades desde la entidad a DTO
                    Id = purchaseEN.Id,
                    User = new UserDTO
                    {
                        UserId = purchaseEN.UserId.UserId
                        // Asignar otras propiedades del usuario si es necesario
                    },
                    Products = purchaseEN.Products.Select(product => new ProductDTO
                    {
                        IdProduct = product.IdProduct,
                        Price = product.Price,
                        Amount = product.Amount
                        // Asignar otras propiedades del producto si es necesario
                    }).ToList(),
                    Total = purchaseEN.Total,
                    PurchaseDate = purchaseEN.PurchaseDate,
                    Company = new CompanyDTO
                    {
                        CompanyId = purchaseEN.CompanyId
                        // Asignar otras propiedades de la compañía si es necesario
                    },
                    ProviderId = purchaseEN.ProviderId.ToString()
                    // Asignar otras propiedades si es necesario
                }).ToList();

                return purchaseDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las transacciones de compra por CompanyId: {ex.Message}");
            }
        }

        public async Task<List<PurcharseProductsDTOs>> GetTransactionsByProviderAsync(string providerId)
        {
            try
            {
                // Obtener las transacciones de compra por providerId desde la base de datos
                var purchaseENList = await _purchasesDAL.GetTransactionsByProviderAsync(providerId);

                // Convertir la lista de entidades a lista de DTOs
                var purchaseDTOList = purchaseENList.Select(purchaseEN => new PurcharseProductsDTOs
                {
                    // Asignar propiedades desde la entidad a DTO
                    Id = purchaseEN.Id,
                    User = new UserDTO
                    {
                        UserId = purchaseEN.UserId.UserId
                        // Asignar otras propiedades del usuario si es necesario
                    },
                    Products = purchaseEN.Products.Select(product => new ProductDTO
                    {
                        IdProduct = product.IdProduct,
                        Price = product.Price,
                        Amount = product.Amount
                        // Asignar otras propiedades del producto si es necesario
                    }).ToList(),
                    Total = purchaseEN.Total,
                    PurchaseDate = purchaseEN.PurchaseDate,
                    Company = new CompanyDTO
                    {
                        CompanyId = purchaseEN.CompanyId
                        // Asignar otras propiedades de la compañía si es necesario
                    },
                    ProviderId = purchaseEN.ProviderId.ToString()
                    // Asignar otras propiedades si es necesario
                }).ToList();

                return purchaseDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las transacciones de compra por ProviderId: {ex.Message}");
            }
        }

        public async Task<List<PurcharseProductsDTOs>> GetTransactionsByUserAsync(int userId)
        {
            try
            {
                // Obtener las transacciones de compra por userId desde la base de datos
                var purchaseENList = await _purchasesDAL.GetTransactionsByUserAsync(userId);

                // Convertir la lista de entidades a lista de DTOs
                var purchaseDTOList = purchaseENList.Select(purchaseEN => new PurcharseProductsDTOs
                {
                    // Asignar propiedades desde la entidad a DTO
                    Id = purchaseEN.Id,
                    User = new UserDTO
                    {
                        UserId = purchaseEN.UserId.UserId
                        // Asignar otras propiedades del usuario si es necesario
                    },
                    Products = purchaseEN.Products.Select(product => new ProductDTO
                    {
                        IdProduct = product.IdProduct,
                        Price = product.Price,
                        Amount = product.Amount
                        // Asignar otras propiedades del producto si es necesario
                    }).ToList(),
                    Total = purchaseEN.Total,
                    PurchaseDate = purchaseEN.PurchaseDate,
                    Company = new CompanyDTO
                    {
                        CompanyId = purchaseEN.CompanyId
                        // Asignar otras propiedades de la compañía si es necesario
                    },
                    ProviderId = purchaseEN.ProviderId.ToString()
                    // Asignar otras propiedades si es necesario
                }).ToList();

                return purchaseDTOList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las transacciones de compra por ProviderId: {ex.Message}");
            }
        }
    }
}
