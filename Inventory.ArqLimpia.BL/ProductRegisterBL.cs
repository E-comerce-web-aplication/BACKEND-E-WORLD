using Inventary.ArqLimpia.DAL;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.ProductHistoryDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class ProductRegisterBL : IProductRegisterBL
    {
        readonly IProductRegister _productRegisterDAL;

        public ProductRegisterBL(IProductRegister productRegisterDAL)
        {
            _productRegisterDAL = productRegisterDAL;
        }

        public async Task<List<ProductRegisterDTOs>> FindAll(string companyId, string userName)
        {
            try
            {
                
                List<ProductRegisterEN> productRegisters = await _productRegisterDAL.FindAll(companyId, userName);

              

                if (productRegisters != null)
                {
                    
                    List<ProductRegisterDTOs> result = productRegisters.Select(register => new ProductRegisterDTOs
                    {
                        Id = register.Id.ToString(),
                        Date = register.Date, 
                        User = new ProductRegisterDTOs.UserDto
                        {
                            name = register.User.name,
                            role = register.User.role
                        },
                        Company_name = register.Company_name,
                        Type = (ProductRegisterDTOs.ProductType)register.Type,
                        CompanyId = register.CompanyId
                    }).ToList();

                    return result;
                }

                throw new Exception($"No se encontraron Registro con CompanyId {companyId} y UserName {userName}");
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }
    }
}