using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.ShoppingCartFeature.Commands
{
    public class AddItemToShoppingCartCommand : IRequest<int>
    {
        public int ShoppingCartId { get; set; }
        
        public int FruitId { get; set; }


        public class AddItemToShoppingCartCommandHandler : IRequestHandler<AddItemToShoppingCartCommand, int>
        {
            private readonly IShoppingCartRepository _shoppingCartRepository;
            private readonly IFruitRepository _fruitRepository;

            public AddItemToShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IFruitRepository fruitRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
                _fruitRepository = fruitRepository;
            }

            public async Task<int> Handle(AddItemToShoppingCartCommand request, CancellationToken cancellationToken)
            {
                var shoppingCart = await _shoppingCartRepository.GetById(request.ShoppingCartId);

                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart();
                    await _shoppingCartRepository.Add(shoppingCart);
                }
               
                var fruit = await _fruitRepository.GetById(request.FruitId);

                if (fruit == null) return default;

                var shoppingCartItem = new ShoppingCartItem();
                
                shoppingCartItem.FruitId = fruit.Id;
                shoppingCartItem.Quantity = 1;
                shoppingCartItem.UnityPrice = fruit.Price;
                shoppingCartItem.Total = shoppingCartItem.UnityPrice * shoppingCartItem.Quantity;

                shoppingCart.ShoppingCartItems.Add(shoppingCartItem);
                shoppingCart.Total = shoppingCart.ShoppingCartItems.Sum(i => i.Total);

                await _shoppingCartRepository.SaveChanges();
                return shoppingCart.Id;
            }
        }
        
    }
}