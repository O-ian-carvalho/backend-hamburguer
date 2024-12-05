using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.RepositoryInterfaces
{
    public interface ICategorieRepository : IRepository<Categorie>
    {
        Task<Categorie> GetCategorieProducts(Guid categorieId);
        Task<IEnumerable<Product>> GetProductsInCategorie(Guid categorieId);
    }
}
