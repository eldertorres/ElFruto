using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Application.Features.UserFeature.Commmands
{
    public class LoginUserCommand : IRequest<LoginUserCommand.LoginResponse>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string Secret { get; set; }
        
        public class LoginResponse
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
        }
        
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
        {
            private readonly IUserRepository _userRepository;

            public LoginUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetAll();
                var user = users.SingleOrDefault(x => x.Email == request.Email && x.Password == request.Password);
                
                if (user == null) return default;
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(request.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("email", user.Email) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var newToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(newToken);

                return new LoginResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = token
                };
            }
        }
    }
}