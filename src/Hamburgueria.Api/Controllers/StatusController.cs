using ApiTic.Api.Controllers;
using AutoMapper;
using Hamburgueria.Api.Dto_s;
using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models.Categorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hamburgueria.Api.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : MainController
    {
        private readonly IStatusRepository _StatusRepository;
        private readonly IStatusService _StatusService;
        private readonly IMapper _mapper;


        public StatusController(IStatusService StatusService, IStatusRepository StatusRepository, IMapper mapper, INotificator notificador) : base(notificador)
        {
            _StatusService = StatusService;
            _mapper = mapper;
            _StatusRepository = StatusRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusDto>> GetStatus()
        {
            return _mapper.Map<IEnumerable<StatusDto>>(await _StatusRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StatusDto>> GetStatusById(Guid id)
        {
            var Status = _mapper.Map<StatusDto>(await _StatusRepository.ObterPorId(id));
            if (Status == null) return NotFound();
            return Status;
        }

        [HttpPost]
        public async Task<ActionResult> CreateStatus(StatusPostDto StatusDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _StatusService.Add(_mapper.Map<Status>(StatusDto));
            return CustomResponse(HttpStatusCode.Created, StatusDto);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateStatus(Guid id, StatusDto StatusDto)
        {
            if (id != StatusDto.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var StatusAtualizacao = await _StatusRepository.ObterPorId(id);
            StatusAtualizacao = _mapper.Map<Status>(StatusDto);

            await _StatusService.Update(StatusAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteStatus(Guid id)
        {

            var Status = await GetStatusById(id);
            if (Status != null) return NotFound();
            await _StatusService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
