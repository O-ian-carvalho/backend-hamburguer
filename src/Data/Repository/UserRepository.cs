using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Models;
using Hamurgueria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db)
        {
        }
        public async Task<IEnumerable<User>> ObterClientesPedidos()
        {
            return await Db.Users.AsNoTracking().Include(p => p.Orders).ToListAsync();
        }

        public async Task<User> ObterUserPedidos(Guid userId)
        {
            return await Db.Users.AsNoTracking().Include(p => p.Orders).FirstOrDefaultAsync(p => p.Id == userId);
        }
    }
}
