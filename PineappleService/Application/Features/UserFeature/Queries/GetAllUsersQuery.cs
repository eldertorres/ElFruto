using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeature.Queries
{
    public class GetAllUsersQuery: IRequest<IEnumerable<User>>
    {
        public class GetAllUsersQueryHandle : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
        {
            private readonly IUserRepository _userRepository;

            public GetAllUsersQueryHandle(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return _userRepository.GetAll();
            }
        }
    }
}