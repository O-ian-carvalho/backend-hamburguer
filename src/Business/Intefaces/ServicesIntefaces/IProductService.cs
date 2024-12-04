using Hamurgueria.Business.Models;
using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.ServicesIntefaces
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Guid id);
        Task AddProductToOrder(Product product, Order order);
        Task RemoveProductFromOrder(Product product, Order order);
    }
}
