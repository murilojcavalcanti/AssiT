using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class CreateAssetCommand:IRequest<ResultViewModel<int>>
    {
        public CreateAssetCommand(int categoryId, string name, string serialNumber, DateTime acquisitionDate, decimal acquisitionValue)
        {
            CategoryId = categoryId;
            Name = name;
            SerialNumber = serialNumber;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
        }

        public int CategoryId { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "O nome do ativo deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [StringLength(15, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(10, ErrorMessage = "O numero de serie deve ter no minimo 10 caracteres")]
        public string SerialNumber { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor de aquisição deve ser maior que zero")]
        public decimal AcquisitionValue { get; set; }

        public Asset ToEntity()
        {
            return new Asset(CategoryId,Name,SerialNumber,AcquisitionDate,AcquisitionValue);
        }
    }
}
