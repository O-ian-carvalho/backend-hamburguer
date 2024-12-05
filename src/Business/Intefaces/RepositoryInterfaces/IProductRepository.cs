using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.RepositoryInterfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategorie(Guid categorieId);
        Task<Product> GetProductByName(string name);
    }
}
