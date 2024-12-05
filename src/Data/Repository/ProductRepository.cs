using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using Hamurgueria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await Db.Products.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategorie(Guid categorieId)
        {
            return await Db.Products.AsNoTracking().Where(p => p.CategorieId == categorieId).ToListAsync();
        }

    }
}
