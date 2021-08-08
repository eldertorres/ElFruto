using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.UserFeature.Commmands
{
    public class LoginUserCommand : IRequest<LoginUserCommand.LoginResponse>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
        public class LoginResponse
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Token { get; set; }
        }
        
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
        {
            public Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}