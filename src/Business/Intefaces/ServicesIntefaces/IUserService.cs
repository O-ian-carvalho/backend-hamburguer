using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.ServicesIntefaces
{
    public interface IUserService : IDisposable
    {
        Task Add(User user);
        Task Update(User user);
        Task Remove(Guid id);
    }
}
