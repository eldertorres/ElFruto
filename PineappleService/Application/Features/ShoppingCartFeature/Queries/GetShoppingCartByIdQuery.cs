using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.ShoppingCartFeature.Queries
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCart>
    {
        public int Id { get; set; }

        public class GetShoppingCartByIdQueryHandle : IRequestHandler<GetShoppingCartByIdQuery, ShoppingCart>
        {
            private readonly IShoppingCartRepository _shoppingCartRepository;

            public GetShoppingCartByIdQueryHandle(IShoppingCartRepository shoppingCartRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
            }

            public Task<ShoppingCart> Handle(GetShoppingCartByIdQuery request, CancellationToken cancellationToken)
            {
                return _shoppingCartRepository.GetById(request.Id);
            }
        }
    }
}