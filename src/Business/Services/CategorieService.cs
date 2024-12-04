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
    public class CategorieService : BaseService, ICategorieService
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategorieService(INotificator notificator, ICategorieRepository categorietRepository) : base(notificator)
        {
            _categorieRepository = categorietRepository;
        }

        public async Task Add(Categorie categorie)
        {
            if(_categorieRepository.Buscar(p=> p.Name == categorie.Name).Result.Any())
            {
                Notificar("Já existe uma categoria com esse nome");
                return;
            }
            await _categorieRepository.Adicionar(categorie);
        }

        public async Task Remove(Guid id)
        {
            var produto = await _categorieRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("A categoria não existe");
                return;
            }
            await _categorieRepository.Remover(id);
        }

        public async Task Update(Categorie categorie)
        {
            if (_categorieRepository.Buscar(p => p.Name == categorie.Name).Result.Any())
            {
                Notificar("Já existe uma categoria com esse nome");
                return;
            }
            await _categorieRepository.Atualizar(categorie);
        }
    }
}
