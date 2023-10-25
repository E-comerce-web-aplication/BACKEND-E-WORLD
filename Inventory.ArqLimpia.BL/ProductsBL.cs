﻿using Inventory.ArqLimpia.BL.Interfaces;
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
                Product_Name = pProducts.Product_Name,
                Description = pProducts.Description,
                Price = pProducts.Price,
                Images = pProducts.Images,
                Stock = pProducts.Stock,
                CompanyId = pProducts.CompanyId,
                Category = pProducts.Category
            };

            var existingProduct = await _productDAL.FindByName(newProduct.Product_Name);
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
                Product_Name = newProduct.Product_Name,
                Description = newProduct.Description,
                Stock = newProduct.Stock,
                Images = newProduct.Images,
                Price = newProduct.Price,
                Tags = newProduct.Tags,
                Category = newProduct.Category,
                CompanyId = newProduct.CompanyId
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
                Product_Name = pProducts.Product_Name,
                Price = pProducts.Price,
                Images = pProducts.Images,
                Stock = pProducts.Stock,
                CompanyId = pProducts.CompanyId,
                Tags = pProducts.Tags,
                Category = pProducts.Category
            });

            var resultList = new List<FindOneProductsOutputDTOs>();
            products.ForEach(product => resultList.Add(new FindOneProductsOutputDTOs
            {
                Id = product._id,
                Product_Name = product.Product_Name,
                Description = product.Description,
                Stock = product.Stock,
                Images = product.Images,
                Price = product.Price,
                CompanyId = product.CompanyId,
                Tags = product.Tags,
                Category = product.Category
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
                    Product_Name = product.Product_Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    Category = product.Category
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
                productToUpdate.Price = pProducts.Price;
                productToUpdate.Product_Name = pProducts.Product_Name;
                productToUpdate.Stock = pProducts.Stock;
                productToUpdate.Description = pProducts.Description;

                await _productDAL.Update(productToUpdate);

                var product = new UpdateProductsOutputDTOs()
                {
                    IdProduct = productToUpdate._id,
                    Product_Name = productToUpdate.Product_Name,
                    Stock = productToUpdate.Stock,
                    Description = productToUpdate.Description
                };

                return product;
            }

            throw new Exception($"Producto con ID {pProducts.IdProduct} no encontrado");
        }
    }
}
