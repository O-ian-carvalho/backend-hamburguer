using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
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
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        public CategorieRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Categorie> GetCategorieProducts(Guid categorieId)
        {
            return await Db.Categories.AsNoTracking().Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == categorieId);
        }
    }
}
