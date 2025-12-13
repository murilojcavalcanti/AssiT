using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class Asset: BaseEntity
    {
        public Asset(int categoriaId, string name, string serialNumber, 
            DateTime acquisitionDate, decimal acquisitionValue):base(DateTime.Now)
        {
            CategoryId = categoriaId;
            Name = name;
            SerialNumber = serialNumber;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
        }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [StringLength(maximumLength:100,MinimumLength =3, ErrorMessage = "O nome do ativo deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }
        
        [StringLength(15, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(10,ErrorMessage ="O numero de serie deve ter no minimo 10 caracteres")]
        public string SerialNumber { get; set; }
        
        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        public decimal AcquisitionValue { get; set; }

        public void Update(Asset assetUpdated)
        {
            if (assetUpdated == null)
            {
                throw new ArgumentNullException(nameof(assetUpdated));
            }

            CategoryId = assetUpdated.CategoryId;
            Name = string.IsNullOrWhiteSpace(assetUpdated.Name) ? Name : assetUpdated.Name;
            SerialNumber = string.IsNullOrWhiteSpace(assetUpdated.SerialNumber) ? SerialNumber : assetUpdated.SerialNumber;
            AcquisitionDate = assetUpdated.AcquisitionDate;
            AcquisitionValue = assetUpdated.AcquisitionValue;
        }

    }
}