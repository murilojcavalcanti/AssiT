using AssiT.Application.Models;
using AssiT.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Agenda.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class CreateAssetCommand:IRequest<ResultViewModel<int>>
    {
        public CreateAssetCommand(int categoryId, string number, string serialNumber, DateTime acquisitionDate, DateTime acquisitionValue)
        {
            CategoryId = categoryId;
            Number = number;
            SerialNumber = serialNumber;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
        }

        public int CategoryId { get; set; }

        [MaxLength(15)]
        public string Number { get; set; }

        [StringLength(15, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(10, ErrorMessage = "O numero de serie deve ter no minimo 10 caracteres")]
        public string SerialNumber { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        public DateTime AcquisitionValue { get; set; }

        public Asset ToEntity()
        {
            return new Asset(CategoryId,Number,SerialNumber,AcquisitionDate,AcquisitionValue);
        }
    }
}
