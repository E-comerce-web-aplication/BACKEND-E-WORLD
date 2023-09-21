using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN.Interfaces;
using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.BL
{
    public class ProductsBL : IProductBL
    {
        readonly IProduct _productDAL;
        readonly IUnitOfWork _unitWork;
       

        public ProductsBL(IProduct pProductDAL, IUnitOfWork pUnitWork)
        {
            _productDAL = pProductDAL;
            _unitWork = pUnitWork;
        }

        //METODO PARA CREAR PRODUCTOS//
        public async Task<CreateProductsOutputDTOs> CreateProduct(CreateProductsInputDTOs pProducts)
        {
                
             ProductEN newProduct = new ProductEN(){
                ProductName = pProducts.ProductName,
                Descriptions = pProducts.Description,
                Price = pProducts.Price,
                ImageUrl = pProducts.ImageUrl,
                Stock = pProducts.Stock
            };

            ProductEN existingProduct = await _productDAL.FindByName(newProduct);

            // Verificar si ya existe un producto con el mismo nombre (NO FUNCIONA)
            if (existingProduct != null)
            {
                throw new ArgumentException("Ya existe un producto con este nombre.");
            }

            // Verificar si los valores de stock y precio son válidos
            if (pProducts.Stock < 0 && pProducts.Stock >= 5)
            {
                throw new ArgumentException("The value of the shares cannot be negative and must be greater than 5");
            }
            if (pProducts.Price <= 10)
            {
                throw new ArgumentException("The price value must be greater than ten.");
            }

            _productDAL.Create(newProduct);
            await _unitWork.SaveChangesAsync();
            CreateProductsOutputDTOs productsOutput = new CreateProductsOutputDTOs()
            {
                IdProduct =newProduct.Id,
                ProductName = newProduct.ProductName,
                Description = newProduct.Descriptions,
                Stock = newProduct.Stock,
                ImageUrl = newProduct.ImageUrl,
                Price = newProduct.Price

            };
            return productsOutput;
        }


        //METODO PARA ELIMINAR PRODUCTOS//
        public async Task<DeleteProductsOutputDTOs> Delete( DeleteProductsInputDTOs pProduct)
        {

            ProductEN isProduct = await _productDAL.FindOne(pProduct.IdProduct);
            
            if(isProduct.Id == pProduct.IdProduct){
            _productDAL.Delete(isProduct);
            await _unitWork.SaveChangesAsync();
            DeleteProductsOutputDTOs status = new DeleteProductsOutputDTOs()
            {
                IsDeleted = true
            };

            return status;
            }
           throw new Exception($"Product with {pProduct.IdProduct} not found");
        }

        public async Task<List<FindOneProductsOutputDTOs>> Find(FindProductsOutputDTOs pProducts)
        {
            List<ProductEN> products = await _productDAL.Find(new ProductEN { 
                Id= pProducts.Id,
                ProductName = pProducts.ProductName,
                Price = pProducts.Price,
                ImageUrl = pProducts.ImageUrl,
                Stock =  pProducts.Stock
            });
            List<FindOneProductsOutputDTOs> List = new List<FindOneProductsOutputDTOs>();
            products.ForEach(s => List.Add(new FindOneProductsOutputDTOs
            {
                Id=s.Id,
                ProductName=s.ProductName,
                Description=s.Descriptions,  
                Stock=s.Stock,
                ImageUrl = s.ImageUrl,
                Price=s.Price,


            }));
            return List;

        }

        //METODO PARA BUSCAR PRODUCTOS//
        public async Task<FindOneProductsOutputDTOs> FindOne(FindByIdDTOs pProducts)
        {
            ProductEN byProduct = new ProductEN(){
                 Id= pProducts.Id
            };
            ProductEN isProduct = await _productDAL.FindOne(byProduct.Id);

            if(isProduct  != null){

                FindOneProductsOutputDTOs products = new FindOneProductsOutputDTOs(){
                  Id = isProduct.Id,
                  Description = isProduct.Descriptions,
                  ProductName = isProduct.ProductName,
                  Stock = isProduct.Stock,
                  Price = isProduct.Price  
                };
                return products ;
            }
            throw new Exception($"Product with id: {pProducts.Id} not found");
        }


        //METODO PARA ACTUALIZAR PRODUCTOS//
        public async Task<UpdateProductsOutputDTOs> Update(UpdateProductsInputDTOs pProducts)
        {

            ProductEN productUpdate = await _productDAL.FindOne(pProducts.ProductId);

            if (productUpdate.Id == pProducts.ProductId)
            {
              productUpdate.Price = pProducts.Price;
              productUpdate.ProductName = pProducts.ProductName;
              productUpdate.Stock = pProducts.Stock;
              productUpdate.Descriptions = pProducts.Description;
              
              _productDAL.Update(productUpdate);
              await _unitWork.SaveChangesAsync();
              UpdateProductsOutputDTOs product = new UpdateProductsOutputDTOs(){
                ProductId = productUpdate.Id,
                ProductName = productUpdate.ProductName,
                Stock = productUpdate.Stock,
                Description = productUpdate.Descriptions
              };
              return product;
            }

        throw new Exception($"The product with id: {pProducts.ProductId} not found");
            
        }
  
    }
}
