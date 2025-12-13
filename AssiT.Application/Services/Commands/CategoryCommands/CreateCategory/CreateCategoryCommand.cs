using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<ResultViewModel<int>>
    {
        [StringLength(20, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(3, ErrorMessage = "O numero de serie deve ter no minimo 10 caracteres")]
        public string Name { get; set; }

        public Category ToEntity()
        {
            return new Category(Name);
        }
    }
}
