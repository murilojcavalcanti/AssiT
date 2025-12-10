using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class Asset: BaseEntity
    {
        public Asset(int categoriaId, string number, string serialNumber, 
            DateTime acquisitionDate, DateTime acquisitionValue):base(DateTime.Now)
        {
            CategoryId = categoriaId;
            Number = number;
            SerialNumber = serialNumber;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
        }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [MaxLength(15)]
        public string Number { get; set; }
        
        [StringLength(15, ErrorMessage = "O numero de serie deve ter no máximo 15 caracteres")]
        [MinLength(10,ErrorMessage ="O numero de serie deve ter no minimo 10 caracteres")]
        public string SerialNumber { get; set; }
        
        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        public DateTime AcquisitionValue { get; set; }

        public void Update(Asset assetUpdated)
        {
            if (assetUpdated == null)
            {
                throw new ArgumentNullException(nameof(assetUpdated));
            }

            CategoryId = assetUpdated.CategoryId;
            Number = string.IsNullOrWhiteSpace(assetUpdated.Number) ? Number : assetUpdated.Number;
            SerialNumber = string.IsNullOrWhiteSpace(assetUpdated.SerialNumber) ? SerialNumber : assetUpdated.SerialNumber;
            AcquisitionDate = assetUpdated.AcquisitionDate;
            AcquisitionValue = assetUpdated.AcquisitionValue;
        }

    }
}