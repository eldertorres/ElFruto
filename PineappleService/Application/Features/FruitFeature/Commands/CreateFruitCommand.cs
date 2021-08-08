using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.FruitFeature.Commands
{
    public class CreateFruitCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        
        public class CreateFruitCommandHandler : IRequestHandler<CreateFruitCommand, int>
        {
            private readonly IFruitRepository _fruitRepository;

            public CreateFruitCommandHandler(IFruitRepository fruitRepository)
            {
                _fruitRepository = fruitRepository;
            }

            public async Task<int> Handle(CreateFruitCommand request, CancellationToken cancellationToken)
            {
                var fruit = new Fruit();
                
                fruit.Name = request.Name;
                fruit.Description = request.Description;
                fruit.Picture = request.Picture;
                fruit.Price = request.Price;
                fruit.Quantity = request.Quantity;

                await _fruitRepository.Add(fruit);
                //await _fruitRepository.SaveChanges();

                return fruit.Id;
            }
        }
    }
}