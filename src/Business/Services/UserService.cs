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
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(INotificator notificator, IUserRepository userRepository) : base(notificator)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user)
        {

            if (_userRepository.Buscar(f => f.Email == user.Email).Result.Any())
            {
                Notificar("Já existe um user com esse email!");
                return;
            }

            await _userRepository.Adicionar(user);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

        public async Task Remove(Guid id)
        {
            var user = await _userRepository.ObterUserPedidos(id);
            if (user == null)
            {
                Notificar("O cliente que você tentou remover não existe");
                return;
            }

            if (user.Orders.Any())
            {
                Notificar("Você não pode excluir clientes com pedidos");
                return;
            }
            await _userRepository.Remover(id);
        }

        public async Task Update(User user)
        {
            if (_userRepository.Buscar(p => p.Email == user.Email && p.Id != user.Id).Result.Any())
            {
                Notificar("Já existe um user com este email");
                return;
            }
            await _userRepository.Atualizar(user);
        }
    }
}
