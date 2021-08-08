using System.Threading.Tasks;
using Application.Features.FruitFeature.Commands;
using Application.Features.FruitFeature.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    public class FruitController : BaseApiController
    {
        /// <summary>
        /// Cria uma nova Fruta
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateFruitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        /// <summary>
        /// Lista todas as Frutas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFruitsQuery()));
        }
        
        /// <summary>
        /// Retorna Fruta por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetFruitByIdQuery() { Id = id }));
        }
        
        /// <summary>
        /// Remove Fruta por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFruitByIdCommand() { Id = id }));
        }
        /// <summary>
        /// Atualiza Fruta por Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateFruitCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}