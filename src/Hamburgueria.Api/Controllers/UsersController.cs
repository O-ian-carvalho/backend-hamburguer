using ApiTic.Api.Controllers;
using AutoMapper;
using Hamburgueria.Api.Dto_s;
using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hamburgueria.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : MainController
    {
        private readonly IUserRepository _UserRepository;
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;


        public UsersController(IUserService UserService, IUserRepository UserRepository, IMapper mapper, INotificator notificador) : base(notificador)
        {
            _UserService = UserService;
            _mapper = mapper;
            _UserRepository = UserRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _UserRepository.ObterTodos());
        }

        // GET: api/Users/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var User = _mapper.Map<UserDto>(await _UserRepository.ObterPorId(id));
            if (User == null) return NotFound();
            return User;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserPostDto UserDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _UserService.Add(_mapper.Map<User>(UserDto));
            return CustomResponse(HttpStatusCode.Created, UserDto);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateUser(Guid id, UserDto UserDto)
        {
            if (id != UserDto.Id)
            {
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var UserAtualizacao = await _UserRepository.ObterPorId(id);
            UserAtualizacao = _mapper.Map<User>(UserDto);

            await _UserService.Update(UserAtualizacao);


            return CustomResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var User = await GetUserById(id);
            if (User != null) return NotFound();
            await _UserService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
