using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.Get(u => u.Email == request.Email);
            if (existingUser != null)
            {
                return ResultViewModel<int>.Error("Já existe um usuário cadastrado com este e-mail.");
            }

            request.Password = _authService.GenerateHash(request.Password);

            User contact = request.ToEntity();
            await _userRepository.Insert(contact);
            return ResultViewModel<int>.Success(contact.Id);
        }
    }
}
