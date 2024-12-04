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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext db) : base(db)
        {
        }
        public async Task AddProductToOrder(Order order, Product product)
        {
            product.Orders.Add(order);
            Db.Update(product);
            await SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUser(Guid userId)
        {
            return await Db.Orders.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetProductsByStatus(Guid statusId)
        {
            return await Db.Orders.AsNoTracking().Where(p => p.StatusId == statusId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsInOrder(Guid orderId)
        {
            var order = await Db.Orders
                   .Include(o => o.Products)
                   .FirstOrDefaultAsync(o => o.Id == orderId);

            // Retorna os produtos ou uma lista vazia se a ordem não existir
            return order?.Products ?? new List<Product>();
        }
    }
}
