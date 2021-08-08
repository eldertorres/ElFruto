using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.FruitFeature.Queries
{
    public class GetAllFruitsQuery : IRequest<IEnumerable<Fruit>>
    {

        public class GetAllFruitsQueryHandle : IRequestHandler<GetAllFruitsQuery, IEnumerable<Fruit>>
        {
            private readonly IFruitRepository _fruitRepository;

            public GetAllFruitsQueryHandle(IFruitRepository fruitRepository)
            {
                _fruitRepository = fruitRepository;
            }

            public Task<IEnumerable<Fruit>> Handle(GetAllFruitsQuery request, CancellationToken cancellationToken)
            {
                return _fruitRepository.GetAll();
            }
        }
    }
}