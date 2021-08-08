using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.FruitFeature.Queries
{
    public class GetFruitByIdQuery : IRequest<Fruit>
    {
        public int Id { get; set; }

        public class GetFruitByIdQueryHandle : IRequestHandler<GetFruitByIdQuery, Fruit>
        {
            private readonly IFruitRepository _fruitRepository;

            public GetFruitByIdQueryHandle(IFruitRepository fruitRepository)
            {
                _fruitRepository = fruitRepository;
            }

            public Task<Fruit> Handle(GetFruitByIdQuery request, CancellationToken cancellationToken)
            {
                return _fruitRepository.GetById(request.Id);
            }
        }
    }
}