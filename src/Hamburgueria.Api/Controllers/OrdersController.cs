using AutoMapper;
using Hamburgueria.Api.Dto_s;
using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : MainController
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;


        public OrdersController(IOrderService OrderService, IProductRepository ProductRepository, IOrderRepository OrderRepository, IMapper mapper, INotificator notificador) : base(notificador)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _OrderRepository = OrderRepository;
            _ProductRepository = ProductRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _OrderRepository.ObterTodos());
        }

        // GET: api/Orders/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var Order = _mapper.Map<OrderDto>(await _OrderRepository.ObterPorId(id));
            if (Order == null) return NotFound();
            return Order;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderPostDto OrderDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
         
            await _OrderService.Add(_mapper.Map<Order>(OrderDto));
            return CustomResponse(HttpStatusCode.Created, OrderDto);
        }


        // DELETE: api/Orders/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var Order = await GetOrderById(id);
            if (Order != null) return NotFound();
            await _OrderService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpGet("{orderId:Guid}/product/{productId:Guid}")]
        public async Task<ActionResult> AddProductOrder(Guid orderId, Guid productId)
        {
            

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var product = await _ProductRepository.ObterPorId(productId);
            var order  = await _OrderRepository.ObterPorId(orderId);

            if(product == null)
            {
                return BadRequest("Produto não existe");
            }
            if (order == null)
            {
                return BadRequest("Pedido não existe");
            }

            await _OrderRepository.AddProductToOrder(order,product);
            order.Products.Add(product);

            await _OrderRepository.Atualizar(order);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpGet("{orderId:guid}/products")]
        public async Task<IEnumerable<ProductDto>> ObterProductsDoPEdido(Guid orderId)
        {

            var products = await _OrderRepository.GetProductsInOrder(orderId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

    }
}

