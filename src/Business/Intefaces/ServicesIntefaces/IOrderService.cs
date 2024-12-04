using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.ServicesIntefaces
{
    public interface IOrderService 
    {
        Task Add(Order order);
        Task Remove(Guid id);

    }
}
