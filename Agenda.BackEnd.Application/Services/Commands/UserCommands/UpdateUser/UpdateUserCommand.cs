using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand:IRequest<ResultViewModel>
    {
        public UpdateUserCommand(string email, string name, int id)
        {
            Email = email;
            Name = name;
            Id = id;
        }

        public int Id { get; set; }

        [EmailAddress]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O email deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Name { get; set; }

        public User ToEntity()
        {
            return new User(Email,Name);
        }
    }
}
