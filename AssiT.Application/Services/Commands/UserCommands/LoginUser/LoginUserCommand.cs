using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.UserCommands.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel<string>>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress]
        public string Email { get; set; }
        
        [Length(8, 16)]
        public string Password { get; set; }
        public User ToEntity()
        {
            return new User(Email,Password);
        }
    }
}
