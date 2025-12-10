using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.UserCommands.LoginUser
{ 
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public LoginUserHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
            User loginUser = await _userRepository.Get(u => u.Email == request.Email);
            string hashPass = _authService.GenerateHash(request.Password);

            if (loginUser != null && loginUser.Password.ToUpper() == hashPass)
            {
                string token = _authService.GenerateToken(loginUser.Email,loginUser.Id);
                return ResultViewModel<string>.Success(token);
            }
            
            return ResultViewModel<string>.Error("Email ou Senha incorretos.");

        }
    }
}
