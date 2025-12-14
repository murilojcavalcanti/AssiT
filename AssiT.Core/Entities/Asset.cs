using AssiT.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class Asset: BaseEntity
    {
        public Asset(int? categoryId, string name, string serialNumber,
            DateTime? acquisitionDate, decimal? acquisitionValue, AssetStatus? assetStatus) : base(DateTime.Now)
        {
            CategoryId = categoryId;
            Name = name;
            SerialNumber = serialNumber;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
            AssetStatus = assetStatus;
        }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string Name { get; set; }
        
        public string SerialNumber { get; set; }
        
        public DateTime? AcquisitionDate { get; set; }
        public decimal? AcquisitionValue { get; set; }
        public AssetStatus? AssetStatus { get; set; }

        public void Update(Asset assetUpdated)
        {
            if (assetUpdated == null)
            {
                throw new ArgumentNullException(nameof(assetUpdated));
            }

            CategoryId = assetUpdated.CategoryId;
            Name = string.IsNullOrWhiteSpace(assetUpdated.Name) ? Name : assetUpdated.Name;
            SerialNumber = string.IsNullOrWhiteSpace(assetUpdated.SerialNumber) ? SerialNumber : assetUpdated.SerialNumber;
            AssetStatus = assetUpdated.AssetStatus == null|| (int)assetUpdated.AssetStatus == 0 ? AssetStatus : assetUpdated.AssetStatus;
            AcquisitionDate = assetUpdated.AcquisitionDate;
            AcquisitionValue = assetUpdated.AcquisitionValue;
            AssetStatus = assetUpdated.AssetStatus==null || (int)assetUpdated.AssetStatus==0?AssetStatus:assetUpdated.AssetStatus;
        }

    }
}