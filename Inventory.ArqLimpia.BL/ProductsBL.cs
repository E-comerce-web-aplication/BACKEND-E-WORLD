using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN.Interfaces;
using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.BL
{
    public class ProductsBL : IProductBL
    {
        readonly IProduct _productDAL;

        public ProductsBL(IProduct productDAL)
        {
            _productDAL = productDAL;
        }

        public async Task<CreateProductsOutputDTOs> CreateProduct(CreateProductsInputDTOs pProducts)
        {
             var newProduct = new ProductEN()
            {
                ProductName = pProducts.ProductName,
                Title =pProducts.Title,
                Description = pProducts.Description,
                 Images = pProducts.Images,
                 Stock = pProducts.Stock,
                 Price = pProducts.Price,
                CompanyId = pProducts.CompanyId,
                SendConditions = pProducts.SendConditions
                
            };

            var existingProduct = await _productDAL.FindByName(newProduct.ProductName);
            if (existingProduct != null)
            {
                throw new ArgumentException("Ya existe un producto con este nombre.");
            }

            if (newProduct.Stock < 0 || newProduct.Stock > 5)
            {
                throw new ArgumentException("El valor de las existencias debe estar entre 0 y 5.");
            }
            if (newProduct.Price <= 10)
            {
                throw new ArgumentException("El precio debe ser mayor que 10.");
            }

            await _productDAL.Create(newProduct);

            var productsOutput = new CreateProductsOutputDTOs()
            {
                IdProduct = newProduct._id,
                ProductName = newProduct.ProductName,
                Title =newProduct.Title,
                Description = newProduct.Description,
                Images = newProduct.Images,
                Stock = newProduct.Stock,
                Price = newProduct.Price,
                CompanyId = newProduct.CompanyId,
                SendConditions = newProduct.SendConditions,
                Tags = newProduct.Tags
            };

            return productsOutput;
        }

        public async Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProduct)
        {
            var isProduct = await _productDAL.FindOne(pProduct.IdProduct);
            if (isProduct != null)
            {
                await _productDAL.Delete(isProduct._id);
                var status = new DeleteProductsOutputDTOs()
                {
                    IsDeleted = true
                };

                return status;
            }

            throw new Exception($"Producto con ID {pProduct.IdProduct} no encontrado");
        }

        public async Task<List<FindOneProductsOutputDTOs>> Find(FindProductsOutputDTOs pProducts)
        {
            var products = await _productDAL.Find(new ProductEN
            {
                _id = pProducts.Id,
                ProductName = pProducts.ProductName,
                Title = pProducts.Title, 
                Description = pProducts.Description,
                Images = pProducts.Images,
                Stock = pProducts.Stock,
                Price = pProducts.Price,
                CompanyId = pProducts.CompanyId,
                SendConditions = pProducts.SendConditions,
                Tags = pProducts.Tags
               
            });

            var resultList = new List<FindOneProductsOutputDTOs>();
            products.ForEach(product => resultList.Add(new FindOneProductsOutputDTOs
            {
                Id = product._id,
             ProductName = product.ProductName,
                Title = product.Title, 
                Description = product.Description,
                Images = product.Images,
                Stock = product.Stock,
                Price = product.Price,
                CompanyId = product.CompanyId,
                SendConditions = product.SendConditions,
                Tags = product.Tags
               
            }));

            return resultList;
        }

        public async Task<FindOneProductsOutputDTOs> FindOne(FindByIdDTOs pProducts)
        {
            var product = await _productDAL.FindOne(pProducts.Id);
            if (product != null)
            {
                var products = new FindOneProductsOutputDTOs
                {
                    Id = product._id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    SendConditions = product.SendConditions
                };
                return products;
            }

            throw new Exception($"Producto con ID {pProducts.Id} no encontrado");
        }

        public async Task<UpdateProductsOutputDTOs> Update(UpdateProductsInputDTOs pProducts)
        {
            var productToUpdate = await _productDAL.FindOne(pProducts.IdProduct);

            if (productToUpdate != null)
            {
                productToUpdate.ProductName = pProducts.ProductName;
                productToUpdate.Title = pProducts.Title;
                productToUpdate.Description = pProducts.Description;
                productToUpdate.Images = pProducts.Images;
                productToUpdate.Stock = pProducts.Stock;
                productToUpdate.Price = pProducts.Price;
                productToUpdate.SendConditions = pProducts.SendConditions;

                await _productDAL.Update(productToUpdate);

                var product = new UpdateProductsOutputDTOs()
                {
                    IdProduct = productToUpdate._id,
                    Title = productToUpdate.Title,
                    Description = productToUpdate.Description,
                    Images = productToUpdate.Images,
                    Stock = productToUpdate.Stock,
                    Price = productToUpdate.Price,
                    SendConditions = productToUpdate.SendConditions
            };

                return product;
            }

            throw new Exception($"Producto con ID {pProducts.IdProduct} no encontrado");
        }
    }
}
