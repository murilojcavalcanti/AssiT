using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand:IRequest<ResultViewModel<int>>
    {
        public CreateUserCommand(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }

        [EmailAddress]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O email deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Name { get; set; }

        [Length(8, 16)]
        public string Password { get; set; }
        public User ToEntity()
        {
            return new User(Email,Name,Password);
        }
    }
}
