using Inventary.ArqLimpia.DAL;
using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL
{
    public class CompanyBL : ICompanyBL
    {
        readonly ICompany _companyDAL;

        public CompanyBL(ICompany companyDAL)
        {
            _companyDAL = companyDAL;
        }

        public async Task<CreateCompanyOutputDTO> CreateCompany(CreateCompanyInputDTO cCompany)
        {
            var newCompany = new Company()
            {
                Name = cCompany.Name,
                Description = cCompany.Description,
                Email = cCompany.Email,
                Address = cCompany.Address,

            };

            var existingCompany = await _companyDAL.FindByName(newCompany.Name);
            if (existingCompany != null)
            {
                throw new ArgumentException("Ya existe una compania con este nombre.");
            }

            await _companyDAL.Create(newCompany);

            var companiesOutput = new CreateCompanyOutputDTO()
            {
                Id = newCompany.Id,
                Name = newCompany.Name,
                Description = newCompany.Description,
                Email = newCompany.Email,
                Address = newCompany.Address
            };

            return companiesOutput;
        }

        public async Task<List<FindOneCompanyOutputDTOs>> Find(FindCompanyOutputDTOs cCompany)
        {
            var company = await _companyDAL.Find(new Company
            {
                Id = cCompany.Id,
                Name = cCompany.Name,
                Description = cCompany.Description,
                Email = cCompany.Email,
                Address = cCompany.Address

            });

            var resultList = new List<FindOneCompanyOutputDTOs>();
            company.ForEach(product => resultList.Add(new FindOneCompanyOutputDTOs
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Email = product.Email,
                Address = product.Address
            }));

            return resultList;
        }


        public async Task<FindOneCompanyOutputDTOs> FindOne(FindByIdDTO cCompany)
        {
            var company = await _companyDAL.FindOne(cCompany.Id);
            if (company != null)
            {
                var companies = new FindOneCompanyOutputDTOs
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description,
                    Email = company.Email,
                    Address = company.Address
                };
                return companies;
            }

            throw new Exception($"Company con ID {cCompany.Id} no encontrado");
        }
    }
}