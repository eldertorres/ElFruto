using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.Features.ShoppingCartFeature.Commands
{
    public class DeleteShoppingCartCommand : IRequest<int>
    {
        public int Id { get; set; }
        
        public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, int>
        {
            private readonly IShoppingCartRepository _shoppingCartRepository;

            public DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
            }

            public async Task<int> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
            {
                var shoppingCart = await _shoppingCartRepository.GetById(request.Id);

                if (shoppingCart == null) return default;
                
                await _shoppingCartRepository.Remove(shoppingCart);

                return shoppingCart.Id;
            }
        }
    }
}