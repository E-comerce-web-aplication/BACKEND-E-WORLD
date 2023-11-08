using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.Design;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductRegisterDAL : IProductRegister
    {
        private readonly IMongoCollection<ProductRegisterEN> _collection;
       

        public ProductRegisterDAL(InventoryContextDAL dbContext)
        {
            
            _collection = dbContext.ProductRegister;
        }

        public async Task<List<ProductRegisterEN>> FindAllByCompanyId(string companyId)
        {
            var filter = Builders<ProductRegisterEN>.Filter.Eq("CompanyId", companyId);
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<List<ProductRegisterEN>> FindAllByName(string name)
        {
            var filter = Builders<ProductRegisterEN>.Filter.Eq("User.name", name);
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task RegistrarAccionEnProductRegisterEN(ProductEN producto, ProductType tipoAccion)
        {
            var registroAccion = new ProductRegisterEN
            {
                Date = DateTime.Now,
                User = new User { name = "Nombre de usuario", role = "Rol de usuario" },
                Product_info = ObjectId.Parse(producto._id),
                Company_name = "Nombre de la empresa",
                Type = tipoAccion,
                Changes = new BsonDocument(),
                CompanyId = producto.CompanyId
            };

            await _collection.InsertOneAsync(registroAccion);
        }
    }    
}