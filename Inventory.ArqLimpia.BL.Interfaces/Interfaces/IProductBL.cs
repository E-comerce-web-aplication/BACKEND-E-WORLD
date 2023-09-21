using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Inventory.ArqLimpia.BL.Interfaces;

public interface IProductBL
{
    Task<CreateProductsOutputDTOs> CreateProduct(CreateProductsInputDTOs pProducts);
    Task<UpdateProductsOutputDTOs> Update(UpdateProductsInputDTOs pProducts);
    Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts);
    Task<List<FindOneProductsOutputDTOs>> Find(FindProductsOutputDTOs pProducts);
    Task<FindOneProductsOutputDTOs> FindOne(FindByIdDTOs pProducts);
   
}