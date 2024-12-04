using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.ServicesIntefaces
{
    public interface IStatusService 
    {
        Task Add(Status status);
        Task Update(Status status);
        Task Remove(Guid id);
    }
}
