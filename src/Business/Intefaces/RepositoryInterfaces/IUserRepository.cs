using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> ObterUserPedidos(Guid userId);
        Task<IEnumerable<User>> ObterClientesPedidos();
    }
}
