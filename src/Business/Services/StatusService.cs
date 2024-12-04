using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models.Categorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Services
{
    public class StatusService : BaseService, IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(INotificator notificator, IStatusRepository statusRepository) : base(notificator)
        {
            _statusRepository = statusRepository;
        }

        public async Task Add(Status status)
        {
            if (_statusRepository.Buscar(p => p.Name == status.Name).Result.Any())
            {
                Notificar("Já existe uma status com esse nome");
                return;
            }
            await _statusRepository.Adicionar(status);
        }

        public async Task Remove(Guid id)
        {
            var produto = await _statusRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("A categoria não existe");
                return;
            }
            await _statusRepository.Remover(id);
        }

        public async Task Update(Status status)
        {
            if (_statusRepository.Buscar(p => p.Name == status.Name).Result.Any())
            {
                Notificar("Já existe uma categoria com esse nome");
                return;
            }
            await _statusRepository.Atualizar(status);
        }
    }
}
