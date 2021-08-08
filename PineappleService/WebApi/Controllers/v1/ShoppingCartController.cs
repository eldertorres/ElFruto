using System.Threading.Tasks;
using Application.Features.ShoppingCartFeature.Commands;
using Application.Features.ShoppingCartFeature.Queries;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.v1
{
    public class ShoppingCartController : BaseApiController
    {
        
        /// <summary>
        /// Retorna Carrinho de Compras por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetShoppingCartByIdQuery() { Id = id }));
        }
        
        /// <summary>
        /// Remove Carrinho de Compras por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteShoppingCartCommand() { Id = id }));
        }
        
        /// <summary>
        /// Adiciona um item no Carrinho de Compras   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddItemToShoppingCart(int id, AddItemToShoppingCartCommand command)
        {
            if (id != command.ShoppingCartId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}