using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Intefaces.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUser(Guid userId);
        Task<IEnumerable<Order>> GetProductsByStatus(Guid statusId);
        Task AddProductToOrder(Order order, Product product);
        Task<IEnumerable<Product>> GetProductsInOrder(Guid orderId);


    }
}
