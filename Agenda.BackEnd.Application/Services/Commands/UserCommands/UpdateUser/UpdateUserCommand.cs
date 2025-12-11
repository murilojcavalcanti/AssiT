using AssiT.Application.Models;
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
        public string Email { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public User ToEntity()
        {
            return new User(Email,Name);
        }
    }
}
