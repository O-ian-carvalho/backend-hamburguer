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
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(INotificator notificator, IProductRepository productRepository) : base(notificator)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if(_productRepository.Buscar(x => x.Name == product.Name).Result.Any())
            {
                Notificar("Já existe um produto com esse nome");
                return;
            }
            await _productRepository.Adicionar(product);
        }

        public async Task AddProductToOrder(Product product ,Order order)
        {
            product.Orders.Add(order);
            await _productRepository.Atualizar(product);
        }

        

        public async Task Remove(Guid id)
        {
            var produto = await _productRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("O produto não existe");
                return;
            }

            await _productRepository.Remover(id);
        }

        public async Task RemoveProductFromOrder(Product product, Order order)
        {
            product.Orders.Remove(order);
            await _productRepository.Atualizar(product);
        }

        public async Task Update(Product product)
        {
            if (_productRepository.Buscar(x => x.Name == product.Name && x.Id != product.Id).Result.Any())
            {
                Notificar("Já existe um produto com esse nome");
                return;
            }

            await _productRepository.Atualizar(product);
        }
    }
}
