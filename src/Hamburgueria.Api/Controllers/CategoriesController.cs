using AutoMapper;
using Hamburgueria.Api.Dto_s;
using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models.Categorization;
using Hamurgueria.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTic.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategorieRepository _CategorieRepository;
        private readonly ICategorieService _CategorieService;
        private readonly IMapper _mapper;


        public CategoriesController(ICategorieService CategorieService, ICategorieRepository CategorieRepository, IMapper mapper, INotificator notificador) : base(notificador)
        {
            _CategorieService = CategorieService;
            _mapper = mapper;
            _CategorieRepository = CategorieRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategorieDto>> GetCategorie()
        {
            return _mapper.Map<IEnumerable<CategorieDto>>(await _CategorieRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategorieDto>> GetCategorieById(Guid id)
        {
            var Categorie = _mapper.Map<CategorieDto>(await _CategorieRepository.ObterPorId(id));
            if (Categorie == null) return NotFound();
            return Categorie;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategorie(CategoriePostDto CategorieDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _CategorieService.Add(_mapper.Map<Categorie>(CategorieDto));
            return CustomResponse(HttpStatusCode.Created, CategorieDto);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCategorie(Guid id, CategorieDto CategorieDto)
        {
            if (id != CategorieDto.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var CategorieAtualizacao = await _CategorieRepository.ObterPorId(id);
            CategorieAtualizacao = _mapper.Map<Categorie>(CategorieDto);

            await _CategorieService.Update(CategorieAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCategorie(Guid id)
        {

            var Categorie = await GetCategorieById(id);
            if (Categorie != null) return NotFound();
            await _CategorieService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpGet("{categorieId:guid}/products")]
        public async Task<IEnumerable<ProductDto>> ObterProductsDoPEdido(Guid categorieId)
        {

            var products = await _CategorieRepository.GetProductsInCategorie(categorieId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }
    }
}

