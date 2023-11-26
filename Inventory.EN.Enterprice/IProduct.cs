using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{

    public interface IProduct
    {
        Task Create(ProductEN pProducts);
        Task Update(ProductEN pProducts);
        Task Delete(string pProducts);
        Task<ProductEN> FindOne(string productId); // Cambiado a string para usar como identificador
        Task<List<ProductEN>> Find( int companyId );
        Task<ProductEN> FindByName(string productName); // Cambiado a string
    }
}
