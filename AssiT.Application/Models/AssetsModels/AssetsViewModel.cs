using AssiT.Core.Entities;
using AssiT.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AssiT.Application.Models.AssetModels;

public class AssetsViewModel
{
    public AssetsViewModel(int id, int? categoryId, string name, string serialNumber, DateTime? acquisitionDate, decimal? acquisitionValue, AssetStatus? status)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        SerialNumber = serialNumber;
        AcquisitionDate = acquisitionDate;
        AcquisitionValue = acquisitionValue;
        Status = status;
    }

    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public AssetStatus? Status { get; set; }
    public DateTime? AcquisitionDate { get; set; }
    public decimal? AcquisitionValue { get; set; }
    public static AssetsViewModel FromEntity(Asset Asset) =>
        new AssetsViewModel(
            id: Asset.Id,
            categoryId: Asset.CategoryId,
            name: Asset.Name,
            serialNumber: Asset.SerialNumber,
            acquisitionDate: Asset.AcquisitionDate,
            acquisitionValue: Asset.AcquisitionValue,
            status: Asset.AssetStatus
         );
}
