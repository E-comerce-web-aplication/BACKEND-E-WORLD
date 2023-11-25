using Inventory.ArqLimpia.BL.DTOs;


namespace Inventory.ArqLimpia.BL.Interfaces;

public interface IProductBL
{
    void CreateProduct(CreateProductsInputDTOs pProducts);
    Task<UpdateProductsOutputDTOs> Update(UpdateProductsInputDTOs pProducts);
    Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts);
    Task<List<FindOneProductsOutputDTOs>> Find(FindProductsOutputDTOs pProducts);
    Task<FindOneProductsOutputDTOs> FindOne(FindByIdDTOs pProducts);
   
}