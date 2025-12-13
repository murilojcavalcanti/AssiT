using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ResultViewModel>
    {
        public UpdateCategoryCommand()
        {
            
        }
        public int Id { get; set; }

        [StringLength(15, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(10, ErrorMessage = "O numero de serie deve ter no minimo 10 caracteres")]
        public string Name { get; set; }

        public Category ToEntity()
        {
            return new Category(Name);
        }
    }
}
