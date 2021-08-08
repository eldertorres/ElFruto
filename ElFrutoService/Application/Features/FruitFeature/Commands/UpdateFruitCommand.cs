using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.Features.FruitFeature.Commands
{
    public class UpdateFruitCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        
        public class UpdateFruitCommandHandler : IRequestHandler<UpdateFruitCommand, int>
        {
            private readonly IFruitRepository _fruitRepository;

            public UpdateFruitCommandHandler(IFruitRepository fruitRepository)
            {
                _fruitRepository = fruitRepository;
            }

            public async Task<int> Handle(UpdateFruitCommand request, CancellationToken cancellationToken)
            {
                var fruit = await _fruitRepository.GetById(request.Id);

                if (fruit == null) return default;

                fruit.Name = request.Name;
                fruit.Description = request.Description;
                fruit.Picture = request.Picture;
                fruit.Price = request.Price;
                fruit.Quantity = request.Quantity;
                
                await _fruitRepository.SaveChanges();
                return fruit.Id;
            }
        }
        
    }
}