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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _produtoRepository;
        private readonly IProductService _produtoService;
        private readonly IMapper _mapper;


        public ProductsController(IProductService produtoService, IProductRepository produtoRepository, IMapper mapper, INotificator notificador) : base(notificador)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProductss()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _produtoRepository.ObterTodos());
        }

        // GET: api/produtos/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetProductsById(Guid id)
        {
            var produto = _mapper.Map<ProductDto>(await _produtoRepository.ObterPorId(id));
            if (produto == null) return NotFound();
            return produto;
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult> CreateProducts(ProductPostDto produtoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Add(_mapper.Map<Product>(produtoDto));
            return CustomResponse(HttpStatusCode.Created, produtoDto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProducts(Guid id, ProductDto produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return CustomResponse(HttpStatusCode.Ambiguous);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produtoAtualizacao = await _produtoRepository.ObterPorId(id);
            produtoAtualizacao = _mapper.Map<Product>(produtoAtualizacao);

            await _produtoService.Update(produtoAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProducts(Guid id)
        {
            var produto = await GetProductsById(id);
            if (produto != null) return NotFound();
            await _produtoService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }


    }
}
