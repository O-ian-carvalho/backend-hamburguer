using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public readonly IOrderRepository _orderRepository;
        public OrderService(INotificator notificator, IOrderRepository orderRepository) : base(notificator)
        {
            _orderRepository = orderRepository;
        }

        public async Task Add(Order order)
        {
            await _orderRepository.Adicionar(order);
        }



        public async Task Remove(Guid id)
        {
            var order = await _orderRepository.ObterPorId(id);

            if (order == null)
            {
                Notificar("O pedido não existe");
                return;
            }

            if (order.Products.Any())
            {
                Notificar("Esse pedido contem produtos, por isso não poder ser removido");
                return;
            }
            await _orderRepository.Remover(id);
        }

      

   
    }
}
