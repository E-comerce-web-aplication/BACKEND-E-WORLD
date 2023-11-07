using Inventary.ArqLimpia.DAL;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL
{
    public class ProductRegisterBL : IProductRegisterBL
    {
        private readonly IProductRegister _productRegisterDAL;

        public ProductRegisterBL(IProductRegister productRegisterDAL)
        {
            _productRegisterDAL = productRegisterDAL;
        }

        public async Task<List<ProductRegisterEN>> FindAllByCompanyId(string companyId)
        {
            try
            {
                List<ProductRegisterEN> productRegisters = await _productRegisterDAL.FindAllByCompanyId(companyId);

                if (productRegisters != null)
                {
                    var result = productRegisters.Select(register => new ProductRegisterEN
                    {
                        Id = register.Id,
                        Date = register.Date,
                        User = new User
                        {
                            name = register.User.name,
                            role = register.User.role
                        },
                        Company_name = register.Company_name,
                        Type = register.Type,
                        CompanyId = register.CompanyId
                    }).ToList();

                    return result;
                }

                throw new Exception($"No se encontraron registros con CompanyId {companyId}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductRegisterEN>> FindAllByName(string name)
        {
            try
            {
                List<ProductRegisterEN> productRegisters = await _productRegisterDAL.FindAllByName(name);

                if (productRegisters != null)
                {
                    var result = productRegisters.Select(register => new ProductRegisterEN
                    {
                        Id = register.Id,
                        Date = register.Date,
                        User = new User
                        {
                            name = register.User.name,
                            role = register.User.role
                        },
                        Company_name = register.Company_name,
                        Type = register.Type,
                        CompanyId = register.CompanyId
                    }).ToList();

                    return result;
                }

                throw new Exception($"No se encontraron registros con el nombre {name}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
