using inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface ICompany
    {
        Task Create(Company cCompany);
        Task<Company> FindOne(string Id); 
        Task<List<Company>> Find(Company company);
        Task<Company> FindByName(string Name);
    }
}
