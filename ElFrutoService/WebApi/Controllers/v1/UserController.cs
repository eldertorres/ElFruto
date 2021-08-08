using System.Threading.Tasks;
using Application.Features.UserFeature.Commmands;
using Application.Features.UserFeature.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Efetua o login do usuário
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
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