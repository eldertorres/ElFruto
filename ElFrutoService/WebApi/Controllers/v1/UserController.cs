using System.Threading.Tasks;
using Application.Features.UserFeature.Commmands;
using Application.Features.UserFeature.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApi.Helpers;

namespace WebApi.Controllers.v1
{
    public class UserController : BaseApiController
    {
        
        private readonly AppSettings _appSettings;

        public UserController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Efetua o login do usuário
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            command.Secret = _appSettings.Secret;
            return Ok(await Mediator.Send(command));
        }
        
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }

        

    }
}