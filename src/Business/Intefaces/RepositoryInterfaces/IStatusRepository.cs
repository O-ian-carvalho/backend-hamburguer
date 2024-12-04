using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.RepositoryInterfaces
{
    public interface IStatusRepository : IRepository<Status>
    {
        Task<Status> GetStatusOrders(Guid statuseId);
    }
}
