using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using MediatR;

namespace Application.Features.FruitFeature.Commands
{
    public class DeleteFruitByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        
        public class DeleteFruitByIdCommandHandler : IRequestHandler<DeleteFruitByIdCommand, int>
        {
            private readonly IFruitRepository _fruitRepository;

            public DeleteFruitByIdCommandHandler(IFruitRepository fruitRepository)
            {
                _fruitRepository = fruitRepository;
            }

            public async Task<int> Handle(DeleteFruitByIdCommand request, CancellationToken cancellationToken)
            {
                var fruit = await _fruitRepository.GetById(request.Id);

                if (fruit == null) return default;
                
                await _fruitRepository.Remove(fruit);

                return fruit.Id;
            }
        }
        
        
    }
}